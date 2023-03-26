using System;
using System.Linq;
using System.Web;
using AutoMapper;
using Webmall.Model.Repositories.Abstract;
using Webmall.Model.Entities;
using Webmall.Model.Entities.Auto;
using System.Collections.Generic;
using System.Reflection;
using Webmall.Model.PriceAggregator.Core;
using System.Net.Http;
using System.Web.Caching;
using System.Web.UI.WebControls;
using Webmall.Model.PriceAggregator.DataModels.Groups;
using Webmall.Model.PriceAggregator.DataModels;
using log4net;
using log4net.Config;
using StackExchange.Profiling;
using Webmall.Model.Entities.Catalog;
using Webmall.Model.PriceAggregator.DataModels.Ware;

namespace Webmall.Model.PriceAggregator.Repositories
{
    public class CatalogRepository : Test.Repositories.CatalogRepository, ICatalogRepository
    {
        private static readonly HttpClient Client;
        private readonly IMapper _mapper;
        private readonly ICmsRepository _cmsRepository;


        #region Logger

        private static readonly ILog Log = LogManager.GetLogger(typeof(CatalogRepository));

        static CatalogRepository()
        {
            Client = HttpHelper.InitPriceAggregatorClient();
            XmlConfigurator.Configure();
        }
        #endregion

        public CatalogRepository(IMapper mapper, ICmsRepository cmsRepository) : base(cmsRepository)
        {
            _mapper = mapper;
            _cmsRepository = cmsRepository;
        }
        private static readonly object GetWaregroupsListLock = new object();
        public override List<Group> GetWaregroups(string localeId)
        {
            var key = MethodBase.GetCurrentMethod()?.Name + localeId;
            var list = HttpRuntime.Cache.Get(key, GetWaregroupsListLock, () =>
            {
                List<Group> result = new List<Group>();
                try
                {
                    var requestModel = Client.GetRequest<List<GroupsModel>>(Core.ConfigHelper.CatalogGroups, new[,] { { "asTree", "true" }, { "culture", localeId } });
                    result = _mapper.Map<List<Group>>(requestModel);
                }
                catch (Exception e)
                {
                    Log.Error("GetWaregroups error", e);
                }
                if (result.Count > 0)
                {
                    var wareGroupsSquidex = _cmsRepository.GetWaregroups();
                    foreach (var item in wareGroupsSquidex)
                    {
                        var group = result.FirstOrDefault(i => i.Id == item.IdGroup);
                        if (group != null)
                        {
                            group.Name = item.Name;
                            group.Order = item.Order;
                            group.Url = item.Slug;
                            group.ImageUrl = item.ImageUrl;
                            group.IsNew = item.IsNew;
                            group.Title = item.Title;
                            group.Description = item.Description;
                            group.Keywords = item.Keywords;
                        }
                    }

                    void SetParent(IEnumerable<Group> groups)
                    {
                        foreach (var group in groups.Where(i => i.Children != null))
                        {
                            foreach (var child in group.Children)
                            {
                                child.Parent = group;
                            }
                            SetParent(group.Children);
                        }
                    }

                    SetParent(result);
                }

                return result;
            });
            return list;

        }

