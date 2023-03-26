using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using log4net;
using log4net.Config;
using Webmall.Laximo.Entities;
using Webmall.Laximo.Repositories;
using ViewRes;
using Webmall.Model;
using Webmall.Model.Abstract;
using Webmall.Model.Entities.User;
using Webmall.Model.Entities.VinSearch;
using Webmall.Model.Repositories.Abstract;
using Webmall.UI.Core;
using Webmall.UI.Core.Helpers;
using Webmall.UI.Core.Renderers;
using Webmall.UI.Models.Laximo;

namespace Webmall.UI.Controllers
{
    [Authorize]
    public class LxmController : Controller
    {
        #region Logger

        // ReSharper disable once UnusedMember.Local
        private static readonly ILog Log = LogManager.GetLogger(typeof(LxmController));

        static LxmController()
        {
            XmlConfigurator.Configure();
        }

        #endregion

        private readonly ILaximoRepository _laximoRepository;
        private readonly IUserRepository _userRepository;

        public LxmController(ILaximoRepository laximoRepository, IUserRepository userRepository)
        {
            _laximoRepository = laximoRepository;
            _userRepository = userRepository;
        }

        public ActionResult Index()
        {
            return View("VinSearch", CreateVehicleListModel(null, null));
        }

        public ActionResult VinSearch(string vin, string frame, BaseModel m)
        {
            var currentUser = SessionHelper.CurrentUser ?? new User
            {
                Id = 0,
                IP = Request.ServerVariables["REMOTE_ADDR"],
            };

            if (!(ConfigHelper.AllowLaximo && !(ConfigHelper.DenyLaximoRetail && !SessionHelper.IsGross)
                  && (string.IsNullOrEmpty(ConfigHelper.LaximoClientsRestrict) || !ConfigHelper.LaximoClientsRestrictList.Contains(SessionHelper.CurrentClientId ?? "-1"))))
            {
                return RedirectToAction("Index", "Home");
            }


            if (!string.IsNullOrEmpty(vin))
            {
                vin = vin.ToUpper();

                if (!vin.ValidateVin())
                {
                    TempData["Message"] = SharedResources.WrongVINCode;
                    return View(CreateVehicleListModel(vin, currentUser));
                }

                if (!string.IsNullOrEmpty(vin) && !_userRepository.CheckUserVinSearchLimit(currentUser, vin))
                {
                    TempData["Message"] = "Vin code limited";
                    return RedirectToAction("Show", "Message");
                }
            }
            else vin = frame?.ToUpper() ?? "";

            if (string.IsNullOrEmpty(vin))
            {
                //TempData["Message"] = SharedResources.WrongVINCode;
                return View(CreateVehicleListModel(vin, currentUser));
            }

            VehicleListModel model;
            try
            {
                if (!string.IsNullOrEmpty(m?.VehicleId))
                {
                    model = CreateVehicleListModel("", currentUser);
                    model.Vehicles = _laximoRepository.GetVehicleInfo(UserPreferences.CurrentCultureUnderScore,
                        m.CatalogId, m.VehicleId, m.Ssd);
                }
                else
                {
                    model = CreateVehicleListModel(vin, currentUser);
                }
            }
            catch (Exception e)
            {
                Log.Error($"vin: [{vin}]", e);
                _userRepository.AddUserVinSearch(new VinSearchHistoryItem { VIN = vin, IsSuccessful = false, UserId = currentUser?.Id, UserIP = currentUser?.IP});
                model = CreateVehicleListModel(null, currentUser);
                //throw;
            }
            if (model.Vehicles == null || !model.Vehicles.Any())
            {
                TempData["Message"] = SharedResources.VinCodeNotFound;
            }

            return View(model);
        }

