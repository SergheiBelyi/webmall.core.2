using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using log4net;
using log4net.Config;
using Newtonsoft.Json;
using StackExchange.Profiling;
using ViewRes;
using Webmall.Model.Entities;
using Webmall.Model.Entities.Catalog;
using Webmall.Model.Entities.Catalog.Filters;
using Webmall.Model.Entities.Client;
using Webmall.Model.Repositories.Abstract;
using Webmall.UI.Core;
using Webmall.UI.Core.Ware;
using Webmall.UI.ViewModel.Catalog;
using Webmall.UI.ViewModel.Filter;

namespace Webmall.UI.Controllers
{
    public class CatalogServiceController : Controller
    {
        #region Logger

        private static readonly ILog Log = LogManager.GetLogger(typeof(CatalogServiceController));

        static CatalogServiceController()
        {
            XmlConfigurator.Configure();
        }

        #endregion

        private readonly ICatalogRepository _repository;
        private readonly IMapper _mapper;
        private readonly IWareHelper _offerProcessor;

        public CatalogServiceController(ICatalogRepository repository, IMapper mapper, IWareHelper offerProcessor)
        {
            _repository = repository;
            _mapper = mapper;
            _offerProcessor = offerProcessor;
        }

        public ActionResult Properties(string wareid)
        {
            if (wareid == null)
                return null;

            var localeId = UserPreferences.CurrentCulture;

            var props = _repository.GetWareProperties(localeId, wareid, null, null);

            return View("Properties", props);
        }

        public ActionResult ShortProperties(string wareid, string type, int cnt = 3)
        {
            if (wareid == null)
                return null;

            var localeId = UserPreferences.CurrentCulture;
            var props = _repository.GetWareProperties(localeId, wareid, null, null);
            var model = new WarePropertiesViewModel
            {
                List = props.Take(cnt).ToList(),
                Total = props.Count
            };

            if (type == "tile")
                return View("ShortPropertiesForTile", props);
            if (type == "table")
                return View("ShortPropertiesForTable", props);

            return View("ShortProperties", model);
        }

        public ActionResult Applicability(string wareid)
        {
            if (wareid == null)
                return null;

            var props = _repository.GetWareApplicability(UserPreferences.CurrentCulture, wareid, null, null);

            return View("Applicability", props);
        }

        public ActionResult Sets(string wareid)
        {
            if (wareid == null)
                return null;

            //var props = _repository.GetWareSets(UserPreferences.CurrentCulture, wareid, null, null);

            return View("Sets");
        }

        public ActionResult Related(string wareid)
        {
            if (wareid == null)
                return null;

            var props = _repository.GetRelatedWares(UserPreferences.CurrentCulture, wareid, null, null);

            return View("Related", props);
        }

