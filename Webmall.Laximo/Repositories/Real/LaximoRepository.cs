using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using AutoMapper;
using Laximo.Guayaquil.Data;
using Laximo.Guayaquil.Data.Entities;
using Webmall.Laximo.Core;
using Webmall.Laximo.Entities;
using Webmall.Model;
using CatalogInfo = Webmall.Laximo.Entities.CatalogInfo;
using Category = Webmall.Laximo.Entities.Category;
using DetailInfo = Webmall.Laximo.Entities.DetailInfo;
using VehicleInfo = Webmall.Laximo.Entities.VehicleInfo;

// ReSharper disable NotResolvedInText

namespace Webmall.Laximo.Repositories.Real
{
    public class LaximoRepository : ILaximoRepository
    {

        #region private Config

        private static string AuthMode
        {
            get
            {
                string authMode = ConfigurationManager.AppSettings["LaximoAuthMode"];
                if (string.IsNullOrEmpty(authMode))
                {
                    throw new ArgumentNullException("AuthMode");
                }
                return authMode;
            }
        }

        private static string CertPath
        {
            get
            {
                if (AuthMode.Equals("Certificate"))
                {
                    string certPath = ConfigurationManager.AppSettings["LaximoCertPath"];
                    if (string.IsNullOrEmpty(certPath))
                    {
                        throw new ArgumentNullException("certPath");
                    }
                    if (!Path.IsPathRooted(certPath))
                    {
                        certPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, certPath);
                    }
                    if (!File.Exists(certPath))
                    {
                        throw new ArgumentException(string.Format("File '{0}' not found", certPath));
                    }
                    return certPath;
                }
                return "notAllowedDueToAuthMode";
            }
        }

        private static string CertPwd
        {
            get
            {
                if (AuthMode.Equals("Certificate"))
                {
                    string certPwd = ConfigurationManager.AppSettings["LaximoCertPwd"];
                    if (string.IsNullOrEmpty(certPwd))
                    {
                        throw new ArgumentNullException("certPwd");
                    }
                    return certPwd;
                }
                return "notAllowedDueToAuthMode";
            }
        }

        private static string Login
        {
            get
            {
                if (AuthMode.Equals("Login"))
                {
                    string login = ConfigurationManager.AppSettings["LaximoLogin"];
                    if (string.IsNullOrEmpty(login))
                    {
                        throw new ArgumentNullException("Login");
                    }
                    return login;
                }
                return "notAllowedDueToAuthMode";
            }
        }

        private static string Password
        {
            get
            {
                if (AuthMode.Equals("Login"))
                {
                    string password = ConfigurationManager.AppSettings["LaximoPassword"];
                    if (string.IsNullOrEmpty(password))
                    {
                        throw new ArgumentNullException("Password");
                    }
                    return password;
                }
                return "notAllowedDueToAuthMode";
            }
        }
        private static readonly object Lock = new object();

        #endregion

        public static readonly CatalogProvider Provider = new CatalogProvider (CertPath, CertPwd, AuthMode, Login, Password, new CatalogCache());
        private static readonly AftermarketProvider AmProvider = new AftermarketProvider(CertPath, CertPwd, AuthMode, Login, Password, new CatalogCache());
        private readonly IMapper _mapper;

        public LaximoRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<VehicleInfo> FindVehicleByVIN(string locale, string catalog, string vin, string ssd, bool localized)
        {

            var r = HttpRuntime.Cache.Get("VIN" + vin + "Cat:" + (catalog ?? "") + "C:" + locale, Lock, () =>
            {
                if (vin.Length == 17)
                {
                    var vehicleInfos = Provider.FindVehicleByVIN(vin, catalog, locale).row;
                    return vehicleInfos?.Select(i => new VehicleInfo(i)).ToList() ?? new List<VehicleInfo>();
                } else
                {

                    var vehicleInfos = Provider.FindVehicleByFrame(vin.Substring(0,5), vin.Substring(5),  catalog, locale).row;
                    return vehicleInfos?.Select(i => new VehicleInfo(i)).ToList() ?? new List<VehicleInfo>();

                }
            });
            return r;
        }

        public List<VehicleInfo> FindVehicle(string locale, string catalog, string ssd, bool localized)
        {

            var r = HttpRuntime.Cache.Get($"Cat:{catalog ?? ""}ssd{ssd}C:{locale}", Lock, () =>
            {
                var vehicleInfos = Provider.FindVehicleByWizard2(catalog, ssd, locale).row;
                    return vehicleInfos?.Select(i => new VehicleInfo(i)).ToList() ?? new List<VehicleInfo>();
            });
            return r;
        }

        public List<VehicleInfo> GetVehicleInfo(string locale, string catalog, string vehicleId, string ssd)
        {
            return Provider.GetVehicleInfo(catalog, vehicleId, ssd, locale).row.Select(i => new VehicleInfo(i)).ToList();
        }