        private VehicleListModel CreateVehicleListModel(string vin, User currentUser)
        {
            var model = new VehicleListModel();

            if (!string.IsNullOrEmpty(vin))
            {
                model.Vin = vin;
                model.Vehicles = vin.ValidateVin() ? _laximoRepository.FindVehicleByVIN(UserPreferences.CurrentCultureUnderScore, null, vin, null, true) : new List<VehicleInfo>();

                var result = model.Vehicles?.FirstOrDefault();
                if (vin.ValidateVin())
                {
                    _userRepository.AddUserVinSearch(
                        new VinSearchHistoryItem
                        {
                            VIN = vin,
                            IsSuccessful = result != null,
                            AutoName = $"{result?.Brand} {result?.Name} {result?.Modification}".Trim(),
                            UserId = currentUser?.Id,
                            UserIP = currentUser?.IP
                        });
                }
            }

            model.SearchHistory = _userRepository.GetVinSearchHistory(currentUser ?? SessionHelper.CurrentUser,
                new VinHistoryFilter { EndDate = DateTime.Now, StartDate = DateTime.Now.AddMonths(-1) });

            return model;

        }

        public ActionResult Categories(BaseModel m)
        {
            var model = new CategoriesModel
            {
                VehicleId = m.VehicleId,
                CatalogId = m.CatalogId,
                Ssd = m.Ssd,
                CategoryId = m.CategoryId ?? "-1",
                Type = m.Type,
                VehicleInfo = _laximoRepository.GetVehicleInfo(UserPreferences.CurrentCultureUnderScore, m.CatalogId, m.VehicleId, m.Ssd).FirstOrDefault(),
                CatalogInfo = _laximoRepository.GetCatalogInfo(UserPreferences.CurrentCultureUnderScore, m.CatalogId)
            };

            model.Categories =
                _laximoRepository.GetCategories(UserPreferences.CurrentCultureUnderScore, m.CatalogId, m.VehicleId, m.CategoryId, m.Ssd)
                    .Select(i => (ICommonTreeComposite<Category>)new CategoryTree(i))
                    .ToList();
            model.SelectedCategory = CommonRenderer.GetItemInTreeById(model.Categories, m.CategoryId) ?? model.Categories.FirstOrDefault();
            model.Units = _laximoRepository.ListUnits(UserPreferences.CurrentCultureUnderScore, m.CatalogId, m.VehicleId, m.CategoryId, model.SelectedCategory != null ? ((CategoryTree)model.SelectedCategory).Category.Ssd : m.Ssd);

            return View(model);
        }

        public ActionResult Groups(BaseModel m, string groupId)
        {
            var catalogInfo = _laximoRepository.GetCatalogInfo(UserPreferences.CurrentCultureUnderScore, m.CatalogId);
            if (catalogInfo == null || !catalogInfo.HasGroupSearch)
                return RedirectToAction("Categories", m);
            var model = new GroupsModel
            {
                VehicleId = m.VehicleId,
                CatalogId = m.CatalogId,
                Ssd = m.Ssd,
                CategoryId = m.CategoryId ?? "-1",
                Type = m.Type,
                VehicleInfo = _laximoRepository.GetVehicleInfo(UserPreferences.CurrentCultureUnderScore, m.CatalogId, m.VehicleId, m.Ssd).FirstOrDefault(),
                Groups = _laximoRepository.ListQuickGroup(UserPreferences.CurrentCultureUnderScore, m.CatalogId, m.VehicleId, m.Ssd)
                    .Select(i => (ICommonTreeComposite<QuickGroup>)new GroupTree(i))
                    .ToList(),
            };

            model.GroupList = model.GetListFromTree(null, model.Groups, "");

            model.SelectedGroup = model.Find(groupId, model.Groups);
            return View(model);
        }

        public ActionResult FilteredGroups(BaseModel m, string filter)
        {
            var list = _laximoRepository.ListQuickGroup(UserPreferences.CurrentCultureUnderScore, m.CatalogId, m.VehicleId, m.Ssd)
                    .Select(i => (ICommonTreeComposite<QuickGroup>)new GroupTree(i))
                    .ToList();
            var model = new GroupsModel
            {
                VehicleId = m.VehicleId,
                CatalogId = m.CatalogId,
                Ssd = m.Ssd,
                CategoryId = m.CategoryId ?? "-1",
                Type = m.Type,
                VehicleInfo = null,
                Groups = string.IsNullOrEmpty(filter) ? list : FilterGroups(list, filter),
            };
            
            model.SelectedGroup = null;
            return View("_filteredGroups", model);
        }

