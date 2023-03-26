namespace Webmall.Laximo.Entities
{
    public class CatalogInfo
    {
        /// <summary>
        /// Код каталога.
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Производитель автомобиля
        /// </summary>
        public string Brand { get; set; }

        public string Name { get; set; }
        
        public bool HasGroupSearch { get; set; }

        public CatalogInfo() { }

        public CatalogInfo(global::Laximo.Guayaquil.Data.Entities.CatalogInfo vI)
        {
            Code = vI.code;
            Brand = vI.brand;
            Name = vI.name;
            HasGroupSearch = vI.isFeatureSupported("quickgroups");
        }

    }
}