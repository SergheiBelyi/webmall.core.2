using System;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
using log4net.Config;
using StackExchange.Profiling;
using Webmall.Laximo.Repositories;
using ViewRes;
using Webmall.Model;
using Webmall.Model.Entities;
using Webmall.Model.Entities.Catalog;
using Webmall.Model.Repositories.Abstract;
using Webmall.UI.Core;
using Webmall.UI.Core.Helpers;
using Webmall.UI.Models.Catalog;
using Webmall.UI.Models.Ware;
using Webmall.UI.ViewModel.Catalog;
using FilterOptions = Webmall.Model.Entities.FilterOptions;
using Ware = ValmiStore.Model.Entities.Ware;

namespace Webmall.UI.Areas.Test.Controllers
{
    public class Catalog2Controller : Controller
    {
        #region Logger

        private static readonly ILog Log = LogManager.GetLogger(typeof(Catalog2Controller));

        static Catalog2Controller()
        {
            XmlConfigurator.Configure();
        }

        #endregion

        private readonly ICatalogRepository _repository;

        public Catalog2Controller(ICatalogRepository repository)
        {
            _repository = repository;
        }

        // GET: Test/Catalog
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Вход для ЧПУ
        /// </summary>
        /// <param name="filterOptions"></param>
        /// <param name="options"></param>
        /// <param name="autoOptions"></param>
        /// <param name="with">Переключатель активной закладки (для карточки товара)</param>
        /// <param name="groupId"></param>
        /// <param name="all">Переключатель показа всего каталога для групп с подгруппами (false или не установлено - показ только спец. предложений)</param>
        /// <returns></returns>
        public ActionResult ShowCatalog(FilterOptions filterOptions, GridViewOptions options, AutoDataFilterOptions autoOptions,
            string with, string groupId, bool? all)
        {
            var profiler = MiniProfiler.Current;
            using (profiler.Step("ShowCatalog action"))
            {
                if (autoOptions.MarkaId == -1)
                    autoOptions.Clear();

                //var currentGroup = repository.GetWaregroup(UserPreferences.CurrentCulture, null, trendObj.Id, group);
                var urlParts = (filterOptions.WareGroupId ?? "").Replace("@", "*").Split('/').Select(i => Helper.RestoreBadUrlSymbols(i)).ToArray();
                var currentGroup = Helper.GetItemInTreeByURL(_repository.GetWaregroups(UserPreferences.CurrentCulture), filterOptions.WareGroupId);
                if (currentGroup == null)
                {
                    if (urlParts.Length >= 2)
                    {
                        var brand = urlParts[urlParts.Length - 2];
                        var number = urlParts[urlParts.Length - 1];
                        // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                        var ware = _repository.GetWare(UserPreferences.CurrentCulture, null, number.Replace('~', '/'), brand.Replace('_', ' '));

                        if (ware == null)
                            return new HttpNotFoundResult();

                        var sw = new Stopwatch();
                        sw.Stop();

                        if (ware != null)
                        {
                            var wareModel = new WareModel { Ware = ware };
                            sw.Start();
                            //return WareIndex(id, with, options.SortColumn, options.SortDirection, modif, groupId);
                            //return PrepareWareCardView(wareModel, autoOptions.modif, groupId, sw);
                            return View("Ware");
                        }
                    }
                    return RedirectToAction("Index", "Home"); //View("ShowGroup");
                }

                CatalogViewModel model = new CatalogViewModel();
                //var isAutoFilter = ConfigHelper.HasGroupAutoFilter(currentGroup.Id ?? "0", SessionHelper.IsGross);
                //if (isAutoFilter && !(SessionHelper.IsGross && autoOptions.markaId == null))
                //{
                //    if (!autoOptions.markaId.HasValue && !autoOptions.modelId.HasValue && !autoOptions.modif.HasValue)
                //    {
                //        SelectionByAutoController.ParseAutoMarkCookie(out int? autoMark, out int? autoModel, out int? autoModif);
                //        autoOptions.markaId = autoMark;
                //        autoOptions.modelId = autoModel;
                //        autoOptions.modif = autoModif;
                //    }
                //    CommonHelpers.AutoSelectionToCookie(autoOptions.markaId, autoOptions.modelId, autoOptions.modif);

                //}

                //if (currentGroup.IsBrand)
                //{
                //    filterOptions.Producers = new[] { currentGroup.BrandId };
                //    model = PrepareGroupModel(filterOptions, options, currentGroup.Parent, currentGroup, all ?? false, isAutoFilter, autoOptions.modif);
                //}
                //else
                //{
                //    model = PrepareGroupModel(filterOptions, options, currentGroup, null, all ?? currentGroup.URL == ConfigHelper.TiresGroup, isAutoFilter, autoOptions.modif);
                //}

                //if (model == null)
                //    return RedirectToAction("Index", "Home");

                //if (model.WaresCatalog.Wares.List.Count == 1 && ConfigHelper.AllowSingleWareRedirect)
                //{
                //    var item = model.WaresCatalog.Wares.List.First();
                //    if (!string.IsNullOrEmpty(item.ProducerName) && !string.IsNullOrEmpty(item.WareNum))
                //    {
                //        var currentParentLink = UserPreferences.CurrentCultureLink + "/";
                //        var modelParameterUrlPart = (model.WaresCatalog.ModifId != null ? "modif=" + model.WaresCatalog.ModifId : "");
                //        modelParameterUrlPart += (model.WaresCatalog.GroupId != null ? "&groupId=" + model.WaresCatalog.GroupId : "");
                //        modelParameterUrlPart += (model.WaresCatalog.NeedReturnURL ? (string.IsNullOrEmpty(modelParameterUrlPart) ? "" : "&") + "returnUrl=" + Request.Url : "");
                //        modelParameterUrlPart = (string.IsNullOrEmpty(modelParameterUrlPart) ? "" : "?") + modelParameterUrlPart;
                //        var url = Url.Content("~/" + currentParentLink + item.URL) + modelParameterUrlPart;
                //        return Redirect(url);
                //    }
                //}

                ////model.Title = currentGroup.PageHeader;
                //ViewBag.CatalogModel = model;
                //ViewBag.CurrentGroupId = currentGroup.Id;

                //if (currentGroup.HasSubGroups)
                //{
                //    // Логика для расшифровки подуровня
                //    ViewBag.GroupList = currentGroup.SubGroup;
                //}
                //else
                //{
                //    // Логика для расшифровки текущего уровня
                //    ViewBag.GroupList = (currentGroup.Parent != null)
                //        ? currentGroup.Parent.SubGroup
                //        : GetTopWaregroups();
                //}
                //model.WaresCatalog.Groups = new List<Group>();
                //while (currentGroup?.Id != null)
                //{
                //    model.WaresCatalog.Groups.Insert(0, currentGroup);
                //    currentGroup = currentGroup.Parent;
                //}

                //if (!isAutoFilter) return View("IndexNew", model);


                //model.SelectionByAutoMarkModel = _referenceRepository.GetSelectionAutoMarkModel(
                //    autoOptions.markaId,
                //    autoOptions.modelId,
                //    autoOptions.modif,
                //    null);
                //model.WaresCatalog.MarkaId = autoOptions.markaId;
                //model.WaresCatalog.ModelId = autoOptions.modelId;
                //model.WaresCatalog.ModifId = autoOptions.modif;
                //model.WaresCatalog.IsAutoFilter = true;
                //ViewBag.WaresCatalog = model.WaresCatalog;

                return View("Index", model);
            }
        }