        private List<ICommonTreeComposite<QuickGroup>> FilterGroups (List<ICommonTreeComposite<QuickGroup>> groups, string filter)
        {
            var upperFilter = filter?.ToUpper() ?? "";
            return groups.Where(i =>
            {
                if (i.Children?.Any() == true)
                {
                    var filteredChildren = FilterGroups(i.Children, filter);
                    i.Children.Clear();
                    i.Children.AddRange(filteredChildren);
                }
                return i.Name.ToUpper().Contains(upperFilter) || i.Children?.Any() == true;
            }).ToList();
        }

        public ActionResult Unit(BaseModel m, string sd, string filter)
        {
            var model = new UnitModel
            {
                VehicleId = m.VehicleId,
                CatalogId = m.CatalogId,
                Ssd = m.Ssd + filter,
                CategoryId = m.CategoryId ?? "-1",
                Type = m.Type,
                SelectedDetailСodes = (sd ?? "").Split(',').ToList(),
                UnitInfo = _laximoRepository.GetUnitInfo(UserPreferences.CurrentCultureUnderScore, m.CatalogId, m.VehicleId, m.CategoryId, m.UnitId, m.Ssd + filter),
                VehicleInfo = _laximoRepository.GetVehicleInfo(UserPreferences.CurrentCultureUnderScore, m.CatalogId, m.VehicleId, m.Ssd + filter).FirstOrDefault(),
            };
            model.Details = _laximoRepository.ListDetailByUnit(UserPreferences.CurrentCultureUnderScore, m.CatalogId, m.UnitId, model.UnitInfo.Ssd + filter);
            foreach (var gr in model.Details.Where(i=>!string.IsNullOrWhiteSpace(i.CodeOnImage)).GroupBy(i=>i.CodeOnImage))
            {
                if (gr.Count() > 1)
                {
                    var cnt = 1;
                    foreach (var unit in gr)
                    {
                        unit.Variant = $"{SharedResources.Variant_short} {cnt++}";
                    }
                }
            }
            model.ImageMaps = _laximoRepository.ListImageMapByUnit(UserPreferences.CurrentCultureUnderScore, m.CatalogId, m.UnitId, model.UnitInfo.Ssd + filter);
            return View(model);
        }

        public ActionResult GroupDetails(BaseModel m, string groupId)
        {
            var model = new GroupDetailsModel
            {
                VehicleId = m.VehicleId,
                CatalogId = m.CatalogId,
                Ssd = m.Ssd,
                CategoryId = m.CategoryId ?? "-1",
                Type = m.Type,
                Categories = _laximoRepository.ListDetailByGroup(UserPreferences.CurrentCultureUnderScore, m.CatalogId, m.VehicleId, groupId, m.Ssd, true)
            };
            return View(model);
        }

        public ActionResult Filter(BaseModel m, string filter, string detailId)
        {
            var model = new FilterModel
            {
                VehicleId = m.VehicleId,
                CatalogId = m.CatalogId,
                Ssd = m.Ssd,
                CategoryId = m.CategoryId ?? "-1",
                UnitId = m.UnitId,
                Type = m.Type,
                Filters = _laximoRepository.ListFilterByDetail(UserPreferences.CurrentCultureUnderScore, m.CatalogId, m.VehicleId, m.UnitId, filter, detailId ?? "0", m.Ssd)
            };
            return View(model);
        }

        public ActionResult Wizard(WizardModel m)
        {
            var model = new WizardModel
            {
                CatalogId = m.CatalogId,
                Ssd = m.Ssd,
                Rows = _laximoRepository.GetWizard2(UserPreferences.CurrentCultureUnderScore, m.CatalogId, m.Ssd)
            };
            return View(model);
        }

        public ActionResult FindVehicles(VehicleListModel m)
        {
            var model = new VehicleListModel
            {
                CatalogId = m.CatalogId,
                Ssd = m.Ssd,
                Vehicles = _laximoRepository.FindVehicle(UserPreferences.CurrentCultureUnderScore, m.CatalogId, m.Ssd, true)
            };
            return View("VehiclesList", model);
        }
    }
}