using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Webmall.Model;

namespace ValmiStore.Model.Entities
{
    public class Ware
    {
        private string _id;
        private string _groupId;

        /// <summary>
        /// Идентификатор товара
        /// </summary>
        public string Id
        {
            get => _id;
            set => _id = value?.Trim();
        }

        /// <summary>
        /// Идентификатор товара нормализованный
        /// </summary>
        public string IdNorm => Regex.Replace(_id, @"[^0-9a-zA-Z_А-Яа-я]+", "");

        /// <summary>
        /// Идентификатор товара нормализованный
        /// </summary>
        public string WareNumNorm => Regex.Replace(WareNum, @"[^0-9a-zA-Z_А-Яа-я]+", "");

        /// <summary>
        /// Идентификатор группы товара
        /// </summary>
        public string GroupId
        {
            get => _groupId;
            set => _groupId = value?.Trim();
        }

        /// <summary>
        /// Код товарного направления
        /// </summary>
        public string TrendCode { get; set; } = "Auto";

        /// <summary>
        /// Наименование товара
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание товара
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Дополнительная информация о товаре
        /// </summary>
        public string AdditionalInfo { get; set; }

        /// <summary>
        /// Наименование производителя
        /// </summary>
        public string ProducerName { get; set; }

        /// <summary>
        /// Каталожный номер
        /// </summary>
        public string WareNum { get; set; }

        /// <summary>
        /// Наличие предложений
        /// </summary>
        public bool HasOffers { get; set; }

        /// <summary>
        /// Наличие аналогов
        /// </summary>
        public bool HasAnalogues { get; set; }

        /// <summary>
        /// Количество аналогов
        /// </summary>
        public int AnaloguesCount { get; set; }

        /// <summary>
        /// Количество комплектов
        /// </summary>
        public int ComplectsCount { get; set; }

        ///// <summary>
        ///// Наличие на всех складах
        ///// </summary>
        //public int TotalOnStock { get; set; }

        ///// <summary>
        ///// Визуализация наличия на всех складах
        ///// </summary>
        //public string TotalOnStockPresenter { get {
        //    return Helper.QuantityPresenter(TotalOnStock);
        //} }

        /// <summary>
        /// Наименование единицы измерения
        /// </summary>
        public string MeasureUnit { get; set; }

        /// <summary>
        /// Кратность продажи
        /// </summary>
        public int? SaleMultiplier { get; set; }

        /// <summary>
        /// Розничная стоимость
        /// </summary>
        public decimal? RetailPrice { get; set; }

        /// <summary>
        /// Цена клиента в базовой валюте
        /// </summary>
        public decimal? MainValutePrice { get; set; }

        /// <summary>
        /// Цена клиента
        /// </summary>
        public decimal? ClientPrice { get; set; }

        public decimal? DisplayPrice => IsSale ? SalePrice : ClientPrice;

        /// <summary>
        /// Кол-во на складе
        /// </summary>
        public decimal? WareQnt { get; set; }

        /// <summary>
        /// Кол-во на всех складах
        /// </summary>
        public decimal? WareQntTotal { get; set; }

        /// <summary>
        /// Кол-во "под заказ"
        /// </summary>
        public decimal? WaitQntOrder { get; set; }

        /// <summary>
        /// Количество в упаковке
        /// </summary>
        public decimal PackQnt { get; set; }

        /// <summary>
        /// Длина
        /// </summary>
        public int WareLen { get; set; }

        /// <summary>
        /// Ширина
        /// </summary>
        public int WareWidth { get; set; }

        /// <summary>
        /// Высота
        /// </summary>
        public int WareHeight { get; set; }

        /// <summary>
        /// Вес
        /// </summary>
        public decimal WareWeight { get; set; }

        /// <summary>
        /// Длина упаковки
        /// </summary>
        public int PackLen { get; set; }

        /// <summary>
        /// Ширина упаковки
        /// </summary>
        public int PackWidth { get; set; }

        /// <summary>
        /// Высота упаковки
        /// </summary>
        public int PackHeight { get; set; }

        /// <summary>
        /// Вес упаковки
        /// </summary>
        public decimal PackWeight { get; set; }

        /// <summary>
        /// Наличие изображения
        /// </summary>
        public bool HasImage { get; set; }

