using System;
using System.Collections.Generic;
using System.Linq;
using Webmall.Model.Entities.Garage;

namespace Webmall.Model.Entities.Client
{
    public class Client
    {
        private Valute _defaultValute;

        public Client()
        {
            Breefing = new Breefing(this);
        }

        /// <summary>
        /// Идентификатор клиента (для связывания с учетной системой)
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Код клиента (для визуализации)
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Uid клиента (для обращения к ПА или другим сервисам)
        /// </summary>
        public string Uid { get; set; }

        /// <summary>
        /// Наименование клиента
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Возможность оплаты карточкой
        /// </summary>
        public bool CanPayByCard { get; set; } = true;

        /// <summary>
        /// Возможность оплаты наличными
        /// </summary>
        public bool CanPayByCash { get; set; } = true;

        /// <summary>
        /// Возможность выбора доставки c налоговой накладной
        /// </summary>
        public bool ShowTaxInvoiceDelivery { get; set; }

        /// <summary>
        /// Значение флага доставки налоговой накладной по-умолчанию
        /// </summary>
        public bool DefaultTaxInvoiceDelivery { get; set; }

        /// <summary>
        /// Текущий склад отгрузки
        /// </summary>
        public string CurrentWarehouseId { get; set; }

        /// <summary>
        /// Признак розничного клиента
        /// </summary>
        public bool IsRetail { get; set; } = true;

        /// <summary>
        /// Признак оптового клиента
        /// </summary>
        public bool IsGross
        {
            get => !IsRetail;
            set => IsRetail = !value;
        }

        /// <summary>
        /// Признак Менеджера Организации
        /// </summary>
        public bool IsOrganizationManager { get; set; }

        /// <summary>
        /// Признак "является покупателем"
        /// </summary>
        public bool IsCustomer { get; set; } = true;

        /// <summary>
        /// Признак "является поставщиком"
        /// </summary>
        public bool IsSupplier { get; set; }

        /// <summary>
        /// Признак "разрешена доставка для клиента" (берется из организации клиента)
        /// </summary>
        public bool IsDeliveryEnabled { get; set; }

        /// <summary>
        /// Валюта клиента
        /// </summary>
        public string CurrentValute { get; set; }

        /// <summary>
        /// Валюта клиента
        /// </summary>
        public List<Valute> Valutes { get; set; }

        public Valute DefaultValute => _defaultValute ?? (_defaultValute = Valutes.FirstOrDefault(i=>i.IsDefault) ?? Valutes.FirstOrDefault());

        /// <summary>
        /// Признак оперативной карточки
        /// </summary>
        public bool IsOperative { get; set; }

        /// <summary>
        /// Разрешение оформления "под-заказ"
        /// </summary>
        public bool AllowCustomOrders { get; set; } = true;

        //public Dictionary<string, object> CustomProps { get; set; } = new Dictionary<string, object>();

        //public bool AllowPaymentMenu { get; set; } = true;

        //public bool AllowSelfDelivery { get; set; } = true;

        //public bool AllowPriceDownload { get; set; } = true;

        //public bool SupplierPrise { get; set; }
        //public string SupplierPriceFileName { get; set; }

        /// <summary>
        /// Список контактных лиц
        /// </summary>
        public List<Contact> Contacts { get; set; } = new List<Contact>();

        /// <summary>
        /// Текущий контакт
        /// </summary>
        public string CurrentContactId { get; set; }

        /// <summary>
        /// Список договоров
        /// </summary>
        public List<Contract> Contracts { get; set; } = new List<Contract>();

        /// <summary>
        /// Текущий договор
        /// </summary>
        public string CurrentContractId { get; set; }

        public ManagerData ManagerData { get; set; } = new ManagerData();

        //public string MainOrganization { get; set; }

        /// <summary>
        /// Признак, что данные клиента загружены
        /// </summary>
        public bool IsLoaded { get; set; } = false;

        /// <summary>
        /// Дата последнего обновления валютных данных
        /// </summary>
        public DateTime LastValuteUpdate { get; set; } = DateTime.Now;

        public Breefing Breefing { get; set; }

        public List<string> Categories { get; set; }
    }
}