        private static readonly object GetProducersLock = new object();
        public override List<Producer> GetProducers()
        {
            var key = MethodBase.GetCurrentMethod()?.Name;
            var list = HttpRuntime.Cache.Get(key, GetProducersLock, () =>
            {
                List<Producer> result = new List<Producer>();
                try
                {
                    var requestModel = Client.GetRequest<List<ProducerModel>>(Core.ConfigHelper.Brands);
                    result = _mapper.Map<List<Producer>>(requestModel);
                    if (result.Count > 0)
                    {
                        var producersSquidex = _cmsRepository.GetBrands();
                        foreach (var item in producersSquidex)
                        {
                            var orig = result.FirstOrDefault(i => i.Name == item.OriginalName);
                            if (orig == null) continue;

                            //if (!string.IsNullOrEmpty(item.Name))
                            //    orig.Name = item.Name;
                            orig.IsRecommended = item.IsRecommended;
                            orig.Brand = item;
                            //orig.Order = item.Order;
                            orig.Country = item.CountryOrigin ?? orig.Country;
                            orig.SiteUrl = item.LinkOrigin ?? orig.SiteUrl;
                            orig.CatalogUrl = item.LinkCatalog ?? orig.CatalogUrl;
                            orig.IsAction = item.IsAction ?? orig.IsAction;
                            orig.ImageUrl = item.Image ?? orig.ImageUrl;
                            //orig.IsNew = item.IsNew;
                            orig.Title = item.Title ?? orig.Title;
                            orig.Description = item.Description ?? orig.Description;
                            orig.Keywords = item.Keywords ?? orig.Keywords;
                        }
                    }
                }
                catch (Exception e)
                {
                    Log.Error("GetProducers error", e);
                }
                return result;

            });
            return list;

        }

        public override List<string> GetGroupProducers(string groupId)
        {
            var key = MethodBase.GetCurrentMethod()?.Name + groupId;
            var list = HttpRuntime.Cache.Get(key, GetProducersLock, () =>
            {
                List<string> result = new List<string>();
                try
                {
                    var requestModel = Client.GetRequest<List<GroupPropertyAvailableValues>>($"{Core.ConfigHelper.BrandsId}{groupId}");
                    result = requestModel.Select((item, i) => item.Id).ToList();
                }
                catch (Exception e)
                {
                    Log.Error("GetGroupProducers error", e);
                }
                return result;

            });
            return list;
        }

        private static readonly object GetGroupPropertiesLock = new object();
        public override List<GroupProperty> GetGroupProperties(string localeId, string groupId)
        {
            var key = MethodBase.GetCurrentMethod()?.Name + localeId + groupId;
            var list = HttpRuntime.Cache.Get(key, GetGroupPropertiesLock, () =>
            {
                List<GroupProperty> result = new List<GroupProperty>();
                try
                {
                    var requestModel = Client.GetRequest<List<GroupPropertyModel>>($"{Core.ConfigHelper.GroupProps}{groupId}", new[,] { { "culture", localeId } });
                    result = _mapper.Map<List<GroupProperty>>(requestModel);
                }
                catch (Exception e)
                {
                    Log.Error("GetGroupProperties error", e);
                }
                return result;

            });
            return list;
        }

        private static readonly object GetWareLock = new object();
        public override WareList GetWareList(string localeId, FilterOptions filterOptions, PageOptions pageOptions, bool forBot)
        {
            //var key = MethodBase.GetCurrentMethod()?.Name + localeId+filterOptions.ToJson()+pageOptions.ToJson()+forBot;
            //WareList list = HttpRuntime.Cache.Get(key, GetWareLock, () =>
            //{
            WareList result = new WareList();
            try
            {
                var producers = filterOptions.Producers?.Select(i => new KeyValuePair<string, string>("Producers", i)).ToList();
                var props = filterOptions.Properties?.Select(i => new KeyValuePair<string, string>("Properties", i)).ToList();
                var strings = new List<KeyValuePair<string, string>> {
                    new KeyValuePair<string, string> ("searchString", filterOptions.Search),
                    new KeyValuePair<string, string> ("groupId", filterOptions.WareGroupId),
                    new KeyValuePair<string, string> ("OrderColumn", pageOptions.OrderColumn),
                    new KeyValuePair<string, string> ("SortDirection", (pageOptions.Direction == SortDirection.Ascending ? 0 : 1).ToString()),
                    new KeyValuePair<string, string> ("PageNumber", pageOptions.PageNumber.ToString()),
                    new KeyValuePair<string, string> ("PageSize", pageOptions.PageSize.ToString())
                };

                if (producers!= null)
                    strings.AddRange(producers);
                if (props != null)
                    strings.AddRange(props);

                var requestModel = Client.GetRequest<WareListModel>(Core.ConfigHelper.WareList, strings);

                result = new WareList
                {
                    Wares = _mapper.Map<List<Entities.Catalog.WareListItem>>(requestModel.Wares),
                    CountAllProduct = requestModel.FoundRows,
                    ManufacturerIdentifiers = requestModel.Brands.Select(i => i.Id).ToList()
                };

                //result = _mapper.Map<WareList>(requestModel);
            }
            catch (Exception e)
            {
                Log.Error("GetWareList error", e);
            }

            return result;
            //});
            //return list;
        }