        public ActionResult Offers(string wareid, string brand, string article, string filterParams,
            GridViewOptions options)
        {
            var filterOptions = JsonConvert.DeserializeObject<FilterOptions>(filterParams) ?? new FilterOptions();
            var profiler = MiniProfiler.Current;
            using (profiler.Step("Offers action"))
            {
                var localeId = UserPreferences.CurrentCulture;

                var currentClient = SessionHelper.CurrentClient;
                currentClient = new Client { Id = "4a5308eb-90c2-4e7a-b6e4-4b17bfbbb695" };
                if (currentClient == null)
                {
                    return null;
                }

                var ware = _repository.GetWare(localeId, wareid, article, brand);
                //ware.Producer = _repository.GetProducers().FirstOrDefault(i => i.Name == brand);
                var pageOptions = new PageOptions
                {
                    OrderColumn = options.SortColumn,
                    Direction = options.SortDirection
                };
                using (profiler.Step("Offers tasks"))
                {
                    var tasks = new[]
                    {
                        Task.Factory.StartNew(() =>
                        {
                            _repository.GetWareReplacements(localeId, ware.Id, article, brand,
                                currentClient.Id, "91611208-bbd1-11ec-84d5-90e2bab8558c",
                                "91611208-bbd1-11ec-84d5-90e2bab8558c", filterOptions, pageOptions);
                        }),
                        Task.Factory.StartNew(() =>
                        {
                            _repository.GetWareOffers(localeId, ware.Id, article, brand,
                                currentClient.Id, "91611208-bbd1-11ec-84d5-90e2bab8558c",
                                "91611208-bbd1-11ec-84d5-90e2bab8558c", new PageOptions());
                        }),
                    };

                    Task.WaitAll(tasks);
                }

                List<Offer> offers;
                List<WareReplacement> replacements;
                using (profiler.Step("Offers repository calls"))
                {
                    offers = _repository.GetWareOffers(localeId, ware.Id, article, brand,
                        currentClient.Id, "91611208-bbd1-11ec-84d5-90e2bab8558c",
                        "91611208-bbd1-11ec-84d5-90e2bab8558c", new PageOptions());
                    replacements = _repository.GetWareReplacements(localeId, ware.Id, article, brand,
                        currentClient.Id, "91611208-bbd1-11ec-84d5-90e2bab8558c",
                        "91611208-bbd1-11ec-84d5-90e2bab8558c", filterOptions, pageOptions);
                }

                using (profiler.Step("Offers processing"))
                {
                    var bestPriceOffers = offers?.OrderBy(i => i.ClientPrice).FirstOrDefault();
                    var bestDelivery = offers?.OrderBy(i => i.DeliveryTerm).FirstOrDefault();
                    var bestDeliveryRepl = replacements.OrderBy(i => i.DeliveryTerm).ThenBy(i => i.ClientPrice)
                        .ThenByDescending(i => i.AvailableQnt).FirstOrDefault();

                    var bestAnalogPriceOffer = replacements.OrderBy(i => i.ClientPrice).FirstOrDefault();

                    var totalModel = new AllOffersViewModel();

                    var model = new OffersViewModel
                    {
                        Valute = SessionHelper.CurrentValute
                    };

                    if (bestPriceOffers != null)
                        model.Offers.Add(NewOfferViewModel("Самая низкая цена", ware, bestPriceOffers));
                    if (bestDeliveryRepl != null && (bestDelivery == null ||
                                                     bestDeliveryRepl.DeliveryTerm <= bestDelivery.DeliveryTerm))
                        model.Offers.Add(NewOfferViewModel("Лучший срок поставки",
                            _mapper.Map<Ware>(bestDeliveryRepl.Ware), bestDeliveryRepl));
                    else if (bestDelivery != null)
                        model.Offers.Add(NewOfferViewModel("Лучший срок поставки", ware, bestDelivery));
                    if (bestAnalogPriceOffer != null)
                        model.Offers.Add(NewOfferViewModel("Самый дешевый аналог",
                            _mapper.Map<Ware>(bestAnalogPriceOffer.Ware), bestAnalogPriceOffer));

                    totalModel.BestOffers = model;

                    if (offers != null)
                    {
                        var offersQuery = offers.AsQueryable();
                        if (filterOptions.PriceMax.HasValue)
                            offersQuery = offersQuery.Where(i => i.ClientPrice <= filterOptions.PriceMax);
                        if (filterOptions.PriceMin > 0)
                            offersQuery = offersQuery.Where(i => i.ClientPrice >= filterOptions.PriceMin);

                        offers = offersQuery.ToList();
                        model = new OffersViewModel
                        {
                            Valute = SessionHelper.CurrentValute,
                            Caption = "На складе"
                        };

                        foreach (var offer in offers.Where(i => i.MyWarehouse))
                        {
                            model.Offers.Add(NewOfferViewModel(null, ware, offer));
                        }

                        totalModel.TableOffers.Add(model);

                        model = new OffersViewModel
                        {
                            Valute = SessionHelper.CurrentValute,
                            Caption = "ИСКОМЫЙ АРТИКУЛ",
                            PageOptions = pageOptions
                        };
                        foreach (var offer in offers.Where(i => !i.MyWarehouse))
                        {
                            model.Offers.Add(NewOfferViewModel(null, ware, offer));
                        }

                        totalModel.TableOffers.Add(model);
                    }

                    model = new OffersViewModel
                    {
                        Valute = SessionHelper.CurrentValute,
                        Caption = "Аналоги",
                        PageOptions = pageOptions
                    };

                    using (profiler.Step("Offers filters preparing"))
                    {
                        var offerProducers = replacements.Select(i => i.Ware.ProducerId).ToList();
                        offerProducers.Add(ware.ProducerId);
                        var filter = PrepareCommonOffersFilters(filterOptions, offerProducers, offers, replacements);
                        filter.PropertySections = PreparePropertiesFilters(filterOptions, ware.Id, replacements);
                        totalModel.FilterViewModel = filter;
                    }

                    using (profiler.Step("Offers filtering"))
                    {
                        if (replacements.Any())
                        {
                            var producers = _repository.GetProducers();
                            var replQuery = replacements.AsQueryable();
                            if (filterOptions.Producers?.Any() == true)
                                replQuery = replQuery.Where(i => filterOptions.Producers.Contains(i.Ware.ProducerId));
                            if (filterOptions.PriceMax.HasValue)
                                replQuery = replQuery.Where(i => i.ClientPrice <= filterOptions.PriceMax);
                            if (filterOptions.PriceMin > 0)
                                replQuery = replQuery.Where(i => i.ClientPrice >= filterOptions.PriceMin);
                            if (filterOptions.Properties?.Any() == true)
                                replQuery = replQuery.Where(i => i.Properties.Any(p => filterOptions.Properties.Any(fp => p.Id == fp)));
                            foreach (var offer in replQuery)
                            {
                                OfferViewModel offerViewModel;
                                model.Offers.Add(offerViewModel =
                                    NewOfferViewModel(null, _mapper.Map<Ware>(offer.Ware), offer));
                                offerViewModel.IsReplacement = true;
                                offerViewModel.Ware.Producer =
                                    producers.FirstOrDefault(i => i.Name == offer.Ware.ProducerName);
                            }
                        }
                    }

                    totalModel.TableOffers.Add(model);
                    return PartialView("_Offers", totalModel);
                }
            }
        }

