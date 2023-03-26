using System;
using System.Collections.Generic;
using System.Linq;
using Webmall.Model.Entities.Order;

namespace ValmiStore.Model.Entities.Order
{
    public class Order
    {
        /// <summary>
        /// Идентификатор заказа
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Дата создания заказа
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Код склада отгрузки
        /// </summary>
        public string WarehouseId { get; set; }

        /// <summary>
        /// Наименование склада отгрузки
        /// </summary>
        public string WarehouseName { get; set; }

        /// <summary>
        /// Сумма из БД
        /// </summary>
        public decimal? SumDB { get; set; }

        /// <summary>
        /// Сумма расчетная
        /// </summary>
        public decimal? Sum => (Positions?.Sum(i => i.Sum) ?? 0) + (Delivery?.Cost ?? 0);

        /// <summary>
        /// Код статуса заказа
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Наименование статуса заказа
        /// </summary>
        public string StatusName { get; set; }

        /// <summary>
        /// Пользователь, создавший заказ
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Код клиента
        /// </summary>
        public string ClientId { get; set; }


        public PaymentInfo PaymentInfo { get; set; }

        /// <summary>
        /// Необходимость оплаты
        /// </summary>
        public bool NeedToPay { get; set; }

        /// <summary>
        /// Факт оплаты заказа
        /// </summary>
        public bool IsPayed { get; set; }

        /// <summary>
        /// Собрать срочно
        /// </summary>
        public bool IsUrgentCollection { get; set; }

        /// <summary>
        /// Код валюты
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Тип оплаты (наличные, перечисление, VISA)
        /// </summary>
        private int _paymentType = (int) PaymentTypes.Cash;

        public int PaymentType
        {
            get => _paymentType;
            set
            {
                _paymentType = value;
                switch (_paymentType)
                {
                    case (int) PaymentTypes.Cash:
                        _paymentConditionsId = (int) PaymentConditions.Cash;
                        break;
                    case (int) PaymentTypes.Invoice:
                        _paymentConditionsId = (int) PaymentConditions.Transfer;
                        break;
                    case (int) PaymentTypes.Visa:
                        _paymentConditionsId = (int) PaymentConditions.Cash;
                        break;
                    case (int) PaymentTypes.LiqPay:
                        _paymentConditionsId = (int) PaymentConditions.Cash;
                        break;
                    case (int) PaymentTypes.EPayKKB:
                        _paymentConditionsId = (int) PaymentConditions.Cash;
                        break;
                    default:
                        _paymentConditionsId = (int) PaymentConditions.Cash;
                        break;
                }

                _paymentConditionsId = (value == (int) PaymentTypes.Cash)
                    ? (int) PaymentConditions.Cash
                    : (int) PaymentConditions.Transfer;
            }
        }

        /// <summary>
        /// Код условий оплаты
        /// </summary>
        int? _paymentConditionsId;

        public int? PaymentConditionsId
        {
            get => _paymentConditionsId ?? (int) PaymentConditions.Cash;
            set
            {
                _paymentConditionsId = value;
                _paymentType = (_paymentConditionsId == (int) PaymentConditions.Cash)
                    ? (int) PaymentTypes.Cash
                    : (int) PaymentTypes.Invoice;
            }
        }

        /// <summary>
        /// Код договора + код отсрочки
        /// </summary>
        public string CompositeAgreementId
        {
            get => AgreementId + "-" + PayDelayId;
            set
            {
                var vals = value.Split('-');
                AgreementId = vals[0];
                try
                {
                    PayDelayId = int.Parse(vals[1]);
                }
                catch (Exception)
                {
                    PayDelayId = 0;
                }
            }
        }

        /// <summary>
        /// Код договора
        /// </summary>
        public string AgreementId { get; set; }

        /// <summary>
        /// Код доверенности
        /// </summary>
        public int? TrustId { get; set; }

        /// <summary>
        /// Необходима доставка
        /// </summary>
        public bool NeedToDeliver { get; set; }

        /// <summary>
        /// Комментарий к заказу
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Для показа на HTML странице
        /// </summary>
        public string HtmlComment => Comment;

        public DateTime ShippingDate { get; set; }

        public DateTime AvailabilityDate
        {
            get
            {
                DateTime date = DateTime.Now;
                //if (Status != OrderStatuses.Draft.ToString())
                //    foreach (var pos in Positions)
                //        if (pos.DeliveryInfo.DeliveryDate.HasValue && pos.DeliveryInfo.DeliveryDate > date)
                //            date = pos.DeliveryInfo.DeliveryDate.Value;

                return date;
            }
        }

        public static string PresenterPattern = "dd.MM.yyyy HH:mm";

        public string AvailabilityDatePresenter => AvailabilityDate.ToString(PresenterPattern);

        /// <summary>
        /// Информация о доставке
        /// </summary>
        public AvailableDelivery Delivery { get; set; } = new AvailableDelivery();

        /// <summary>
        /// Наименование отсрочки платежа
        /// </summary>
        public string PayDelayName { get; set; }

        /// <summary>
        /// Кол-во дней отсрочки
        /// </summary>
        public int? PayDelayDays { get; set; }

        /// <summary>
        /// Код отсрочки
        /// </summary>
        public int? PayDelayId { get; set; }

        /// <summary>
        /// Признак возможности удалить заказ
        /// </summary>
        public bool CanBeDeleted { get; set; }

        /// <summary>
        /// Признак возможности изменения заказа (при 0 - блокируется все, кроме выделения в подзаказ. В т.ч. и отправка в работу)
        /// </summary>
        public bool CanBeChanged { get; set; }

        /// <summary>
        /// При невозможности изменения заказа - причина
        /// </summary>
        public string CanNotBeChangedComment { get; set; }

        /// <summary>
        /// Признак возможности оплаты электронной картой
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public bool CanPayVISA { get; set; }

        /// <summary>
        /// ФИО ответственного менеджера
        /// </summary>
        public string ResponsibleName { get; set; }

        /// <summary>
        /// Позиции заказа
        /// </summary>
        public List<OrderPosition> Positions { get; set; }

        /// <summary>
        /// Признак возможности печати акта приема-передачи
        /// </summary>
        public bool AllowTransmissionAct { get; set; }

        /// <summary>
        /// TODO Адрес склада
        /// </summary>
        public string WarehouseAddress { get; set; }

        /// <summary>
        /// TODO даты доставки
        /// </summary>
        public DateTime[] DeliverySchedule { get; set; }


        public Order()
        {
            Positions = new List<OrderPosition>();
            OrderDate = DateTime.Now;
        }
    }

    public enum OrderStatuses
    {
        Draft = 1,
        SendedToProcess = 2,
        Processing = 3,
        Packaging = 4,
        ReadyForDelivery = 5,
        Delivery = 6,
        Finished = 7,
        RequestToDelete = 8,
        Completed = 9,
        Canceled = 10,
        PreparingForDelivery = 11,
        Reserved
    }

    public enum PaymentTypes
    {
        //Account = 1,
        Cash = 1,
        Invoice = 3,
        Visa = 4,
        LiqPay = 5,

        // ReSharper disable once InconsistentNaming
        EPayKKB = 6
    }

    public enum PaymentConditions
    {
        Cash = 1,
        Transfer = 2,
    }
}