        public ActionResult WareCard(string producer, string name)
        {
            var model = new Ware();
            return View(model);
        }

        public ActionResult Search(FilterOptions filterOptions, GridViewOptions options)
        {
            var profiler = MiniProfiler.Current;
            var searchString = filterOptions.Search;
            using (profiler.Step("Search action"))
            {
                try
                {
                    var sw = new Stopwatch();
                    sw.Start();

                    var result = CheckVINSearch(searchString);
                    if (result != null)
                        return result;

                    var pageOptions = new PageOptions
                    {
                        PageSize = options.PageSize,
                        PageNumber = options.Skip,
                        OrderColumn = options.SortColumn,
                        Direction = options.SortDirection
                    };
                    var currentCulture = UserPreferences.CurrentCulture;
                    var searchResult = _repository.GetWareList(currentCulture, filterOptions, pageOptions, false);

                    foreach (var item in searchResult.Wares)
                    {
                        item.Url = Url.Action("WareCard",
                            new {producer = item.ProducerName, article = item.WareNumber});
                    }

                    var waresGridModel = searchResult.Wares.AsGridView(ControllerContext, options, searchResult.CountAllProduct);

                    var groups = _repository.GetWaregroupsList(currentCulture).Where(i=>searchResult.ProductGroupIdentifiers.Contains(i.Id)).ToList();
                    var producers = _repository.GetProducers().Where(i => searchResult.ManufacturerIdentifiers.Contains(i.Id)).ToList();
                    producers.AddRange(searchResult.ManufacturerIdentifiers.Where(i=>producers.All(p=>p.Id != i))
                                        .Select(i=>new Producer { Id = i, Name = i}));

                    var model = new CatalogViewModel
                    {
                        WaresCatalog = new CatalogWaresModel { Wares = waresGridModel },
                        CatalogFilterViewModel = CatalogFilterViewModel.Create<CatalogFilterViewModel>(filterOptions, null, producers, null),
                        //CatalogPropertiesModel = new CatalogPropertiesModel
                        //{
                        //    FilterOptions = filterOptions, 
                        //    FilterModel = FilterModel.Create(filterOptions, groups, producers, null)
                        //}
                    };

                    return View(model);
                }
                catch (Exception e)
                {
                    Log.Error(e);
                    TempData["Message"] = SharedResources.ErrorMessage;
                    return RedirectToAction("Show", "Message");
                }
            }
        }