        public override Ware GetWare(string localeId, string wareId, string article, string producer)
        {
            var key = MethodBase.GetCurrentMethod()?.Name + $"{localeId}_{wareId}_{article}_{producer}";
            var result = HttpRuntime.Cache.Get(key, GetWareLock, () =>
            {
                try
                {
                    var requestModel = Client.GetRequest<WareModel>(Core.ConfigHelper.Ware, new[,] {
                        { "WareId", wareId },
                        { "Brand", producer },
                        { "Article", article },
                        { "culture", localeId }});
                    var ware = _mapper.Map<Ware>(requestModel) ?? new Ware { WareNumber = article, ProducerName = producer};
                    var producerObj = GetProducers().FirstOrDefault(i => i.Name.ToLower() == ware.ProducerName.ToLower());
                    ware.ProducerId = producerObj?.Id;
                    return ware;
                }
                catch (Exception e)
                {
                    Log.Error("GetWare error", e);
                }

                return null;
            });
            return result;
        }

        private static readonly object GetWareApplicabilityLock = new object();
        public override List<Applicability> GetWareApplicability(string localeId, string wareId, string article, string producer)
        {
            var key = MethodBase.GetCurrentMethod()?.Name + $"{localeId}_{wareId}_{article}_{producer}";
            var list = HttpRuntime.Cache.Get(key, GetWareApplicabilityLock, () =>
            {
                List<Applicability> result = new List<Applicability>();
                try
                {
                    var requestModel = Client.GetRequest<List<WareApplicabilityModel>>(Core.ConfigHelper.WareApplicability, new[,] {
                        { "WareId", wareId },
                        { "Brand", producer },
                        { "Article", article },
                        { "culture", localeId }});
                    result = _mapper.Map<List<Applicability>>(requestModel);
                }
                catch (Exception e)
                {
                    Log.Error("GetWare error", e);
                }

                return result;
            });
            return list;
        }


        private static readonly object GetWareOffersLock = new object();
        public override List<Offer> GetWareOffers(string localeId, string wareId, string article, string producer, string clientId, string shipmentAddressId, string deliveryAddressId, PageOptions pageOptions)
        {
            var profiler = MiniProfiler.Current;
            using (profiler.Step("GetWareOffers"))
            {
                var key = MethodBase.GetCurrentMethod()?.Name +
                          $"{localeId}{wareId}{article}{producer}{clientId}{shipmentAddressId}{deliveryAddressId}";
                var list = HttpRuntime.Cache.Get(key, GetWareOffersLock, () =>
                {
                    var result = new List<Offer>();
                    try
                    {
                        using (profiler.Step("GetWareOffers request"))
                        {
                            var requestModel = Client.GetRequest<List<OfferModel>>(Core.ConfigHelper.WareOffers, new[,]
                            {
                                {"ClientId", clientId},
                                {"AddressId", deliveryAddressId},
                                {"ShipmentAddressId", shipmentAddressId},
                                {"WareId", wareId},
                                {"Article", article},
                                {"Brand", producer}
                            });
                            result = _mapper.Map<List<Offer>>(requestModel);
                        }
                    }
                    catch (Exception e)
                    {
                        Log.Error("GetWareOffers error", e);
                    }

                    return result;
                }, CacheItemPriority.Low, null, 1);
                return list;
            }
        }

