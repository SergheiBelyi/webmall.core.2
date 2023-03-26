namespace Webmall.Model.Entities.Catalog
{
    public class BrandFilterOptions
    {
        public string Letter { get; set; }
        public string[] Marks { get; set; } = new string[0];
        public string[] Assemblies { get; set; } = new string[0];
        public string[] VehicleTypes { get; set; } = new string[0];
    }
}