        private ActionResult CheckVINSearch(string searchString)
        {
            // Проверка на VIN 
            if (searchString?.Length == 17 && searchString.ValidateVin())
            {
                try
                {
                    // если да, пробуем искать по VIN
                    ILaximoRepository laximoRepository =
                        (ILaximoRepository) DependencyResolver.Current.GetService(typeof(ILaximoRepository));
                    var vehicles = laximoRepository.FindVehicleByVIN(UserPreferences.CurrentCultureUnderScore,
                        null, searchString, null, true);
                    if (vehicles.Any())
                    {
                        Log.DebugFormat("Redirect to search VIN: {0}", searchString);
                        return RedirectToAction("VinSearch", "Lxm", new {vin = searchString});
                    }
                }
                catch (Exception e)
                {
                    Log.DebugFormat("Bad attempt to search VIN: {0} (Exc: {1})", searchString, e.Message);
                }
            }

            return null;
        }

        public static CatalogWaresModel PrepareCatalogWareModel(CatalogWaresModel model, string sview)
        {
            model.SortList = new[]
                                    {
                                        new SelectListItem {Value = "", Text = SharedResources.Presence, Selected = string.IsNullOrEmpty(model.Wares.SortColumn)},
                                        new SelectListItem {Value = "Name", Text = SharedResources.Name, Selected = model.Wares.SortColumn == "Name"},
                                        new SelectListItem {Value = "ClientPrice", Text = SharedResources.Price, Selected = model.Wares.SortColumn == "ClientPrice"},
                                        new SelectListItem {Value = "ProducerName", Text = SharedResources.Brand, Selected = model.Wares.SortColumn == "ProducerName"}
                                    };
            model.ViewMode = SessionHelper.IsGross ? 0 : 1;
            if (ConfigHelper.AllowSaveViewMode)
            {
                model.ViewMode = SessionHelper.CurrentView;
            }
            //var sview = Request.QueryString["view"];
            if (!string.IsNullOrEmpty(sview))
            {
                if (int.TryParse(sview, out var view))
                {
                    SessionHelper.CurrentView = model.ViewMode = view;
                }
            }
            //model.AllowCustomOrders = SessionHelper.AllowCustomOrders;
            //model.CanAddToCart = CanAddToCart;
            //model.ShowRetailPrice = SessionHelper.ShowRetailPrice;
            //model.BrandPreliminarySelection = ConfigHelper.AllowBrandPreliminarySelection;

            // Простановка признака наличия товара в корзине
            //if (SessionHelper.Cart != null)
            //{
            //    foreach (var item in model.Wares.List.Where(i => SessionHelper.Cart.Any(c => c.WareId == i.Id)))
            //    {
            //        var inCartQnt = SessionHelper.Cart.Where(c => c.WareId == item.Id).Sum(i => i.WareQnt);
            //        //item.InCart = (int)(inCartQnt ?? 0);
            //        //WareListHelper.FillOffersCartQnt(item, SessionHelper.Cart);
            //    }
            //}

            return model;
        }



