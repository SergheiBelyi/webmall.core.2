namespace ValmiStore.Model.Entities.Configuration.Features
{
    public class CatalogFeatures
    {
        public bool TiresSelection { get; set; }
    }

    public class CartFeatures
    {
        public bool ImportToCart { get; set; }
    }

    // TODO Need reviion
    public class OrderFeatures
    {
        public bool Delivery { get; set; }
        public bool VisaPayment { get; set; }
        public bool PaymentDelay { get; set; }
        // ReSharper disable once InconsistentNaming
        public bool EPayKKBPayment { get; set; }
        public bool PaymentTransfer { get; set; }
    }

    public class CabinetFeatures
    {
        public bool UserNotifications { get; set; }
        public bool LoyaltyProgram { get; set; }
    }

    public class MiscFeatures
    {
        public bool OrderTerminal { get; set; }
    }
}