        public ListCatalogs CatalogsList(string locale)
        {
            return HttpRuntime.Cache.Get("CatalogsList:" + locale, Lock, () => Provider.CatalogsList(locale));
        }

        public List<WizardRow> GetWizard2(string locale, string catalog, string ssd)
        {
            return _mapper.Map<List<WizardRow>>(Provider.GetWizard2(catalog, ssd, locale).row);
        }

        public List<Category> GetCategories (string locale, string catalog, string vehicleId, string categoryId, string ssd)
        {
            var list = Provider.GetCategoriesList(catalog, vehicleId, categoryId, ssd, locale).row.Select(i=>new Category(i)).ToList();
            list.Where(i=>!string.IsNullOrEmpty(i.ParentCategoryId)).ToList().ForEach(i =>
            {
                var parent = list.FirstOrDefault(p=>p.Id == i.ParentCategoryId);
                parent?.Children.Add(i);
                i.Parent = parent;
            });
            return list.Where(i => string.IsNullOrEmpty(i.ParentCategoryId) || i.Parent == null).ToList();
        }

        public List<QuickGroup> ListQuickGroup(string locale, string catalog, string vehicleId, string ssd)
        {
            var top = Provider.GetListQuickGroup(catalog, vehicleId, ssd, locale).row;
            if (top == null)
                return new List<QuickGroup>();
            if (top.Length == 1)
                return top[0].row.Select(i => new QuickGroup(i)).ToList();
            return top.Select(i => new QuickGroup(i)).ToList();
        }

        public List<UnitInfo> ListUnits (string locale, string catalog, string vehicleId, string categoryId, string ssd)
        {
            var listUnitsRows = Provider.GetUnitsList(catalog, vehicleId, categoryId, ssd, locale).row;
            return listUnitsRows?.Select(i => new UnitInfo(i)).ToList() ?? new List<UnitInfo>();
        }

        public UnitInfo GetUnitInfo (string locale, string catalog, string vehicleId, string categoryId, string unitId, string ssd)
        {
            var getUnitInfoRows = Provider.GetUnitInfo(catalog, unitId, ssd, locale).row;
            return (getUnitInfoRows != null) ? getUnitInfoRows.Select(i => new UnitInfo(i)).FirstOrDefault() : new UnitInfo();
        }
        
        public List<DetailInfo> ListDetailByUnit(string locale, string catalog, string unitId, string ssd)
        {
            var detailInfos = Provider.GetListDetailByUnit(catalog, unitId, ssd, locale).row;
            return detailInfos?.Select(i => new DetailInfo(i)).ToList() ?? new List<DetailInfo>();
        }

        public List<Category> ListDetailByGroup(string locale, string catalog, string vehicleId, string groupId, string ssd, bool all)
        {
            var listQuickDetailCategories = Provider.GetListQuickDetail(catalog, vehicleId, groupId, ssd, all, locale).Category;
            return listQuickDetailCategories?.Select(i => new Category(i)).ToList() ?? new List<Category>();
        }
        public List<ImageMapRow> ListImageMapByUnit(string locale, string catalog, string unitId, string ssd)
        {
            var listImageMapByUnitRows = Provider.GetListImageMapByUnit(catalog, unitId, ssd, locale).row;
            return listImageMapByUnitRows?.Select(i => new ImageMapRow(i)).ToList() ?? new List<ImageMapRow>();
        }

        //public List<ImageMapRow> ListImageMapByUnit(string locale, string catalog, string unitId, string ssd)
        //{
        //    return Provider.GetListImageMapByUnit(catalog, unitId, ssd, locale).row.Select(i => new ImageMapRow(i)).ToList();
        //}

        public void GetFindOem(string oem, out string oems, out string ams)
        {
            var result = AmProvider.GetFindOEM(oem, "crosses").detail;
            oems = "";
            ams = "";
            if (result != null)
            {
                oems = string.Join(";", result.Select(i => i.formattedoem + "," + i.manufacturer).Distinct().ToList());
                ams = string.Join(";",
                    result.Where(i => i.replacements!=null).Select(i => i.replacements)
                        .Aggregate(new List<KeyValuePair<string, string>>(),
                            (s, detail) =>
                            {
                                s.AddRange(detail.Where(i=>i.detail != null).Select(i => new KeyValuePair<string, string>(i.detail.formattedoem, i.detail.manufacturer)).ToList());
                                return s;
                            }).Select(i => i.Key + "," + i.Value).Distinct().ToList());
            }

        }

        public List<Filter> ListFilterByDetail(string locale, string catalog, string vehicleId, string unitId, string filter, string detailId, string ssd)
        {
            var filterRows = Provider.GetFilterByDetail(catalog, unitId, filter, detailId, ssd, locale).row;
            return filterRows?.Select(i => new Filter(i)).ToList() ?? new List<Filter>();
        }

        public CatalogInfo GetCatalogInfo(string locale, string catalog)
        {
            var catalogRows = Provider.GetCatalogInfo(catalog, locale).row;
            return new CatalogInfo(catalogRows);
        }
    }
}