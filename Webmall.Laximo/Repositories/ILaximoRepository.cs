using System.Collections.Generic;
using Laximo.Guayaquil.Data.Entities;
using Webmall.Laximo.Entities;
using CatalogInfo = Webmall.Laximo.Entities.CatalogInfo;
using Category = Webmall.Laximo.Entities.Category;
using DetailInfo = Webmall.Laximo.Entities.DetailInfo;
using VehicleInfo = Webmall.Laximo.Entities.VehicleInfo;

namespace Webmall.Laximo.Repositories
{
    public interface ILaximoRepository
    {
        /// <summary>
        /// Поиск автомобиля по VIN коду.
        /// </summary>
        /// <param name="locale">Язык, на котором предпочтительно получить данные</param>
        /// <param name="catalog">Код каталога, берется из списка каталогов. Если не указан, производится поиск во всех каталогах.</param>
        /// <param name="vin">VIN код автомобиля</param>
        /// <param name="ssd">Данные сервера</param>
        /// <param name="localized">При установке значения данного параметра "true", включается перевод наименований параметров, на указанном в Locale языке. По умолчанию, значение "false" - наименования возвращаемых параметров, в формате, указанном ниже</param>
        List<VehicleInfo> FindVehicleByVIN (string locale, string catalog, string vin, string ssd, bool localized);

        List<VehicleInfo> GetVehicleInfo(string locale, string catalog, string vehicleId, string ssd);
        List<VehicleInfo> FindVehicle(string locale, string catalog, string ssd, bool localized);
        ListCatalogs CatalogsList(string locale);
        List<WizardRow> GetWizard2(string locale, string catalog, string ssd);
        CatalogInfo GetCatalogInfo(string locale, string catalog);
        List<Category> GetCategories(string locale, string catalog, string vehicleId, string categoryId, string ssd);
        List<QuickGroup> ListQuickGroup(string locale, string catalog, string vehicleId, string ssd);
        List<UnitInfo> ListUnits(string locale, string catalog, string vehicleId, string categoryId, string ssd);
        UnitInfo GetUnitInfo(string locale, string catalog, string vehicleId, string categoryId, string unitId, string ssd);
        List<DetailInfo> ListDetailByUnit(string locale, string catalog, string unitId, string ssd);
        List<ImageMapRow> ListImageMapByUnit(string locale, string catalog, string unitId, string ssd);
        List<Category> ListDetailByGroup(string locale, string catalog, string vehicleId, string groupId, string ssd, bool all);
        List<Filter> ListFilterByDetail(string locale, string catalog, string vehicleId, string unitId, string filter, string detailId, string ssd);
        void GetFindOem(string oem, out string oems, out string ams);
    }
}
