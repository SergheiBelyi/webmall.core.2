namespace Webmall.Model.Entities.Catalog
{
    public class AutoDataFilterOptions
    {
        public int? MarkaId { get; set; }
        public int? ModelId { get; set; }
        public int? Modif { get; set; }

        public void Clear()
        {
            MarkaId = null;
            ModelId = null;
            Modif = null;
        }
    }
}