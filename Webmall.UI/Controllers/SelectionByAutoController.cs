using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using log4net;
using log4net.Config;
using StackExchange.Profiling;
using Webmall.Laximo.Repositories;
using ValmiStore.Model.Entities.Configuration.Features;
using ValmiStore.Model.Entities.Meta;
using ViewRes;
using Webmall.Laximo.Entities;
using Webmall.Model;
using Webmall.Model.Abstract;
using Webmall.Model.Entities;
using Webmall.Model.Entities.Auto;
using Webmall.Model.Entities.Catalog;
using Webmall.Model.PriceAggregator.DataModels.AutoData;
using Webmall.Model.Repositories.Abstract;
using Webmall.UI.Core;
using Webmall.UI.Core.Attributes;
using Webmall.UI.Core.Helpers;
using Webmall.UI.Models.Catalog;
using Webmall.UI.Models.Laximo;
using Webmall.UI.Models.SelectionByAuto;
using Webmall.UI.Models.Ware;
using Webmall.UI.ViewModel.SelectionByAuto;
using AutoModel = Webmall.Model.Entities.Auto.AutoModel;

namespace Webmall.UI.Controllers
{
    public class SelectionByAutoController : Controller
    {
        // ReSharper disable once InconsistentNaming

        #region Logger

        private static readonly ILog Log = LogManager.GetLogger(typeof(SelectionByAutoController));

        static SelectionByAutoController()
        {
            XmlConfigurator.Configure();
        }

        #endregion

        public SelectionByAutoController(IAutoDataRepository autoDataRepository, ILaximoRepository lxmRepository)
        {
            _autoDataRepository = autoDataRepository;
            _lxmRepository = lxmRepository;
        }

        private readonly IAutoDataRepository _autoDataRepository;
        private readonly ILaximoRepository _lxmRepository;

        //[AcceptVerbs(HttpVerbs.Post)]
        //public ActionResult GetMarkModel(int? id)
        //{
        //    SelectListItem [] result = {};
        //    if (id.HasValue)
        //    {
        //        result = _repository.GetAutoModelList(UserPreferences.CurrentCulture, id.Value).Select(i => new SelectListItem { Text = i.Name, Value = i.Id.ToString() }).ToArray();
        //    }
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        //[AcceptVerbs(HttpVerbs.Post)]
        //public ActionResult GetModelListByMark(string markId)
        //{
        //    if (markId.HasValue)
        //    {
        //        var models = new List<AutoModel> { new AutoModel { Name = SharedResources.SelectViewModel } };
        //        models.AddRange(_autoDataRepository.GetModelsList(markId.Value));

        //        var result = models.Select(i => new
        //        {
        //            Id = i.Id.ToString(CultureInfo.InvariantCulture),
        //            i.Name,
        //            Start = i.DateBegin?.Year.ToString(CultureInfo.CurrentUICulture) ?? "",
        //            End = i.DateEnd?.Year.ToString(CultureInfo.CurrentUICulture) ?? ""
        //        }).ToArray();

        //        return Json(result, JsonRequestBehavior.AllowGet);
        //    }

        //    return Json(null, JsonRequestBehavior.AllowGet);
        //}