        private static readonly object GetWarePropertiesLock = new object();
        public override List<WareProperty> GetWareProperties(string localeId, string wareId, string article, string producer)
        {
            var key = MethodBase.GetCurrentMethod()?.Name + $"{localeId}{wareId}{article}{producer}";
            var list = HttpRuntime.Cache.Get(key, GetWarePropertiesLock, () =>
            {
                List<WareProperty> result = new List<WareProperty>();
                try
                {
                    var requestModel = Client.GetRequest<List<WarePropertiesModel>>(Core.ConfigHelper.WareProperties, new[,] {
                            { "WareId", wareId },
                            { "Brand", producer },
                            { "Article", article },
                            { "localeId", localeId }});
                    result = _mapper.Map<List<WareProperty>>(requestModel);
                }
                catch (Exception e)
                {
                    Log.Error("GetWareProperties error", e);
                }
                return result;
            });
            return list;
        }

        private static readonly object GetWareReplacementsLock = new object();
        public override List<WareReplacement> GetWareReplacements(string localeId, string wareId, string article, string producer, string clientId, string shipmentAddressId, string deliveryAddressId, FilterOptions filterOptions, PageOptions pageOptions)
        {
            var profiler = MiniProfiler.Current;
            using (profiler.Step("GetWareReplacements"))
            {
                var key = MethodBase.GetCurrentMethod()?.Name +
                          $"{localeId}{wareId}{article}{producer}{clientId}{shipmentAddressId}{deliveryAddressId}";
                var list = HttpRuntime.Cache.Get(key, GetWareReplacementsLock, () =>
                {
                    var result = new List<WareReplacement>();
                    try
                    {
                        var producers = filterOptions.Producers
                            ?.Select(i => new KeyValuePair<string, string>("Producers", i)).ToList();
                        using (profiler.Step("GetWareReplacements request"))
                        {
                            var strings = new List<KeyValuePair<string, string>>
                            {
                                new KeyValuePair<string, string>("ClientId", clientId),
                                new KeyValuePair<string, string>("AddressId", deliveryAddressId),
                                new KeyValuePair<string, string>("ShipmentAddressId", shipmentAddressId),
                                new KeyValuePair<string, string>("WareId", wareId),
                                new KeyValuePair<string, string>("Brand", producer),
                                new KeyValuePair<string, string>("Article", article)
                            };

                            if (producers != null)
                                strings.AddRange(producers);

                            var requestModel =
                                Client.GetRequest<List<WareReplacementsModel>>(Core.ConfigHelper.WareReplacements, strings);
                            result = _mapper.Map<List<WareReplacement>>(requestModel);
                        }
                    }
                    catch (Exception e)
                    {
                        Log.Error("GetWareProperties error", e);
                    }

                    return result;
                });
                return list;
            }
        }

        private static readonly object GetWareImageLock = new object();
        public override List<string> GetWareImageIds(string localeId, string wareId, string article, string producer)
        {
            var key = MethodBase.GetCurrentMethod()?.Name + $"{localeId}{wareId}{article}{producer}";
            var list = HttpRuntime.Cache.Get(key, GetWareImageLock, () =>
            {
                List<string> result = new List<string>();
                try
                {
                    var requestModel = Client.GetRequest<List<WareImageIdModel>>(Core.ConfigHelper.WareImages, new[,] {
                            { "WareId", wareId },
                            { "Brand", producer },
                            { "Article", article }});

                    result = requestModel.Select(i => i.Id.ToString()).ToList();
                }
                catch (Exception e)
                {
                    Log.Error("GetWareImages error", e);
                }
                return result;
            });
            return list;
        }

        public override byte[] GetWareImage(string imageId)
        {
            var key = MethodBase.GetCurrentMethod()?.Name + $"{imageId}";
            var list = HttpRuntime.Cache.Get(key, GetWareImageLock, () =>
            {
                byte[] result = new byte[0];
                try
                {
                    result = HttpHelper.GetRequestByte(Core.ConfigHelper.WareImage + imageId);
                }
                catch (Exception e)
                {
                    Log.Error("GetWareImages error", e);
                }
                return result;
            });
            return list;
        }

    }
}
