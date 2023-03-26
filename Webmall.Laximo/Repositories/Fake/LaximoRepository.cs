using System.Collections.Generic;
using Laximo.Guayaquil.Data.Entities;
using Webmall.Laximo.Entities;
using CatalogInfo = Webmall.Laximo.Entities.CatalogInfo;
using Category = Webmall.Laximo.Entities.Category;
using DetailInfo = Webmall.Laximo.Entities.DetailInfo;
using VehicleInfo = Webmall.Laximo.Entities.VehicleInfo;

namespace Webmall.Laximo.Repositories.Fake
{
    public class LaximoRepository : ILaximoRepository
    {
        public List<VehicleInfo> FindVehicleByVIN(string locale, string catalog, string vin, string ssd, bool localized)
        {
            return new List<VehicleInfo> { new VehicleInfo 
            {
                CatalogId = "Audi",
                Name = "audi a6 2,8 (V6)",
            }};
        }

        public List<VehicleInfo> GetVehicleInfo(string locale, string catalog, string vehicleId, string ssd)
        {
            return new List<VehicleInfo> { new VehicleInfo 
            {
                CatalogId = "Audi",
                Name = "audi a6 2,8 (V6)",
            }};
        }

        public List<VehicleInfo> FindVehicle(string locale, string catalog, string ssd, bool localized)
        {
            throw new System.NotImplementedException();
        }

        public ListCatalogs CatalogsList(string locale)
        {
            throw new System.NotImplementedException();
        }

        public List<WizardRow> GetWizard2(string locale, string catalog, string ssd)
        {
            throw new System.NotImplementedException();
        }

        public List<Category> GetCategories(string locale, string catalog, string vehicleId, string categoryId, string ssd)
        {
            throw new System.NotImplementedException();
        }

        public List<QuickGroup> ListQuickGroup(string locale, string catalog, string vehicleId, string ssd)
        {
            throw new System.NotImplementedException();
        }

        public List<UnitInfo> ListUnits(string locale, string catalog, string vehicleId, string categoryId, string ssd)
        {
            throw new System.NotImplementedException();
        }

        public UnitInfo GetUnitInfo(string locale, string catalog, string vehicleId, string categoryId, string unitId, string ssd)
        {
            throw new System.NotImplementedException();
        }

        public List<DetailInfo> ListDetailByUnit(string locale, string catalog, string unitId, string ssd)
        {
            throw new System.NotImplementedException();
        }

        public List<ImageMapRow> ListImageMapByUnit(string locale, string catalog, string unitId, string ssd)
        {
            throw new System.NotImplementedException();
        }

        public List<Category> ListDetailByGroup(string locale, string catalog, string vehicleId, string groupId, string ssd, bool all)
        {
            throw new System.NotImplementedException();
        }

        public void GetFindOem(string oem, out string oems, out string ams)
        {
            throw new System.NotImplementedException();
        }

        public List<Filter> ListFilterByDetail(string locale, string catalog, string vehicleId, string unitId, string filter, string detailId, string ssd)
        {
            throw new System.NotImplementedException();
        }

        public CatalogInfo GetCatalogInfo(string locale, string catalog)
        {
            throw new System.NotImplementedException();
        }
    }
}