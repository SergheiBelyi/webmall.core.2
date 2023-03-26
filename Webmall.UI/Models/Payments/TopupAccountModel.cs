namespace Webmall.UI.Models.Payments
{
    public class TopupAccountModel
    {
        public string Message { get; set; }
        public bool? Success { get; set; }
        public string ValuteName { get; set; }
        public bool CanPay { get; set; }

        //public EPayKKBAdditionalInfo EPayKKBInfo { get; set; } = new EPayKKBAdditionalInfo();
    }
}