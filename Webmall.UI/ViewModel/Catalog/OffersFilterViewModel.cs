using Webmall.UI.ViewModel.Filter;

namespace Webmall.UI.ViewModel.Catalog
{
    public class OffersFilterViewModel : CatalogFilterViewModel
    {
        /// <summary>
        /// Отображение
        /// </summary>
        public SelectViewModel ShowSection { get; set; } = new SelectViewModel();

        /// <summary>
        /// Акции
        /// </summary>
        public SelectViewModel ActionsSection { get; set; } = new SelectViewModel();

        /// <summary>
        /// Возврат
        /// </summary>
        public RangeViewModel ReturnDays  { get; set; } = new RangeViewModel();

        // form the warehouses data list
        public SelectViewModel Warehouses { get; set; } = new SelectViewModel();

        /// <summary>
        /// Срок возврата до
        /// </summary>
        public RangeViewModel DeliveryRating { get; set; } = new RangeViewModel();

        /// <summary>
        /// Наличие не менее
        /// </summary>
        public RangeViewModel AvailableQnt { get; set; } = new RangeViewModel();

        /// <summary>
        /// Срок поставки до
        /// </summary>
        public RangeViewModel DeliveryDays { get; set; } = new RangeViewModel();

        /// <summary>
        /// Цена покупки
        /// </summary>
        public RangeViewModel ClientPrice { get; set; } = new RangeViewModel();

        /// <summary>
        /// Цена продажи
        /// </summary>
        public RangeViewModel SalePrice { get; set; } = new RangeViewModel();
    }
}