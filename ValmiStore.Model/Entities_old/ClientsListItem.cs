using System;

namespace ValmiStore.Model.Entities
{
    public class ClientsListItem
    {
        public int KagId { get; set; }
        public string KagName { get; set; }
        public byte? ImportantBuhId { get; set; }
        public bool? UseInternalValuteRate { get; set; }
        public bool? CanPayByCard { get; set; }
        public bool? ShowTaxInvoiceDelivery { get; set; }
        public bool? DefaultTaxInvoiceDelivery { get; set; }
        public bool? IsRetail { get; set; }
        public string OKPO { get; set; }
        public string BankAccountNum { get; set; }
        public string BankMFO { get; set; }
        public string BankName { get; set; }
        public string BankCityName { get; set; }
        public int? FilId { get; set; }
        public short? PropFormId { get; set; }
        public string PropFormName { get; set; }
        public string PropFormShName { get; set; }
        public bool? PayForm1 { get; set; }
        public bool? PayForm2 { get; set; }
        public string KagCur { get; set; }
        public string PrintKagName { get; set; }
    }
}