        //    public ActionResult Search(string searchString, GridViewOptions options, bool? partialSearch, int? searchModifId, string searchGroupId, string searchCaption, bool? onlyWithPrice, bool? accurateSearch,
        //SearchType? searchType, FilterOptions filterOptions)
        //    {
        //        var profiler = MiniProfiler.Current;
        //        searchString = searchString?.Trim() ?? "";
        //        using (profiler.Step("Search action"))
        //        {
        //            try
        //            {
        //                var sw = new Stopwatch();
        //                sw.Start();

        //                // Проверка на VIN 
        //                if (searchString.Length == 17 && searchString.ValidateVin())
        //                {
        //                    try
        //                    {
        //                        // если да, пробуем искать по VIN
        //                        ILaximoRepository laximoRepository = (ILaximoRepository)DependencyResolver.Current.GetService(typeof(ILaximoRepository));
        //                        var vehicles = laximoRepository.FindVehicleByVIN(UserPreferences.CurrentCultureUnderScore, null, searchString, null, true);
        //                        if (vehicles.Any())
        //                        {
        //                            Log.DebugFormat("Redirect to search VIN: {0}", searchString);
        //                            return RedirectToAction("VinSearch", "Lxm", new { vin = searchString });
        //                        }
        //                    }
        //                    catch (Exception e)
        //                    {
        //                        Log.DebugFormat("Bad attempt to search VIN: {0} (Exc: {1})", searchString, e.Message);
        //                    }
        //                }

        //                ViewBag.SearchString = searchString;

        //                //if (!searchType.HasValue)
        //                //    searchType = SearchType.Number;
        //                var innerSearchType = searchType ?? SearchType.Number;


        //                if (options == null)
        //                    options = new GridViewOptions();
        //                options.CurrentContent = GridViewOptions.CatalogContent;
        //                var skip = options.Skip;
        //                var take = options.PageSize;

        //                var model = new WaresCatalogModel { IsSearchResult = true };

        //                if (filterOptions == null)
        //                    filterOptions = new FilterOptions();
        //                if (options.BrandFilter != null)
        //                    filterOptions.Producers = options.BrandFilter.Split(",");

        //                searchString = SetSearchType(searchString, innerSearchType, filterOptions);

        //                //var fullBrandList = new List<SelectListItem>();

        //                model.BrandList = new List<SelectListItem>();
        //                if (options.BrandFilter != null)
        //                    model.BrandList.Add(new SelectListItem { Value = options.BrandFilter });
        //                if (partialSearch != true)
        //                {
        //                    searchGroupId = null;
        //                    searchCaption = null;
        //                    searchModifId = null;
        //                }

        //                if (string.IsNullOrEmpty(filterOptions.WareGroupId))
        //                    filterOptions.Group = filterOptions.Groups?.FirstOrDefault();