        private List<SelectViewModel> PreparePropertiesFilters(FilterOptions filterOptions, string origWareId, List<WareReplacement> replacements)
        {
            var props = LoadReplacementProperties(origWareId, replacements);

            var propertySections = new List<SelectViewModel>();
            foreach (var group in props.OrderByDescending(i => i.Importance).ThenBy(i => i.Name))
            {
                var section = new SelectViewModel
                {
                    Caption = group.Name,
                    Name = "properties",
                    SectionIsOpened = false,
                    //SectionIsHidden = !m.ShowAllSections,
                    //AutoSubmit = m.AutoSubmit,
                    IsFilterable = group.AvailableValues.Count > 30,
                    ShowSelectMoreLink = true
                };
                foreach (var item in group.AvailableValues)
                {
                    //var id = item.Id.Trim().ToHex() + CommonHelpers.PropertyDivider + group.Name.Trim().ToHex();
                    var id = item.Id;
                    var selected = (filterOptions?.Properties != null && filterOptions.Properties.Contains(id));
                    section.Options.Add(new SelectListItem { Text = item.Value, Value = id, Selected = selected });
                }

                if (section.Options.Any(i => i.Selected))
                {
                    section.SectionIsOpened = true;
                }

                propertySections.Add(section);
            }

            if (propertySections.Any(i => i.SectionIsHidden))
            {
                var last = propertySections.LastOrDefault(i => !i.SectionIsHidden);
                if (last != null)
                {
                    last.ShowSelectMoreLink = true;
                }
            }

            return propertySections;
        }

