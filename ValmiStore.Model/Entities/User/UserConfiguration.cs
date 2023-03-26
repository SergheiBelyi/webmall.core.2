using System;

namespace Webmall.Model.Entities.User
{
    public class UserConfiguration
    {
        /// <summary>
        /// Признак рассылки резюме заказа
        /// </summary>
        public bool SendOrderResume { get; set; }
        public string DefaultValuteId { get; set; }
        public bool SubscribeForPromotions { get; set; }
        public bool ShowRetailPrice { get; set; }
        public int? VinSearchLimit { get; set; }
        public DateTime? VinSearchLimitDate { get; set; }
    }
}
