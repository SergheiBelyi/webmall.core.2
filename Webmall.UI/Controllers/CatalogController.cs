using System;
using System.Collections.Generic;
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
using Webmall.UI.Core.HtmlHelpers;
using Webmall.UI.Models.Catalog;
using Webmall.UI.ViewModel.Catalog;
using Webmall.UI.ViewModel;

namespace Webmall.UI.Controllers
{
    public class CatalogController : Controller
    {
        #region Logger

        private static readonly ILog Log = LogManager.GetLogger(typeof(CatalogController));

        static CatalogController()
        {
            XmlConfigurator.Configure();
        }

        #endregion

        private readonly ICatalogRepository _repository;

        public CatalogController(ICatalogRepository repository)
        {
            _repository = repository;
        }

        // GET: Test/Catalog
        //public ActionResult Index()
        //{
        //    return View();
        //}

        /*[ChildActionOnly]
[OutputCache(Duration = 60 * 10)]*/
        public ActionResult GroupMenu(string culture)
        {
            return View("Components/CatalogNav", GetTopWaregroups());
        }

        public ActionResult GroupMenuMobile(string culture)
        {
            return View("Components/CatalogNavMobile", GetTopWaregroups());
        }

        /// <summary>
        /// Вход для ЧПУ
        /// </summary>
        /// <param name="filterOptions"></param>
        /// <param name="options"></param>
        /// <param name="autoOptions"></param>
        /// <param name="with">Переключатель активной закладки (для карточки товара)</param>
        /// <param name="path">Общая часть URL для парсинга</param>
        /// <returns></returns>
        public ActionResult ShowCatalog(FilterOptions filterOptions, GridViewOptions options, AutoDataFilterOptions autoOptions, string with, string path)
        {
            var profiler = MiniProfiler.Current;
            using (profiler.Step("ShowCatalog action"))
            {
                if (autoOptions.MarkaId == -1)
                    autoOptions.Clear();

                var groups = _repository.GetWaregroupsList(UserPreferences.CurrentCulture);
                var currentGroup = groups.FirstOrDefault(i => i.Url == path);
                if (currentGroup != null)
                {
                    return currentGroup.Children?.Any() == true 
                        ? WareGroupsList(currentGroup, groups) 
                        : WaresListForGroup (currentGroup, groups, filterOptions, options, autoOptions) ;
                }
                var urlParts = (path ?? "").Replace("@", "*").Split('/').Select(Helper.RestoreBadUrlSymbols).ToArray();
                if (urlParts.Length >= 2)
                {
                    var brand = urlParts[urlParts.Length - 2];
                    var number = urlParts[urlParts.Length - 1];
                    return WareCard(brand, number, filterOptions);
                    // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                }
                return WareGroupsList(null, groups);
            }
        }

        private ActionResult WaresListForGroup(Group currentGroup, List<Group> groups, FilterOptions filterOptions, GridViewOptions options, AutoDataFilterOptions autoOptions)
        {
            var currentCulture = UserPreferences.CurrentCulture;
            var profiler = MiniProfiler.Current;
            using (profiler.Step("WaresListForGroup action"))
            {
                try
                {
                    var sw = new Stopwatch();
                    sw.Start();

                    var pageOptions = new PageOptions
                    {
                        PageSize = options.PageSize,
                        PageNumber = options.CurrentPage ?? 1,
                        OrderColumn = options.SortColumn,
                        Direction = options.SortDirection
                    };

                    filterOptions.WareGroupId = currentGroup.Id;
                    var searchResult = _repository.GetWareList(currentCulture, filterOptions, pageOptions, false);

                    ProcessWareList(searchResult);

                    var waresGridModel = searchResult.Wares.AsGridView(ControllerContext, options, searchResult.CountAllProduct);

                    var producers = _repository.GetProducers().Where(i => _repository.GetGroupProducers(currentGroup.Id).Contains(i.Id)).ToList();
                    //producers.AddRange(searchResult.ManufacturerIdentifiers.Where(i => producers.All(p => p.Id != i))
                    //    .Select(i => new Producer { Id = i, Name = i }));

                    var properties = _repository.GetGroupProperties(currentCulture, currentGroup.Id);
                    var sview = Request.QueryString["view"];
                    if (!string.IsNullOrEmpty(sview))
                    {
                        if (int.TryParse(sview, out var view))
                        {
                            SessionHelper.CurrentView = view;
                        }
                    }

                    var model = new CatalogViewModel
                    {
                        WaresCatalog = new CatalogWaresModel { Wares = waresGridModel },
                        CatalogFilterViewModel = CatalogFilterViewModel.Create<CatalogFilterViewModel>(filterOptions, null, producers, properties),
                        //CatalogPropertiesModel = new CatalogPropertiesModel
                        //{
                        //    FilterOptions = filterOptions,
                        //    FilterModel = FilterModel.Create(filterOptions, null, producers, properties)
                        //},
                        ViewMode = SessionHelper.CurrentView,
                        BreadCrumbs = GetBreadCrumbsCatalog(currentGroup.Id)
                    };

                    ViewBag.CatalogTitle = currentGroup.Name;
                    ViewBag.ViewMode = model.ViewMode;
                    return View("WaresListForGroup", model);
                }
                catch (Exception e)
                {
                    Log.Error(e);
                    TempData["Message"] = SharedResources.ErrorMessage;
                    return RedirectToAction("Show", "Message");
                }
            }
        }

        private List<BreadCrumbsModel> GetBreadCrumbsCatalog(string catalogId)
        {
            if (catalogId == null) return new List<BreadCrumbsModel>();
            var breadCrumbs = new List<BreadCrumbsModel>();
            var waregroups = _repository.GetWaregroupsList(UserPreferences.CurrentCulture);
            var url = waregroups.FirstOrDefault(i => i.Id == catalogId)?.Url;
            if (url == null)
                return new List<BreadCrumbsModel>();
            string[] parentList = { url };
            if (url.Contains("/"))
            {
                parentList = url.Split('/');
            }
            foreach (var item in parentList)
            {
                var group = waregroups.FirstOrDefault(i => i.Id == item);
                if (group != null)
                    breadCrumbs.Add(new BreadCrumbsModel { Name = group.Name, Url = "/" + UserPreferences.CurrentCultureLink + "catalog/" + group.Url });
            }
            return breadCrumbs;
        }

        public ActionResult WareGroupsList(Group group, List<Group> groups = null)
        {
            if (groups == null)
                _repository.GetWaregroupsList(UserPreferences.CurrentCulture);
            var groupParentId = group?.ParentId;
            var currentGroupId = group?.Id;
            var groupModel = new GroupsListViewModel
            {
                Title = group?.Title ?? group?.Name ?? SharedResources.SelectByGroups,
                CurrentLevel = groups?.Where(i=> i.ParentId == groupParentId).ToList(),
                SubGroups = groups?.Where(i => i.ParentId == currentGroupId).ToList(),
                BreadCrumbs = GetBreadCrumbsCatalog(group?.Id)
            };
            //return WareIndex(id, with, options.SortColumn, options.SortDirection, modif, groupId);
            //return PrepareWareCardView(wareModel, autoOptions.modif, groupId, sw);
            return View("WareGroups", groupModel);


        }

        public ActionResult WareCard(string producer, string article, FilterOptions filterOptions)
        {
            var sw = new Stopwatch();
            sw.Start();
            var ware = _repository.GetWare(UserPreferences.CurrentCulture, null, article.Replace('~', '/'), producer.Replace('_', ' '));
            sw.Stop();

            var wareModel = new WareCardViewModel {
                Ware = ware,
                BreadCrumbs = GetBreadCrumbsCatalog(ware.GroupId),
            };
            wareModel.BreadCrumbs.Add(new BreadCrumbsModel { Name = ware.Name, Url = "" });
            wareModel.FilterOptions = filterOptions;
            //wareModel.CatalogPropertiesModel.FilterModel = new FilterModel
            //{
            //    ShowSearchFilter = false,
            //    PriceMax = 10000,
            //    ShowPriceFilter = true,
            //    Brands = _repository.GetProducers().Where(i => _repository.GetGroupProducers(ware.GroupId).Contains(i.Id)).ToList()
            //};

            //return WareIndex(id, with, options.SortColumn, options.SortDirection, modif, groupId);
            //return PrepareWareCardView(wareModel, autoOptions.modif, groupId, sw);
            return View("WareCard", wareModel);
        }

        [HttpGet]
        public ActionResult SearchOem(string oem)
        {
            return RedirectToAction("Search", new { Search = oem });
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

                    var result = CheckVinSearch(searchString);
                    if (result != null)
                        return result;

                    var pageOptions = new PageOptions
                    {
                        PageSize = options.PageSize,
                        PageNumber = options.CurrentPage ?? 1,
                        OrderColumn = options.SortColumn,
                        Direction = options.SortDirection
                    };
                    var currentCulture = UserPreferences.CurrentCulture;
                    var searchResult = _repository.GetWareList(currentCulture, filterOptions, pageOptions, false);

                    ProcessWareList(searchResult);

                    var waresGridModel = searchResult.Wares.AsGridView(ControllerContext, options, searchResult.CountAllProduct);

                    var groups = _repository.GetWaregroupsList(currentCulture).Where(i => searchResult.ProductGroupIdentifiers.Contains(i.Id)).ToList();
                    var producers = _repository.GetProducers().Where(i => searchResult.ManufacturerIdentifiers.Contains(i.Id)).ToList();
                    sw.Stop();

                    // Добавление производителей, которых нет в PA, но есть в сторонних API
                    producers.AddRange(searchResult.ManufacturerIdentifiers.Where(i => producers.All(p => p.Id != i))
                        .Select(i => new Producer { Id = i, Name = i }));

                    var sview = Request.QueryString["view"];
                    if (!string.IsNullOrEmpty(sview))
                    {
                        if (int.TryParse(sview, out var view))
                        {
                            SessionHelper.CurrentView = view;
                        }
                    }

                    var model = new CatalogViewModel
                    {
                        WaresCatalog = new CatalogWaresModel { Wares = waresGridModel },
                        CatalogFilterViewModel = CatalogFilterViewModel.Create<CatalogFilterViewModel>(filterOptions, null, producers, null),
                        //CatalogPropertiesModel = new CatalogPropertiesModel
                        //{
                        //    //Categories = groups,
                        //    //WareProducers = producers,
                        //    FilterOptions = filterOptions,
                        //    FilterModel = FilterModel.Create(filterOptions, groups, producers, null)
                        //},
                        ViewMode = SessionHelper.CurrentView,
                        BreadCrumbs = new List<BreadCrumbsModel> { new BreadCrumbsModel { Name = SharedResources.Search, Url = "" } }
                    };

                    ViewBag.CatalogTitle = SharedResources.Search;
                    ViewBag.ViewMode = model.ViewMode;
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

        private void ProcessWareList(WareList searchResult)
        {
            var producers = _repository.GetProducers();
            foreach (var item in searchResult.Wares)
            {
                item.Url = Url.Ware(item);
                item.Producer = producers.FirstOrDefault(i => i.Id == item.ProducerId);
            }
        }

        private ActionResult CheckVinSearch(string searchString)
        {
            // Проверка на VIN 
            if (searchString?.Length == 17 && searchString.ValidateVin())
            {
                try
                {
                    // если да, пробуем искать по VIN
                    ILaximoRepository laximoRepository =
                        (ILaximoRepository)DependencyResolver.Current.GetService(typeof(ILaximoRepository));
                    var vehicles = laximoRepository.FindVehicleByVIN(UserPreferences.CurrentCultureUnderScore,
                        null, searchString, null, true);
                    if (vehicles.Any())
                    {
                        Log.DebugFormat("Redirect to search VIN: {0}", searchString);
                        return RedirectToAction("VinSearch", "Lxm", new { vin = searchString });
                    }
                }
                catch (Exception e)
                {
                    Log.DebugFormat("Bad attempt to search VIN: {0} (Exc: {1})", searchString, e.Message);
                }
            }

            return null;
        }

        //public static CatalogWaresModel PrepareCatalogWareModel(CatalogWaresModel model, string sview)
        //{
        //    model.SortList = new[]
        //                            {
        //                                new SelectListItem {Value = "", Text = SharedResources.Presence, Selected = string.IsNullOrEmpty(model.Wares.SortColumn)},
        //                                new SelectListItem {Value = "Name", Text = SharedResources.Name, Selected = model.Wares.SortColumn == "Name"},
        //                                new SelectListItem {Value = "ClientPrice", Text = SharedResources.Price, Selected = model.Wares.SortColumn == "ClientPrice"},
        //                                new SelectListItem {Value = "ProducerName", Text = SharedResources.Brand, Selected = model.Wares.SortColumn == "ProducerName"}
        //                            };
        //    model.ViewMode = SessionHelper.IsGross ? 0 : 1;
        //    if (ConfigHelper.AllowSaveViewMode)
        //    {
        //        model.ViewMode = SessionHelper.CurrentView;
        //    }
        //    //var sview = Request.QueryString["view"];
        //    if (!string.IsNullOrEmpty(sview))
        //    {
        //        if (int.TryParse(sview, out var view))
        //        {
        //            SessionHelper.CurrentView = model.ViewMode = view;
        //        }
        //    }
        //    //model.AllowCustomOrders = SessionHelper.AllowCustomOrders;
        //    //model.CanAddToCart = CanAddToCart;
        //    //model.ShowRetailPrice = SessionHelper.ShowRetailPrice;
        //    //model.BrandPreliminarySelection = ConfigHelper.AllowBrandPreliminarySelection;

        //    // Простановка признака наличия товара в корзине
        //    //if (SessionHelper.Cart != null)
        //    //{
        //    //    foreach (var item in model.Wares.List.Where(i => SessionHelper.Cart.Any(c => c.WareId == i.Id)))
        //    //    {
        //    //        var inCartQnt = SessionHelper.Cart.Where(c => c.WareId == item.Id).Sum(i => i.WareQnt);
        //    //        //item.InCart = (int)(inCartQnt ?? 0);
        //    //        //WareListHelper.FillOffersCartQnt(item, SessionHelper.Cart);
        //    //    }
        //    //}

        //    return model;
        //}



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

        /// <summary>
        /// Возвращает список групп верхнего уровня
        /// </summary>
        /// <returns>Список групп</returns>
        private List<Group> GetTopWaregroups()
        {
            var model = _repository.GetWaregroups(UserPreferences.CurrentCulture);
            return model;
        }

        public ActionResult Brands(string groupId)
        {
            var localeId = UserPreferences.CurrentCulture;

            var testGetGroupProducers = _repository.GetGroupProducers(groupId);

            return View();
        }
    }
}