        private List<GroupProperty> LoadReplacementProperties(string origWareId, List<WareReplacement> replacements)
        {
            var localeId = UserPreferences.CurrentCulture;
            var props = new List<GroupProperty>();

            foreach (var wareId in replacements.Where(i => i.Ware.Id != null).Select(i => i.Ware.Id).Union(new[] {origWareId}))
            {
                var wareProps = _repository.GetWareProperties(localeId, wareId, null, null);
                foreach (var offer in replacements.Where(i => i.Ware.Id == wareId))
                {
                    offer.Properties = wareProps;
                }

                foreach (var wareProp in wareProps)
                {
                    var prop = props.FirstOrDefault(i => i.Id == wareProp.PropTypeId);
                    if (prop == null)
                    {
                        props.Add(new GroupProperty
                        {
                            Id = wareProp.PropTypeId,
                            Name = wareProp.Name,
                            AvailableValues = new List<GroupPropertyAvailableValues>
                                {new GroupPropertyAvailableValues {Id = wareProp.Id, Value = wareProp.Value}}
                        });
                        continue;
                    }

                    if (prop.AvailableValues.Any(i => i.Value == wareProp.Value))
                        continue;
                    prop.AvailableValues.Add(new GroupPropertyAvailableValues {Id = wareProp.Id, Value = wareProp.Value});
                }
            }

            return props;
        }

        private OffersFilterViewModel PrepareCommonOffersFilters(FilterOptions filterOptions, List<string> offerProducers, List<Offer> offers,
            List<WareReplacement> replacements)
        {
            var filter = CatalogFilterViewModel.Create<OffersFilterViewModel>(filterOptions, null,
                _repository.GetProducers().Where(i => offerProducers.Contains(i.Id)).ToList(), null);

            filter.ShowSearchFilter = false;
            filter.ShowPriceFilter = true;
            filter.ClientPrice = new RangeViewModel
            {
                Caption = SharedResources.PurchasePrice,
                MinSelected = filterOptions.PriceMin,
                MaxSelected = filterOptions.PriceMax,
                Max = (int)Math.Ceiling(Math.Max(offers?.Any() == true ? offers.Max(i => i.ClientPrice) : 0,
                    replacements.Any() ? replacements.Max(i => i.ClientPrice) : 0)),
                Min = (int)Math.Min(offers?.Any() == true ? offers.Min(i => i.ClientPrice) : 0,
                    replacements.Any() ? replacements.Min(i => i.ClientPrice) : 0),
                NameMax = "PriceMax",
                NameMin = "PriceMin",
            };

            filter.ReturnDays = new RangeViewModel
            {
                Caption = SharedResources.ReturnPeriod,
                MinSelected = filterOptions.MinReturnTerm,
                MaxSelected = null,
                Max = 100,
                Min = 0,
                NameMax = null,
                NameMin = nameof(filterOptions.MinReturnTerm),
                Step = 1
            };

            filter.DeliveryRating = new RangeViewModel
            {
                Caption = SharedResources.DeliveryProbability,
                MinSelected = filterOptions.MinDeliveryRating,
                MaxSelected = null,
                Max = 100,
                Min = 0,
                NameMax = null,
                NameMin = nameof(filterOptions.MinDeliveryRating),
                Step = 1
            };

            filter.AvailableQnt = new RangeViewModel
            {
                Caption = SharedResources.Quantity,
                MinSelected = filterOptions.MinQnt,
                MaxSelected = null,
                Max = (int)Math.Ceiling(Math.Max(offers?.Any() == true ? offers.Max(i => i.AvailableQnt) ?? 0 : 0,
                    replacements.Any() ? replacements.Max(i => i.AvailableQnt) ?? 0 : 0)),
                Min = 0,
                NameMax = null,
                NameMin = nameof(filterOptions.MinQnt),
                Step = 1
            };

            filter.DeliveryDays = new RangeViewModel
            {
                Caption = SharedResources.TermDays,
                MinSelected = null,
                MaxSelected = filterOptions.MaxDeliveryTerm,
                Max = Math.Max(offers?.Any() == true ? offers.Max(i => i.DeliveryDays) : 0,
                    replacements.Any() ? replacements.Max(i => i.DeliveryDays) : 0),
                Min = Math.Min(offers?.Any() == true ? offers.Min(i => i.DeliveryDays) : 0,
                    replacements.Any() ? replacements.Min(i => i.DeliveryDays) : 0),
                NameMax = nameof(filterOptions.MaxDeliveryTerm),
                NameMin = null,
                Step = 1
            };

            filter.ShowSection = new SelectViewModel
            {
                Caption = SharedResources.Visibility,
                Name = "visibility",
                Options = new List<SelectListItem>
                {
                    new SelectListItem
                    {
                        Value = ((int) Visibility.Analogues).ToString(), Text = SharedResources.ShowAnalogues,
                        Selected = filterOptions.Visibility.Contains(Visibility.Analogues)
                    },
                    new SelectListItem
                    {
                        Value = ((int) Visibility.ClientPrice).ToString(), Text = SharedResources.PurchasePrice,
                        Selected = filterOptions.Visibility.Contains(Visibility.ClientPrice)
                    },
                    new SelectListItem
                    {
                        Value = ((int) Visibility.SalePrice).ToString(), Text = SharedResources.SalePrice,
                        Selected = filterOptions.Visibility.Contains(Visibility.SalePrice)
                    },
                },
                SectionIsOpened = true
            };

            filter.ActionsSection = new SelectViewModel
            {
                Caption = SharedResources.Action,
                Name = "actions",
                Options = new List<SelectListItem>
                {
                    new SelectListItem
                    {
                        Value = ((int) Actions.Actions).ToString(), Text = SharedResources.Action,
                        Selected = filterOptions.Actions.Contains(Actions.Actions)
                    },
                    new SelectListItem
                    {
                        Value = ((int) Actions.New).ToString(), Text = SharedResources.NewWare,
                        Selected = filterOptions.Actions.Contains(Actions.New)
                    },
                    new SelectListItem
                    {
                        Value = ((int) Actions.Sales).ToString(), Text = SharedResources.Sale,
                        Selected = filterOptions.Actions.Contains(Actions.Sales)
                    },
                },
                SectionIsOpened = true
            };
            return filter;
        }