        /// <summary>
        /// Сыылка на изображение для товара
        /// </summary>
        public string WareImageUrl { get; set; }

        /// <summary>
        /// Информация об акции на товар
        /// </summary>
        public string ActionInfo { get; set; }

        /// <summary>
        /// признак показа акционного значка
        /// </summary>
        public bool ShowAction { get; set; }

        /// <summary>
        /// Признак, что товар является оригинальным
        /// </summary>
        public bool IsOriginal { get; set; }

        /// <summary>
        /// Срок гарантии (в месяцах)
        /// </summary>
        public int? Warranty { get; set; }

        /// <summary>
        /// Код основной картинки товара
        /// </summary>
        public string MainImageCode { get; set; }

        /// <summary>
        /// Коды картинок товара
        /// </summary>
        public List<string> ImageCodes { get; set; }

        public List<FileInfo> Files { get; set; } = new List<FileInfo>();

        /// <summary>
        /// Свойства товара
        /// </summary>
        public List<WareProperty> Properties = new List<WareProperty>();

        /// <summary>
        /// Выбранное предложение
        /// </summary>
        public Offer Offer { get; set; }

        /// <summary>
        /// Предложения по товару
        /// </summary>
        public List<Offer> Offers { get; set; }

        /// <summary>
        /// Отметка о наличии резерва
        /// </summary>
        public bool HaveReserve { get; set; }

        /// <summary>
        /// URL связанный с группой товара
        /// </summary>
        public string GroupURL { get; set; }

        /// <summary>
        /// Наименование типа товара
        /// </summary>
        public string WareType { get; set; }

        /// <summary>
        /// Количество сопутствующих товаров
        /// </summary>
        public int RelatedWaresCount { get; set; }

        /// <summary>
        /// тип скидки (2 – распродажа, 4 – акция, nul – ни то ни другое)
        /// </summary>
        public int? DiscGroupTypeId { get; set; }

        private bool _isSale;
        private decimal? _salePrice;

        /// <summary>
        /// признак распродажи
        /// </summary>
        public bool IsSale { get => _isSale || (Offers != null && Offers.Any(i => i.IsSale)); set => _isSale = value; }

        /// <summary>
        /// цена распродажи
        /// </summary>
        public decimal? SalePrice { get => _isSale ? _salePrice : Offers?.FirstOrDefault(i => i.IsSale)?.Price; set => _salePrice = value; }

        public bool IsBlocked { get; set; }

        public bool IsPresent => (WareQntTotal > 0 || SaleQnt > 0);

        public bool IsNew { get; set; }

        /// <summary>
        /// количество товара на распродаже
        /// </summary>
        public decimal? SaleQnt { get; set; }


        /// <summary>
        /// признак акции
        /// </summary>
        public bool IsAction { get; set; }

        /// <summary>
        /// Допустимость добавления в корзину
        /// </summary>
        public bool CanAddToCart => (ClientPrice > 0 || RetailPrice > 0) && (WareQntTotal > 0 || (WaitQntOrder > 0 && !ConfigHelper.AllowSendToCartOnlyFromStock))
            || SalePrice > 0 && SaleQnt > 0;

        /// <summary>
        /// Товар по заказ
        /// </summary>
        public bool OnlyForReservation => !CanAddToCart && (WaitQntOrder > 0);

        /// <summary>
        /// URL связанный с товарной позицией
        /// </summary>
        public string URL => TrendCode + "/" + (!string.IsNullOrEmpty(GroupURL) ? GroupURL + "/" : "")
                             + Helper.RemoveBadURLSymbols(ProducerName, false) + "/"
                             + Helper.RemoveBadURLSymbols(WareNum, true)
                             + (HasDuplicateNums ? "_" + Id : "");

        /// <summary>
        /// Отметка о дубликате каталожного номера в рамках бренда
        /// </summary>
        public bool HasDuplicateNums { get; set; }

        /// <summary>
        /// Признак предложения с партнерского склада
        /// </summary>
        public bool IsPartnerWarehouse { get; set; }

        /// <summary>
        /// Признак того, что товар уже есть в корзине
        /// </summary>
        public int InCart { get; set; }

        /// <summary>
        /// Признак необходимости автоматической загрузки аналогов
        /// </summary>
        public bool LoadAnalogues { get; set; }
    }
}