        //                var wareList = _repository.GetWareList(UserPreferences.CurrentCulture, filterOptions.Group,
        //                    SessionHelper.CurrentClientId,
        //                    SessionHelper.CurrentWarehouseId,
        //                    SessionHelper.CurrentWarehouseName,
        //                    filterOptions, null, searchModifId, searchString, (int)innerSearchType, null,
        //                    options.SortColumn, options.SortDirection, skip, take, out _, model.BrandList,
        //                    Request.IsSearchBot());
        //                if (wareList.Count == 0 && wareList.TotalFound > 0)
        //                {
        //                    options.CurrentPage = 1;
        //                    skip = 0;
        //                    wareList = _repository.GetWareList(UserPreferences.CurrentCulture, filterOptions.Group,
        //                                            SessionHelper.CurrentClientId,
        //                                            SessionHelper.CurrentWarehouseId,
        //                                            SessionHelper.CurrentWarehouseName,
        //                                            filterOptions, null, searchModifId, searchString, (int)innerSearchType, null,
        //                                            options.SortColumn, options.SortDirection, skip, take, out _, model.BrandList,
        //                                            Request.IsSearchBot());
        //                }
        //                if (searchType == null && wareList.TotalFound == 0)
        //                {
        //                    // повторяем поиск для строки
        //                    innerSearchType = SearchType.Name;
        //                    searchString = SetSearchType(searchString, innerSearchType, filterOptions);

        //                    wareList = _repository.GetWareList(UserPreferences.CurrentCulture, searchGroupId,
        //                        SessionHelper.CurrentClientId,
        //                        SessionHelper.CurrentWarehouseId,
        //                        SessionHelper.CurrentWarehouseName,
        //                        filterOptions, null, searchModifId, searchString, (int)innerSearchType, null,
        //                        options.SortColumn, options.SortDirection, skip, take, out _, model.BrandList,
        //                        Request.IsSearchBot());

        //                    if (wareList.Count == 0 && wareList.TotalFound > 0)
        //                    {
        //                        options.CurrentPage = 1;
        //                        skip = 0;
        //                        wareList = _repository.GetWareList(UserPreferences.CurrentCulture, searchGroupId,
        //                                                    SessionHelper.CurrentClientId,
        //                                                    SessionHelper.CurrentWarehouseId,
        //                                                    SessionHelper.CurrentWarehouseName,
        //                                                    filterOptions, null, searchModifId, searchString, (int)innerSearchType, null,
        //                                                    options.SortColumn, options.SortDirection, skip, take, out _, model.BrandList,
        //                                                    Request.IsSearchBot());
        //                    }
        //                }

        //                model.Wares = wareList.AsGridView(ControllerContext, options, wareList.TotalFound);

        //                filterOptions.Brands = wareList.BrandList?.Select(i => new Producer { Id = i.Value, Name = i.Text, ShortName = i.Text }).ToList();
        //                model.Groups = filterOptions.Categories = wareList.GroupList.Select(i => new Group { Id = i.Value, Name = i.Text }).ToList();

        //                if (filterOptions.Producers?.Length == 1)
        //                {
        //                    foreach (var ware in wareList)
        //                    {
        //                        ware.LoadAnalogues =
        //                            (String.Compare(ware.WareNum, searchString, StringComparison.OrdinalIgnoreCase) == 0)
        //                            && filterOptions.Brands.Any(i => i.Id == filterOptions.Producers[0] && i.Name == ware.ProducerName);
        //                    }
        //                }

        //                // Вынос совпадающих номеров на первое место в результатх поиска
        //                if (!string.IsNullOrEmpty(searchString))
        //                {
        //                    var accSearchResult = model.Wares.List.Where(i =>
        //                            string.Compare(i.WareNum, searchString, StringComparison.OrdinalIgnoreCase) == 0
        //                            || string.Compare(i.WareNumNorm, searchString, StringComparison.OrdinalIgnoreCase) == 0
        //                            )
        //                        .ToList();
        //                    foreach (var item in accSearchResult)
        //                    {
        //                        model.Wares.List.Remove(item);
        //                        model.Wares.List.Insert(0, item);
        //                    }
        //                }

