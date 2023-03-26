namespace ValmiStore.Model.Entities.Configuration.Features
{
    public class Features
    {
        public CartFeatures Cart { get; set; } = new CartFeatures();

        public CatalogFeatures Catalog { get; set; } = new CatalogFeatures();
            
        public OrderFeatures Order { get; set; } = new OrderFeatures();
        
        public CabinetFeatures Cabinet { get; set; } = new CabinetFeatures();
        
        public MiscFeatures Misc { get; set; } = new MiscFeatures();
    }
}