        [HttpGet]
        public ActionResult GetModelsList(string markId)
        {
            var models = new List<AutoModel> { new AutoModel { Name = SharedResources.SelectModel } };
            models.AddRange(_autoDataRepository.GetModelsList(UserPreferences.CurrentCulture, markId));

            var result = models.Select(i => new SelectListItem
            {
                Value = i.Id?.ToString(CultureInfo.InvariantCulture),
                Text = $"{i.Name} ({i.DateBegin?.Year.ToString(CultureInfo.CurrentUICulture) ?? ""} - {((i.DateEnd?.Year > 1900) ? i.DateEnd?.Year.ToString(CultureInfo.CurrentUICulture) : "")})"
            }).ToArray();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetModifListByModel(string modelId)
        {
            var modifs = new List<AutoModification> { new AutoModification { Name = SharedResources.SelectModification } };
            modifs.AddRange(_autoDataRepository.GetModifList(UserPreferences.CurrentCulture, modelId));

            var result = modifs.Select(i => new
            {
                Id = i.Id?.ToString(CultureInfo.InvariantCulture),
                i.Name,
                Start = i.DateBegin?.Year.ToString(CultureInfo.CurrentUICulture) ?? "",
                End = i.DateEnd?.Year.ToString(CultureInfo.CurrentUICulture) ?? "",
                PowerHp = i.PS,
                Volume = i.CcmTech,
                PowerKwt = i.KW
            }).ToArray();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetFuelTypes(string modelId)
        {
            var result = new List<SelectListItem>
            {
                new SelectListItem {Value = "", Text = @" - ", Selected = true},
            };
            var types = _autoDataRepository.GetFuelTypes(UserPreferences.CurrentCulture, modelId);
            result.AddRange(types);
            /*if (modelId.HasValue)
            {
                result = result
                    .Union(_catalogRepository.GetAutoModifList(UserPreferences.CurrentCulture, modelId.Value)
                        .Where(i => i.FuelTypeId != null).Select(i => i.FuelTypeId).Distinct()
                        .Select(i => new SelectListItem
                        {
                            Value = i.ToString(CultureInfo.InvariantCulture),
                            Text = types.Where(f => f.Value == i.ToString(CultureInfo.InvariantCulture)).Select(f => f.Text).FirstOrDefault()
                        }).Distinct()).ToList();
            }*/
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ModifList(string markId, string modelId, int? yearOfProduce, int? volume, int? volumePercent, int? fuelType, int? power, int? powerUnit, int? powerPercent)
        {
            if (string.IsNullOrEmpty(modelId))
                return Json(null, JsonRequestBehavior.AllowGet);

            CommonHelpers.AutoSelectionToCookie(markId, modelId, null);
            var model = _autoDataRepository.GetModifList(UserPreferences.CurrentCulture, modelId, yearOfProduce, volume,
                volumePercent, fuelType, power, powerUnit, powerPercent);
            return View(model);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Info(string modifId)
        {
            try
            {
                var model = _autoDataRepository.GetModifData(UserPreferences.CurrentCulture, modifId);
                return View(model);
                //return View();
            }
            catch (Exception e)
            {
                Log.Error(e);
                ViewData.Model = new HandleErrorInfo(e, "SelectionByAuto", "Info");
                return View("Error");
            }
        }

        public ActionResult Selection(string autoMark, string autoModel, string modif, bool forceSelection = false)
        {
            ViewBag.MarkaId = autoMark;
            ViewBag.ModelId = autoModel;

            if (string.IsNullOrEmpty(autoMark) && string.IsNullOrEmpty(autoModel) && string.IsNullOrEmpty(modif))
            {
                ParseAutoMarkCookie(out autoMark, out autoModel, out modif);
            }

            CommonHelpers.AutoSelectionToCookie(autoMark, autoModel, modif);
            //Если задана модификация - идем к списку товаров
            if (!string.IsNullOrEmpty(modif) && !(forceSelection || SessionHelper.IsGross))
                return RedirectToAction("WaresForModif", "Catalog", new { modif });

            if (!string.IsNullOrEmpty(autoMark))
            {
                /*var markMeta =
                    _catalogRepository.GetAutoMarkaList(UserPreferences.CurrentCulture).Where(i => i.Id == autoMark).Select(i => i.Meta).FirstOrDefault();
                if (markMeta != null)
                {
                    ViewBag.Title = markMeta.Title;
                    ViewData["Keywords"] = markMeta.Keywords;
                    ViewData["Description"] = markMeta.Description;

                    ViewBag.PageHeaderTitle = SharedResources.SelectionByAuto;
                }
                ViewBag.MarkaId = null;*/
            }

            var sw = new Stopwatch();
            var swContr = new Stopwatch();
            swContr.Start();
            var culture = UserPreferences.CurrentCulture;
            var model = new SelectionByAutoMarkModel
            {
                AutoMarkList = _autoDataRepository.GetMarksList(culture),
                AllowLaximoAutoSelection = ConfigHelper.AllowLaximoAutoSelection,
            };


            // _referenceRepository.GetSelectionAutoMarkModel(autoMark?.ToString(), autoModel?.ToString(), modif?.ToString(), sw);
            if (model.AllowLaximoAutoSelection)
            {
                model.LaximoCatalogList = _lxmRepository.CatalogsList(UserPreferences.CurrentCultureUnderScore).row
                    .Select(i => new KeyValuePair<string, string>(i.code, i.name)).ToList();
                model.LaximoCatalogList.Insert(0, new KeyValuePair<string, string>("", $"- {SharedResources.SelectMark} -"));
            }

            HttpContext.Items[SessionHelper.DB_TIME] = (HttpContext.Items[SessionHelper.DB_TIME] != null) ? ((TimeSpan)HttpContext.Items[SessionHelper.DB_TIME]) + sw.Elapsed : sw.Elapsed;
            swContr.Stop();
            Log.DebugFormat(@"(Request: {1}) SelectionByAutoMark.Filter: {0} ms", swContr.ElapsedMilliseconds, System.Web.HttpContext.Current.Request.GetHashCode());

            ViewBag.PageHeaderTitle = SharedResources.SelectionByAuto;
            return View("Selection", model);
        }


        public static void ParseAutoMarkCookie(out string autoMark, out string autoModel, out string modif)
        {
            autoMark = null;
            autoModel = null;
            modif = null;
            // Пробуем разобрать Cookie
            var httpCookie = CookieHelper.GetCookieValue(CommonHelpers.LASTAUTO_COOKIENAME);
            if (httpCookie != null)
            {
                var values = httpCookie.Split('|');
                autoMark = values[0];
                if (values.Length > 1) autoModel = values[1];
                if (values.Length > 2) autoModel = values[2];
                if (!ConfigHelper.AllowAutoAutoSelection)
                    modif = null;
            }
        }

        public ActionResult IndexByName(string markaName, string modelName, string modifName)
        {
            string markaId = null;
            string modelId = null;
            string modifId = null;
            if (!string.IsNullOrEmpty(markaName))
            {
                if (markaName != " ")
                {
                    markaName = markaName.ToUpper();
                    /*var marka = _catalogRepository.GetAutoMarkaList(UserPreferences.CurrentCulture).FirstOrDefault(i => i.UrlName == markaName);
                    if (marka != null)
                    {
                        modelName = (modelName ?? "").ToUpper();
                        markaId = marka.Id;
                        var model = _catalogRepository.GetAutoModelList(UserPreferences.CurrentCulture, marka.Id).FirstOrDefault(i => i.URLName == modelName);
                        if (model != null)
                        {
                            modelId = model.Id;
                        }
                    }*/
                }
            }
            else
            {
                ParseAutoMarkCookie(out markaId, out modelId, out modifId);
            }
            var httpCookie = CookieHelper.GetCookieValue(CommonHelpers.LASTAUTO_COOKIENAME);
            if (httpCookie != null) CommonHelpers.AutoSelectionToCookie(markaId, modelId, null);

            return string.IsNullOrEmpty(markaId)
                ? MarkList()
                : string.IsNullOrEmpty(modelId) ? ModelList(markaId)
                : string.IsNullOrEmpty(modifId) ? ModifListForView(markaId, modelId)
                : Selection(markaId, modelId, modifId);
        }

        //public ActionResult WaresForModif(string modif)
        //{
        //    return RedirectToAction("Search", "Catalog", new {ModifId = modif});
        //}



        public ActionResult WaresForModif(string modif, FilterOptions filterOptions, GridViewOptions options)
        {
            var profiler = MiniProfiler.Current;
            using (profiler.Step("WaresForModif action"))
            {
                if (modif == null) return RedirectToAction("Selection", "SelectionByAuto");

                var sw = new Stopwatch();
                var swContr = new Stopwatch();
                var swProp = new Stopwatch();
                swContr.Start();

                var currentCulture = UserPreferences.CurrentCulture;
                //var catalogInfo = _autoDataRepository.GetTecDocAssembliesTree(currentCulture, modif);

                var model = new AutoGroupsModel
                {

                    VehicleInfo = _autoDataRepository.GetModifData(currentCulture, modif),
                    Groups = _autoDataRepository.GetTecDocAssembliesTree(currentCulture, modif).Where(i=>i.ParentId == null)
                        .Select(i => (ICommonTreeComposite<Group>)new AutoGroupTree(i)).ToList(),
                };
                return View(model);
            }
        }

        public ActionResult AssemblyWares(string modifId, string assemblyId)
        {
            var currentCulture = UserPreferences.CurrentCulture;
            var groups = _autoDataRepository.GetTecDocAssembliesTree(currentCulture, modifId)
                .Where(i => i.ParentId == null)
                .Select(i => (ICommonTreeComposite<Group>) new AutoGroupTree(i)).ToList();
            var assembly = groups.Select(child => ((AutoGroupTree)child).Find(assemblyId)).FirstOrDefault(found => found != null);
            var items = _autoDataRepository.GetTecDocAssemblyWares(UserPreferences.CurrentCulture, modifId, assemblyId);
            var model = new AssemblyWaresViewModel
            {
                //WaresModel = new CatalogWaresModel
                //{
                //    Wares = items.AsGridView(ControllerContext, new GridViewOptions(), items.Count)
                //},
                Items = items,
                Assembly = assembly
            };
            return PartialView(model);
        }

        //public ActionResult LoadSubTreeByRoot(int root, int modif)
        //{
        //    var groups = _repository.GetTechDocWareGroups(UserPreferences.CurrentCulture, modif);
        //    var node = Helper.GetItemInTreeById(groups, root);
        //    var result = new List<object>();

        //    foreach (var nd in node.Children)
        //    {
        //        result.Add(new { text = nd.Name, id = nd.Id, hasChildren = nd.Children.Any(), url = (!nd.Children.Any()) ? Url.Action("Filter", new { modif, parentId = nd.ParentId, groupId = nd.Id, wareGroupId = nd.WareGroupId }) : null });
        //    }

        //    return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
        //}

        [Authorize]
        public JsonResult UpdateMark(int markaId, AutoMarkMetaInfo info)
        {
            info.MarkaId = markaId;
            //_catalogRepository.SaveAutoMarkMeta(info, UserPreferences.CurrentCulture);
            var jResult = new JsonResult
            {
                Data = info,
                JsonRequestBehavior = JsonRequestBehavior.DenyGet
            };
            return jResult;
        }

        public ActionResult TiresCalculator()
        {
            return View();
        }

        [FeatureFilter(typeof(CatalogFeatures), nameof(CatalogFeatures.TiresSelection))]
        public ActionResult TiresSelection(int? season)
        {
            /*var currentGroup = Helper.GetItemInTreeByURL(_catalogRepository.GetWaregroups(UserPreferences.CurrentCulture), ConfigHelper.TiresGroup);

            var groupId = currentGroup.URL;
            if (string.IsNullOrEmpty(currentGroup.Id))
                return Redirect("~");

            var model = new TiresSelectionModel
            {
                GroupId = groupId,
                Properties = CatalogController.GetCatalogPropertiesModel(currentGroup.Id, _catalogRepository, null, false),
                SeasonParameter = ConfigHelper.TiresSeasonParameterId,
                TypeParameter = ConfigHelper.TiresTypeParameterId,
                WidthParameter = ConfigHelper.TiresWidthParameterId,
                HeightParameter = ConfigHelper.TiresHeightParameterId,
                DiameterParameter = ConfigHelper.TiresDiameterParameterId,
                Season = season ?? 0,
                TiresCombinations = _referenceRepository.GetTiresCombinations(UserPreferences.CurrentCulture, currentGroup.Id,
                    ConfigHelper.TiresWidthParameterId, ConfigHelper.TiresHeightParameterId, ConfigHelper.TiresDiameterParameterId, ConfigHelper.TiresSeasonParameterId, ConfigHelper.TiresTypeParameterId)
            };

            if (season.HasValue)
            {
                var group = model.Properties.WareProperties.FirstOrDefault(i => i.Id == model.SeasonParameter.ToString());
                var item = group?.AvailableValues.Count > season.Value ? group.AvailableValues[season.Value] : null;
                ViewBag.SelectedProperties = new List<string>
                {
                    item?.Trim().ToHex() + CommonHelpers.PropertyDivider + group?.Name.Trim().ToHex()
                };
            }
            return View(model);*/
            return View();
        }
        private ActionResult MarkList()
        {
            /*var model = _catalogRepository.GetAutoMarkaList(UserPreferences.CurrentCulture);
            return View("MarkList", model);*/
            return View("MarkList");
        }

        private ActionResult ModelList(string markaId)
        {
            /*var model = new SelectionByAutoMarkModel
            {
                AutoMarkaObj =
                    _catalogRepository.GetAutoMarkaList(UserPreferences.CurrentCulture)
                        .FirstOrDefault(i => i.Id == markaId),
                AutoModelList = _catalogRepository.GetAutoModelList(UserPreferences.CurrentCulture, markaId),
            };*/

            /*ProcessMarkMeta(model.AutoMarkaObj.Meta);
            return View("ModelList", model);*/
            return View("MarkList");
        }

        private void ProcessMarkMeta(AutoMarkMetaInfo markMeta)
        {
            if (markMeta != null)
            {
                ViewBag.Title = markMeta.Title;
                ViewData["Keywords"] = markMeta.Keywords;
                ViewData["Description"] = markMeta.Description;
            }
        }

        private ActionResult ModifListForView(string markaId, string modelId)
        {
            /*var autoMarkaObj =
                _catalogRepository.GetAutoMarkaList(UserPreferences.CurrentCulture)
                    .FirstOrDefault(i => i.Id == markaId);
            if (autoMarkaObj != null) ProcessMarkMeta(autoMarkaObj.Meta);
            var model = _catalogRepository.GetAutoModifList(UserPreferences.CurrentCulture, modelId);
            return View("ModifListForView", model);*/
            return View("ModifListForView");
        }
    }
}