        //                sw.Stop();
        //                Log.DebugFormat("(Request: {1}) SearchControllerIndex: DB: {0:d} ms", sw.ElapsedMilliseconds, System.Web.HttpContext.Current.Request.GetHashCode());
        //                HttpContext.Items[SessionHelper.DB_TIME] = sw.Elapsed;
        //                sw.Start();
        //                if (model.Wares.List.Count == 1 && ConfigHelper.AllowBrandPreliminarySelection)
        //                {
        //                    var currentParentLink = UserPreferences.CurrentCultureLink + "/";
        //                    var url = Url.Content("~/" + currentParentLink + model.Wares.List.First().URL + $"?searchString={searchString.Trim("%")}");
        //                    return Redirect(url);
        //                }

        //                //if (!model.Wares.List.Any())
        //                //    _userRepository.DemandRequest(SessionHelper.CurrentUser, Request, DemandRequestTypes.Search, null, $"{searchString}");
        //                ViewBag.SearchCaption = searchCaption;
        //                ViewBag.SearchModifId = searchModifId;
        //                ViewBag.SearchGroupId = searchGroupId;
        //                // Формируем вид с деревом модификации
        //                if (searchModifId.HasValue)
        //                {
        //                    var searchModifModel = new CatalogModel
        //                    {
        //                        WaresCatalog = new WaresCatalogModel { ModifId = searchModifId, GroupId = null },
        //                        CatalogPropertiesModel = GetCatalogPropertiesModel("0", _repository, searchModifId, false)
        //                    };

        //                    searchModifModel.CatalogPropertiesModel.ModifId = searchModifId;
        //                    searchModifModel.CatalogPropertiesModel.GroupId = "0"; //searchGroupId.HasValue ? searchGroupId.Value : 0;
        //                    searchModifModel.CatalogPropertiesModel.WareGroupId = "0"; // wareGroupId;
        //                    searchModifModel.SelectedProducersIDs = null;
        //                    var autodata = _repository.GetAutoDataByModif(searchModifId.Value, UserPreferences.CurrentCulture);
        //                    searchModifModel.AutoModification = autodata;
        //                    searchModifModel.WaresCatalog.Wares = model.Wares;

        //                    sw.Stop();
        //                    Log.DebugFormat(@"(Request: {1}) SearchControllerIndex: Total time {0:d}", sw.ElapsedMilliseconds, System.Web.HttpContext.Current.Request.GetHashCode());
        //                    return View("IndexNew", searchModifModel);

        //                }
        //                PrepareWaresCatalogModel(model, Request.QueryString["view"]);
        //                sw.Stop();

        //                Log.DebugFormat(@"(Request: {1}) SearchControllerIndex: Total time {0:d}", sw.ElapsedMilliseconds, System.Web.HttpContext.Current.Request.GetHashCode());

        //                var searchModel = new SearchModel { WaresCatalog = model, CatalogPropertiesModel = new CatalogPropertiesModel { FilterOptions = filterOptions } };
        //                return View("Search", searchModel);
        //            }
        //            catch (Exception e)
        //            {
        //                Log.Error(e);
        //                TempData["Message"] = SharedResources.ErrorMessage;
        //                return RedirectToAction("Show", "Message");
        //            }
        //        }
        //    }

        private string SetSearchType(string searchString, SearchType searchType, FilterOptions filterOptions)
        {
            if (searchType == SearchType.Name)
            {
                searchString = "%" + searchString + "%";
            }

            ViewBag.SearchType = searchType;
            filterOptions.Search = searchString;
            filterOptions.SearchCriteria = (int)searchType;

            Response.Cookies.Add(new HttpCookie(CookieNames.SearchType, searchType.ToString()));
            return searchString;
        }

        public ActionResult Brands(string groupId)
        {
            var localeId = UserPreferences.CurrentCulture;

            var testGetGroupProducers = _repository.GetGroupProducers(groupId);

            return View();
        }
    }
}