        /* Separate offers actions
        public ActionResult BestOffers(string wareid, string brand, string article, FilterOptions filterOptions, GridViewOptions options)
        {
            var profiler = MiniProfiler.Current;
            using (profiler.Step("BestOffers action"))
            {
                var localeId = UserPreferences.CurrentCulture;

                var currentClient = SessionHelper.CurrentClient;
                currentClient = new Client { Id = "4a5308eb-90c2-4e7a-b6e4-4b17bfbbb695" };
                if (currentClient == null)
                {
                    return null;
                }

                var ware = _repository.GetWare(localeId, wareid, article, brand);
                //ware.Producer = _repository.GetProducers().FirstOrDefault(i => i.Name == brand);
                var pageOptions = new PageOptions
                {
                    OrderColumn = options.SortColumn,
                    Direction = options.SortDirection
                };

                var tasks = new[]
                {
                Task.Factory.StartNew(() => { _repository.GetWareReplacements(localeId, wareid, article, brand,
                    currentClient.Id, "91611208-bbd1-11ec-84d5-90e2bab8558c", "91611208-bbd1-11ec-84d5-90e2bab8558c", filterOptions, pageOptions); }),
                Task.Factory.StartNew(() => { _repository.GetWareOffers(localeId, wareid, article, brand,
                    currentClient.Id, "91611208-bbd1-11ec-84d5-90e2bab8558c", "91611208-bbd1-11ec-84d5-90e2bab8558c", new PageOptions()); }),

            };

                Task.WaitAll(tasks);

                var offers = _repository.GetWareOffers(localeId, wareid, article, brand,
                    currentClient.Id, "91611208-bbd1-11ec-84d5-90e2bab8558c", "91611208-bbd1-11ec-84d5-90e2bab8558c", new PageOptions());
                var replacements = _repository.GetWareReplacements(localeId, wareid, article, brand,
                    currentClient.Id, "91611208-bbd1-11ec-84d5-90e2bab8558c", "91611208-bbd1-11ec-84d5-90e2bab8558c", filterOptions, pageOptions);

                var bestPriceOffers = offers?.OrderBy(i => i.ClientPrice).FirstOrDefault();
                var bestDelivery = offers?.OrderBy(i => i.DeliveryTerm).FirstOrDefault();
                var bestDeliveryRepl = replacements.OrderBy(i => i.DeliveryTerm).ThenBy(i => i.ClientPrice).ThenByDescending(i => i.AvailableQnt).FirstOrDefault();

                var bestAnalogPriceOffer = replacements.OrderBy(i => i.ClientPrice).FirstOrDefault();

                var model = new OffersViewModel
                {
                    Valute = SessionHelper.CurrentValute
                };

                if (bestPriceOffers != null) model.Offers.Add(NewOfferViewModel("Самая низкая цена", ware, bestPriceOffers));
                if (bestDeliveryRepl != null && (bestDelivery == null || bestDeliveryRepl.DeliveryTerm <= bestDelivery.DeliveryTerm))
                    model.Offers.Add(NewOfferViewModel("Лучший срок поставки", _mapper.Map<Ware>(bestDeliveryRepl.Ware), bestDeliveryRepl));
                else if (bestDelivery != null)
                    model.Offers.Add(NewOfferViewModel("Лучший срок поставки", ware, bestDelivery));
                if (bestAnalogPriceOffer != null) model.Offers.Add(NewOfferViewModel("Самый дешевый аналог", _mapper.Map<Ware>(bestAnalogPriceOffer.Ware), bestAnalogPriceOffer));

                return View("BestOffers", model);
            }
        }

        public ActionResult WarehouseOffers(string wareid, string brand, string article, FilterOptions filterOptions, GridViewOptions options, bool isMob = false)
        {
            var localeId = UserPreferences.CurrentCulture;
            var currentClient = SessionHelper.CurrentClient;
            currentClient = new Client { Id = "4a5308eb-90c2-4e7a-b6e4-4b17bfbbb695" };
            if (currentClient == null)
            {
                return null;
            }

            var pageOptions = new PageOptions
            {
                OrderColumn = options.SortColumn,
                Direction = options.SortDirection
            };

            OffersViewModel model = new OffersViewModel
            {
                Valute = SessionHelper.CurrentValute,
                Caption = "На складе"
            };
            var ware = _repository.GetWare(localeId, wareid, article, brand);

            var offers = _repository.GetWareOffers(localeId, wareid, article, brand,
                currentClient.Id, "91611208-bbd1-11ec-84d5-90e2bab8558c", "91611208-bbd1-11ec-84d5-90e2bab8558c", pageOptions);

            foreach (var offer in offers.Where(i => i.MyWarehouse))
            {
                model.Offers.Add(NewOfferViewModel(null, ware, offer));
            }

            if (isMob) return View("OffersTableMob", model);

            return View("OffersTable", model);
        }

        public ActionResult NonWarehouseOffers(string wareid, string brand, string article, FilterOptions filterOptions, GridViewOptions options, bool isMob = false)
        {
            var localeId = UserPreferences.CurrentCulture;
            var currentClient = SessionHelper.CurrentClient;
            currentClient = new Client { Id = "4a5308eb-90c2-4e7a-b6e4-4b17bfbbb695" };
            if (currentClient == null)
            {
                return null;
            }

            var pageOptions = new PageOptions
            {
                OrderColumn = options.SortColumn,
                Direction = options.SortDirection
            };

            OffersViewModel model = new OffersViewModel
            {
                Valute = SessionHelper.CurrentValute,
                Caption = "ИСКОМЫЙ АРТИКУЛ",
                PageOptions = pageOptions
            };
            var ware = _repository.GetWare(localeId, wareid, article, brand);

            var tasks = new List<Task>
            {
                Task.Factory.StartNew(() => { _repository.GetWareReplacements(localeId, wareid, article, brand,
                    currentClient.Id, "91611208-bbd1-11ec-84d5-90e2bab8558c", "91611208-bbd1-11ec-84d5-90e2bab8558c", filterOptions, pageOptions); }),
                Task.Factory.StartNew(() => { _repository.GetWareOffers(localeId, wareid, article, brand,
                    currentClient.Id, "91611208-bbd1-11ec-84d5-90e2bab8558c", "91611208-bbd1-11ec-84d5-90e2bab8558c", pageOptions); }),
            };

            //Task.WaitAny();

            var offers = _repository.GetWareOffers(localeId, wareid, article, brand,
                currentClient.Id, "91611208-bbd1-11ec-84d5-90e2bab8558c", "91611208-bbd1-11ec-84d5-90e2bab8558c", pageOptions);

            foreach (var offer in offers.Where(i => !i.MyWarehouse))
            {
                model.Offers.Add(NewOfferViewModel(null, ware, offer));
            }

            if (isMob) return View("OffersTableMob", model);

            return View("OffersTable", model);
        }

        public ActionResult Analogs(string wareid, string brand, string article, FilterOptions filterOptions, GridViewOptions options, bool isMob = false)
        {
            var localeId = UserPreferences.CurrentCulture;
            var currentClient = SessionHelper.CurrentClient;
            currentClient = new Client { Id = "4a5308eb-90c2-4e7a-b6e4-4b17bfbbb695" };
            if (currentClient == null)
            {
                return null;
            }

            var pageOptions = new PageOptions
            {
                OrderColumn = options.SortColumn,
                Direction = options.SortDirection
            };
            OffersViewModel model = new OffersViewModel
            {
                Valute = SessionHelper.CurrentValute,
                Caption = "Аналоги",
                PageOptions = pageOptions
            };

            var replacements = _repository.GetWareReplacements(localeId, wareid, article, brand,
                currentClient.Id, "91611208-bbd1-11ec-84d5-90e2bab8558c", "91611208-bbd1-11ec-84d5-90e2bab8558c", filterOptions, pageOptions);

            if (replacements.Any())
            {
                var producers = _repository.GetProducers();
                foreach (var offer in replacements)
                {
                    OfferViewModel offerViewModel;
                    model.Offers.Add(offerViewModel = NewOfferViewModel(null, _mapper.Map<Ware>(offer.Ware), offer));
                    offerViewModel.Ware.Producer = producers.FirstOrDefault(i => i.Name == offer.Ware.ProducerName);
                }
            }

            if (isMob) return View("OffersTableMob", model);

            return View("OffersTable", model);
        }
        */

        private OfferViewModel NewOfferViewModel(string caption, Ware ware, Offer offer)
        {
            var model = new OfferViewModel
            {
                Caption = caption,
                Ware = ware,
            };
            model.Offer = _offerProcessor.ProcessWareOffer(ware, offer, model);
            return model;
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetWarePropsList(string id, int? modif, string type)
        {
            var localeId = UserPreferences.CurrentCulture;
            var props = _repository.GetWareProperties(localeId, id, null, null);
            var viewParam = type == "mobTable" ? "Table" : type;
            return View("GetWarePropsList" + viewParam, props);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult AvailableNumbers(string search, int? searchType)
        {
            var strippedSearch = Regex.Replace(search, @"[.\\ -]", "");
            if (string.IsNullOrEmpty(strippedSearch) || search.Length < 3)
                return new JsonResult { Data = new List<AvailableNumber>(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            var result = _repository.GetAvailableNumbersForSearch(SessionHelper.CurrentClientId, strippedSearch, searchType ?? 0);

            return new JsonResult { Data = result.Take(30), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetWareImages(string id, string article, string producer)
        {
            var model = _repository.GetWareImageIds(UserPreferences.CurrentCulture, id, article, producer);

            return PartialView(model);
        }
    }
}