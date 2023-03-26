// ReSharper disable PossibleNullReferenceException
using System.Configuration;
using System.Reflection;

namespace Webmall.Model.PriceAggregator.Core
{
    public static class ConfigHelper
    {
        

        /// <summary>
        /// Адрес от имени которого отправлять сообщения
        /// </summary>
        public static string PriceAggregatorUrl => ConfigurationManager.AppSettings[MethodBase.GetCurrentMethod().Name] ?? "http://148.251.180.109:9004/";

        #region Catalog
        /// <summary>
        /// Адрес для получения GetWaregroups
        /// </summary>
        public static string CatalogGroups => ConfigurationManager.AppSettings[MethodBase.GetCurrentMethod().Name] ?? "Catalog/Groups/1";
        
        /// <summary>
        /// Адрес для получения GetProducers
        /// </summary>
        public static string Brands => ConfigurationManager.AppSettings[MethodBase.GetCurrentMethod().Name] ?? "Catalog/Brands";

        /// <summary>
        /// Адрес для получения GetGroupProducers
        /// </summary>
        public static string BrandsId => ConfigurationManager.AppSettings[MethodBase.GetCurrentMethod().Name] ?? "Catalog/Brands/";


        /// <summary>
        /// Адрес для получения GetGroupProperties
        /// </summary>
        public static string GroupProps => ConfigurationManager.AppSettings[MethodBase.GetCurrentMethod().Name] ?? "Catalog/GroupProps/";

        /// <summary>
        /// Адрес для получения GetWareOffers
        /// </summary>
        public static string WareOffers => ConfigurationManager.AppSettings[MethodBase.GetCurrentMethod().Name] ?? "Catalog/WareOffers";

        /// <summary>
        /// Адрес для получения GetWareList
        /// </summary>
        public static string WareList => ConfigurationManager.AppSettings[MethodBase.GetCurrentMethod().Name] ?? "Catalog/Wares";

        /// <summary>
        /// Адрес для получения GetWare
        /// </summary>
        public static string Ware => ConfigurationManager.AppSettings[MethodBase.GetCurrentMethod().Name] ?? "Catalog/Ware";

        /// <summary>
        /// Адрес для получения GetWareProperties
        /// </summary>
        public static string WareProperties => ConfigurationManager.AppSettings[MethodBase.GetCurrentMethod().Name] ?? "Catalog/WareProperties";

        /// <summary>
        /// Адрес для получения GetWareApplicability
        /// </summary>
        public static string WareApplicability => ConfigurationManager.AppSettings[MethodBase.GetCurrentMethod().Name] ?? "Catalog/WareApplicability";

        /// <summary>
        /// Адрес для получения GetWareReplacements
        /// </summary>
        public static string WareReplacements => ConfigurationManager.AppSettings[MethodBase.GetCurrentMethod().Name] ?? "Catalog/WareReplacements";

        /// <summary>
        /// Адрес для получения GetWareImages
        /// </summary>
        public static string WareImages => ConfigurationManager.AppSettings[MethodBase.GetCurrentMethod().Name] ?? "Catalog/WareImageIds";

        #endregion Catalog

        /// <summary>
        /// Адрес для получения GetWareImage
        /// </summary>
        public static string WareImage => ConfigurationManager.AppSettings[MethodBase.GetCurrentMethod().Name] ?? "Images/Ware/";

        #region AutoData
        /// <summary>
        /// Адрес для получения AutoMarks
        /// </summary>
        public static string AutoMarks => ConfigurationManager.AppSettings[MethodBase.GetCurrentMethod().Name] ?? "AutoDataManagement/AutoMarks";

        /// <summary>
        /// Адрес для получения AutoModels
        /// </summary>
        public static string AutoModels => ConfigurationManager.AppSettings[MethodBase.GetCurrentMethod().Name] ?? "AutoDataManagement/AutoModels";

        /// <summary>
        /// Адрес для получения AutoModifications
        /// </summary>
        public static string AutoModifications => ConfigurationManager.AppSettings[MethodBase.GetCurrentMethod().Name] ?? "AutoDataManagement/AutoModifs";

        /// <summary>
        /// Адрес для получения AutoModifications
        /// </summary>
        public static string AutoModification => ConfigurationManager.AppSettings[MethodBase.GetCurrentMethod().Name] ?? "AutoDataManagement/AutoModif";

        /// <summary>
        /// Адрес для получения FuelTypes
        /// </summary>
        public static string FuelTypes => ConfigurationManager.AppSettings[MethodBase.GetCurrentMethod().Name] ?? "AutoDataManagement/Refs/FuelTypes";

        /// <summary>
        /// Адрес для получения AutoModifications
        /// </summary>
        public static string AutoAssemblies => ConfigurationManager.AppSettings[MethodBase.GetCurrentMethod().Name] ?? "AutoDataManagement/AutoAssembliesTree";

        /// <summary>
        /// Адрес для получения AutoAssemblyArticles
        /// </summary>
        public static string AutoAssemblyArticles => ConfigurationManager.AppSettings[MethodBase.GetCurrentMethod().Name] ?? "AutoDataManagement/AutoAssemblyArticles";

        #endregion AutoData
    }

}