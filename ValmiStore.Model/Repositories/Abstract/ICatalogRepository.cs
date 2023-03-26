using System.Collections.Generic;
using Webmall.Model.Entities;
using Webmall.Model.Entities.Auto;
using Webmall.Model.Entities.Catalog;

namespace Webmall.Model.Repositories.Abstract
{
    public interface ICatalogRepository
    {
        /// <summary>
        /// Возвращает список
        /// </summary>
        /// <param name="localeId">Код языка</param>
        List<Group> GetWaregroups(string localeId);

        /// <summary>
        /// Возвращает список
        /// </summary>
        /// <param name="localeId">Код языка</param>
        List<Group> GetWaregroupsList(string localeId);

        /// <summary>
        /// Возвращает список производителей
        /// </summary>
        List<Producer> GetProducers();

        /// <summary>
        /// Возвращает список всех производителей для заданной товарной группы
        /// </summary>
        /// <param name="groupId">Идентификатор товарной группы</param>
        List<string> GetGroupProducers(string groupId);

        /// <summary>
        /// Возвращает список всех свойств товаров для заданной товарной группы
        /// </summary>
        /// <param name="localeId">Код языка</param>
        /// <param name="groupId">Идентификатор товарной группы</param>
        List<GroupProperty> GetGroupProperties(string localeId, string groupId);

        /// <summary>
        /// Возвращает список товаров по заданным критериям отбора (универсальный поисковый запрос)
        /// </summary>
        /// <param name="localeId">Код языка</param>
        /// <param name="filterOptions">Параметры поиска</param>
        /// <param name="pageOptions">Параметры пагинации и сортировки</param>
        /// <param name="forBot">Режим формирования данных для бота (упрощенный)</param>
        WareList GetWareList(string localeId, FilterOptions filterOptions, PageOptions pageOptions, bool forBot);

        /// <summary>
        /// Возвращает информацию о товаре
        /// </summary>
        /// <param name="localeId">Код языка</param>
        /// <param name="wareId">Идентификатор товара в учетной системе (если не задана пара Артикул+Производитель)</param>
        /// <param name="article">Артикул товара</param>
        /// <param name="producer">Наименование производителя</param>
        Ware GetWare(string localeId, string wareId, string article, string producer);

        /// <summary>
        /// Возвращает информацию о товаре
        /// </summary>
        /// <param name="localeId">Код языка</param>
        /// <param name="wareId">Идентификатор товара в учетной системе (если не задана пара Артикул+Производитель)</param>
        /// <param name="article">Артикул товара</param>
        /// <param name="producer">Наименование производителя</param>
        List<WareProperty> GetWareProperties(string localeId, string wareId, string article, string producer);

        /// <summary>
        /// Возвращает информацию о товаре
        /// </summary>
        /// <param name="localeId">Код языка</param>
        /// <param name="wareId">Идентификатор товара в учетной системе (если не задана пара Артикул+Производитель)</param>
        /// <param name="article">Артикул товара</param>
        /// <param name="producer">Наименование производителя</param>
        List<Applicability> GetWareApplicability(string localeId, string wareId, string article, string producer);

        /// <summary>
        /// Возвращает список кодов изображений товара
        /// </summary>
        /// <param name="localeId">Код языка</param>
        /// <param name="wareId">Идентификатор товара в учетной системе (если не задана пара Артикул+Производитель)</param>
        /// <param name="article">Артикул товара</param>
        /// <param name="producer">Наименование производителя</param>
        List<string> GetWareImageIds(string localeId, string wareId, string article, string producer);

        /// <summary>
        /// Возвращает изображение товара по его коду
        /// </summary>
        /// <param name="imageId">Код языка</param>
        byte[] GetWareImage(string imageId);

        /// <summary>
        /// Возвращает список файлов товара
        /// </summary>
        /// <param name="localeId">Код языка</param>
        /// <param name="wareId">Идентификатор товара в учетной системе (если не задана пара Артикул+Производитель)</param>
        /// <param name="article">Артикул товара</param>
        /// <param name="producer">Наименование производителя</param>
        FileInfo[] GetWareFiles(string localeId, string wareId, string article, string producer);

        /// <summary>
        /// Возвращает файл товара по его коду
        /// </summary>
        /// <param name="fileId">Код языка</param>
        byte[] GetWareFile(string fileId);

        /// <summary>
        /// Возвращает информацию о предложениях на искомый товар
        /// </summary>
        /// <param name="localeId">Код языка</param>
        /// <param name="wareId">Идентификатор товара в учетной системе (если не задана пара Артикул+Производитель)</param>
        /// <param name="article">Артикул товара</param>
        /// <param name="producer">Наименование производителя</param>
        /// <param name="clientId">Код клиента для которого запрашивается предложение (если не задан, то для анонимного клиента)</param>
        /// <param name="shipmentAddressId">Код клиента для которого запрашивается предложение (если не задан, то для анонимного клиента)</param>
        /// <param name="deliveryAddressId">Код адреса доставки (необязательно, для расчета времени доступности). Если не задано, то считается доступность для склада отгрузки.</param>
        List<Offer> GetWareOffers(string localeId, string wareId, string article, string producer, string clientId, string shipmentAddressId, string deliveryAddressId, PageOptions pageOptions);

        /// <summary>
        /// Возвращает информацию о предложениях на искомый товар
        /// </summary>
        /// <param name="localeId">Код языка</param>
        /// <param name="wareId">Идентификатор товара в учетной системе (если не задана пара Артикул+Производитель)</param>
        /// <param name="article">Артикул товара</param>
        /// <param name="producer">Наименование производителя</param>
        /// <param name="clientId">Код клиента для которого запрашивается предложение (если не задан, то для анонимного клиента)</param>
        /// <param name="shipmentAddressId">Код клиента для которого запрашивается предложение (если не задан, то для анонимного клиента)</param>
        /// <param name="deliveryAddressId">Код адреса доставки (необязательно, для расчета времени доступности). Если не задано, то считается доступность для склада отгрузки.</param>
        /// <param name="filterOptions"></param>
        /// <param name="pageOptions"></param>
        List<WareReplacement> GetWareReplacements(string localeId, string wareId, string article, string producer,
            string clientId, string shipmentAddressId, string deliveryAddressId, FilterOptions filterOptions,
            PageOptions pageOptions);

        /// <summary>
        /// Возвращает информацию о сопутствующих товарах для искомого товара
        /// </summary>
        /// <param name="localeId">Код языка</param>
        /// <param name="wareId">Идентификатор товара в учетной системе (если не задана пара Артикул+Производитель)</param>
        /// <param name="article">Артикул товара</param>
        /// <param name="producer">Наименование производителя</param>
        List<WareListItem> GetRelatedWares(string localeId, string wareId, string article, string producer);

        /// <summary>
        /// Возвращает информацию о предложениях на искомый товар
        /// </summary>
        /// <param name="localeId">Код языка</param>
        /// <param name="wareId">Идентификатор товара в учетной системе (если не задана пара Артикул+Производитель)</param>
        /// <param name="article">Артикул товара</param>
        /// <param name="producer">Наименование производителя</param>
        List<WareListItem> GetComplectWares(string localeId, string wareId, string article, string producer);
        
        /// <summary>
        /// Возвращает список номеров для поля поиска по номеру
        /// </summary>
        /// <param name="search">введенный пользователем текст</param>
        /// <param name="clientId">Код клиента</param>
        /// <param name="searchType">Тип поиска (0 - по коду, 1 - по наименованию)</param>
        /// <returns></returns>
        List<AvailableNumber> GetAvailableNumbersForSearch(string clientId, string search, int searchType);

        //old
        /*/// <summary>
        /// Обновляет метаданные группы
        /// </summary>
        /// <param name="culture">Код языка</param>
        /// <param name="group">Данные</param>
        void UpdateWaregroup(string culture, Group group);

        /// <summary>
        /// Возвращает структуру товарных линий по направлениям
        /// </summary>
        /// <param name="culture">Код языка</param>
        /// <returns></returns>
        List<Group> GetWaregroups(string culture);

        /// <summary>
        /// Возвращает список товарных линий по направлениям
        /// </summary>
        /// <param name="culture">Код языка</param>
        /// <returns></returns>
        List<Group> GetPopularWaregroups(string culture);

        /// <summary>
        /// Возвращает товарную линию по Id
        /// </summary>
        /// <param name="culture">Код языка</param>
        /// <param name="waregroupId">Код товарной линии</param>
        /// <param name="url">Часть URL, относящаяся к группе</param>
        /// <returns>Объект товарная линия</returns>
        Group GetWaregroup(string culture, string waregroupId, string url);

        /// <summary>
        /// Возвращает спиcок производителей, доступных в пределах заданной группы (только для концевых групп)
        /// </summary>
        /// <param name="culture">Код языка</param>
        /// <param name="groupId">Код группы</param>
        /// <param name="modifId">Код модификации авто</param>
        /// <param name="isAction">Признак запроса товаров по акции</param>
        /// <returns>Список брендов по группе</returns>
        ProducersList GetProducersForGroup(string culture, string groupId, int? modifId, bool isAction);

        /// <summary>
        /// Получить список свойств для группы
        /// </summary>
        /// <param name="culture">Код языка</param>
        /// <param name="groupId">Код группы</param>
        /// <param name="modifId">Код модификации авто</param>
        /// <returns>Список свойств группы</returns>
        List<WareProperty> GetGroupProperties(string culture, string groupId, int? modifId);

        /// <summary>
        /// Возвращает список товаров пределах заданной группы
        /// </summary>
        /// <param name="culture">Код языка</param>
        /// <param name="groupId">Код группы</param>
        /// <param name="clientId">Код клиента</param>
        /// <param name="warehouseId">Код склада клиента</param>
        /// <param name="warehouseName">Наименование склада клиента (некоторый костыль для больбы с дубликатами товара)</param>
        /// <param name="filterOptions">Параметры фильтрации списка товаров</param>
        /// <param name="properties">Фильтрационных список параметров (null или пустой - не учитывать)</param>
        /// <param name="modifId">Код модификации (null - не учитывается)</param>
        /// <param name="name">Ключевое слово для поиска</param>
        /// <param name="searchType">Тип поиска</param>
        /// <param name="trendId">Код направления для поиска</param>
        /// <param name="sortColumn">Колонка сортировки</param>
        /// <param name="sortDirection">Направление сортировки</param>
        /// <param name="skip">Сколько записей пропустить (paging)</param>
        /// <param name="take">Сколько записей получить (paging)</param>
        /// <param name="all">Общее количество записей</param>
        /// <param name="brandList">Сюда возвращается список брендов</param>
        /// <param name="searchBotMode">Режим формирования данных для бота</param>
        /// <returns>Список товаров</returns>
        WareList GetWareList(string culture, string groupId, string clientId, string warehouseId, string warehouseName, FilterOptions filterOptions, IEnumerable<WareProperty> properties, int? modifId, string name, int searchType,
            int? trendId, string sortColumn, SortDirection sortDirection, int skip, int take, out int all, List<SelectListItem> brandList, bool searchBotMode);

        /// <summary>
        /// Возвращает список товаров пределах заданной группы
        /// </summary>
        /// <param name="culture">Код языка</param>
        /// <param name="groupId">Код группы</param>
        /// <param name="clientId">Код клиента</param>
        /// <param name="warehouseId">Код склада клиента</param>
        /// <param name="filterOptions">Параметры фильтрации списка товаров</param>
        /// <param name="properties">Фильтрационных список параметров (null или пустой - не учитывать)</param>
        /// <param name="modifId">Код модификации (null - не учитывается)</param>
        /// <param name="trendId">Код направления для поиска</param>
        /// <param name="sortColumn">Колонка сортировки</param>
        /// <param name="sortDirection">Направление сортировки</param>
        /// <param name="skip">Сколько записей пропустить (paging)</param>
        /// <param name="take">Сколько записей получить (paging)</param>
        /// <param name="all">Общее количество записей</param>
        /// <param name="brandList">Сюда возвращается список брендов</param>
        /// <param name="searchBotMode">Режим формирования данных для бота</param>
        /// <returns>Список товаров</returns>
        //List<Ware> GetWareList(string culture, int? groupId, bool isAction, IEnumerable<int> producers, int? clientId, int? warehouseId, decimal? minPrice, decimal? maxPrice, bool? onlyOnStock, bool? onlyWithPrice, IEnumerable<WareProperty> properties, int? modifId, string name, int? trendId,
        //    string sortColumn, SortDirection sortDirection, int skip, int take, out int all);
        List<Ware> GetTDWareList(string culture, string groupId, string clientId, string warehouseId, FilterOptions filterOptions, IEnumerable<WareProperty> properties, int? modifId, int? trendId,
            string sortColumn, SortDirection sortDirection, int skip, int take, out int all, List<SelectListItem> brandList, bool searchBotMode);

        /// <summary>
        /// Возвращает список товаров пределах заданной группы
        /// </summary>
        /// <param name="culture">Код языка</param>
        /// <param name="oem">список OEM-номеров вида "OENUM1, OEBRAND1; OENUM2, OEBRAND2; ..."</param>
        /// <param name="am">список AM-номеров вида "AMNUM1, AMBRAND1; AMNUM2, AMBRAND2; ..."</param>
        /// <param name="clientId">Код клиента</param>
        /// <param name="warehouseId">Код склада клиента</param>
        /// <param name="filterOptions">Параметры фильтрации списка товаров</param>
        /// <param name="properties">Фильтрационных список параметров (null или пустой - не учитывать)</param>
        /// <param name="modifId">Код модификации (null - не учитывается)</param>
        /// <param name="sortColumn">Колонка сортировки</param>
        /// <param name="sortDirection">Направление сортировки</param>
        /// <param name="skip">Сколько записей пропустить (paging)</param>
        /// <param name="take">Сколько записей получить (paging)</param>
        /// <param name="all">Общее количество записей</param>
        /// <param name="brandList">Сюда возвращается список брендов</param>
        /// <returns>Список товаров</returns>
        List<Ware> GetWareListByOem(string culture, string oem, string am, string clientId, string warehouseId, FilterOptions filterOptions, IEnumerable<WareProperty> properties,
            int? modifId,
            string sortColumn, SortDirection sortDirection, int skip, int take, out int all, List<SelectListItem> brandList);

        /// <summary>
        /// Возвращает замены товара
        /// </summary>
        /// <param name="culture">Код языка</param>
        /// <param name="wareId">Код товара</param>
        /// <param name="clientId">Код клиента</param>
        /// <param name="warehouseId">Код склада клиента</param>
        /// <param name="showAll">Признак показа всех аналогов</param>
        /// <param name="rowCnt">Кол-во найденных строк</param>
        /// <returns>Сведения о товаре</returns>
        List<Ware> GetWareReplacements(string culture, string wareId, string clientId, string warehouseId, bool showAll, out int rowCnt);

        /// <summary>
        /// Возвращает замены товара
        /// </summary>
        /// <param name="culture">Код языка</param>
        /// <param name="wareId">Код товара</param>
        /// <param name="clientId">Код клиента</param>
        /// <param name="warehouseId">Код склада клиента</param>
        /// <returns>Сведения о товаре</returns>
        List<Ware> GetRelatedWares(string culture, int wareId, string clientId, string warehouseId);

        /// <summary>
        /// Возвращает комплектность товара
        /// </summary>
        /// <param name="culture">Код языка</param>
        /// <param name="wareId">Код товара</param>
        /// <param name="clientId">Код клиента</param>
        /// <param name="warehouseId">Код склада клиента</param>
        /// <returns>Сведения о товаре</returns>
        List<Ware> GetComplectWares(string culture, int wareId, string clientId, string warehouseId);

        /// <summary>
        /// Возвращает данные для карточки товара
        /// </summary>
        /// <param name="culture">Код языка</param>
        /// <param name="wareId">Код товара</param>
        /// <param name="clientId">Код клиента</param>
        /// <param name="warehouseId">Код склада клиента</param>
        /// <param name="searchBotMode">Упрощенный режим вывода для поисковиков</param>
        /// <returns>Сведения о товаре</returns>
        Ware GetWare(string culture, string wareId, string clientId, string warehouseId, bool searchBotMode);

        /// <summary>
        /// Возвращает данные для карточки товара
        /// </summary>
        /// <param name="culture">Код языка</param>
        /// <param name="brand">Наименование производителя</param>
        /// <param name="number">Каталожный номер</param>
        /// <param name="clientId">Код клиента</param>
        /// <param name="warehouseId">Код склада клиента</param>
        /// <returns>Сведения о товаре</returns>
        Ware GetWare(string culture, string brand, string number, string clientId, string warehouseId);
        
        /// <summary>
        /// Возвращает применяемость товара к автомобилю
        /// </summary>
        /// <param name="culture">Код языка</param>
        /// <param name="wareId">Код товара</param>
        /// <returns>Список модификаций</returns>
        List<Applicability> GetWareApplicability(string culture, string wareId);

        /// <summary>
        /// Возвращает дополнительные свойства товара
        /// </summary>
        /// <param name="culture">Код языка</param>
        /// <param name="wareId">Код товара</param>
        /// <param name="modifId">Код модификации (если есть)</param>
        /// <returns>Список свойств</returns>
        List<WareProperty> GetWareProperties(string culture, string wareId, int? modifId);

        /// <summary>
        /// Возвращает список автомобильных марок
        /// </summary>
        /// <param name="culture">Код языка</param>
        /// <returns>Список марок</returns>
        List<AutoMarka> GetAutoMarkaList(string culture);

        /// <summary>
        /// Возвращает список автомоделей по заданной марке
        /// </summary>
        /// <param name="culture">Код языка</param>
        /// <param name="markaId">Код марки</param>
        /// <param name="modelId"></param>
        /// <returns>Список моделей</returns>
        List<AutoModel> GetAutoModelList(string culture, int markaId, int? modelId = null);

        /// <summary>
        /// Возвращает список модификаций по модели
        /// </summary>
        /// <param name="culture">Код языка</param>
        /// <param name="modelId">Код модели</param>
        /// <param name="yearOfProduce"></param>
        /// <param name="volume"></param>
        /// <param name="volumePercent"></param>
        /// <param name="fuelType"></param>
        /// <param name="power"></param>
        /// <param name="powerMU"></param>
        /// <param name="powerPercent"></param>
        /// <returns>Список модификаций</returns>
// ReSharper disable once InconsistentNaming
        List<AutoModification> GetAutoModifList(string culture, int modelId, int? yearOfProduce = null, int? volume = null, int? volumePercent = null, string fuelType = null, int? power = null, int? powerMU = null, int? powerPercent = null);

        /// <summary>
        /// Возвращает полные данные модификации
        /// </summary>
        /// <param name="culture">Код языка</param>
        /// <param name="modifId">Код модификации</param>
        /// <returns>Модификация</returns>
        AutoModification GetAutoModifData(string culture, int modifId);

        /// <summary>
        /// Возвращает структуру товарных групп в рамках автомобильной модификации
        /// </summary>
        /// <param name="culture">Код языка</param>
        /// <param name="modifId">Код модификации</param>
        /// <returns>Структура товарных групп</returns>
        List<Group> GetTechDocWareGroups(string culture, int modifId);

        /// <summary>
        /// Получение изображения товара
        /// </summary>
        /// <param name="culture">Код языка</param>
        /// <param name="wareId">Код товара</param>
        /// <returns>Изображение товара</returns>
        byte [] GetWareImage (string culture, string wareId);
        
        /// <summary>
        /// Получение фаила по коду
        /// </summary>
        /// <param name="culture">код языка</param>
        /// <param name="fileId">имя фаила</param>
        /// <returns>фаил в виде масива байтов</returns>
        byte[] GetFile(string culture, string fileId);

        /// <summary>
        /// Получение картинки по ее идентификатору
        /// </summary>
        /// <param name="culture">Код языка</param>
        /// <param name="imageId">Код изображения</param>
        /// <returns>Изображение товара</returns>
        byte[] GetImage(string culture, string imageId);

        /// <summary>
        /// Получить список идентификаторов изображений для заданного товара
        /// </summary>
        /// <param name="culture">Код языка</param>
        /// <param name="wareId">Код товара</param>
        /// <returns>Список идентификаторов изображений</returns>
        List<string> GetWareImages(string culture, string wareId);

        /// <summary>
        /// Получение предложений на товар
        /// </summary>
        /// <param name="culture">Код языка</param>
        /// <param name="wareId">Код товара</param>
        /// <param name="user">Текущий пользователь</param>
        /// <returns>Предложения по товару</returns>
        List <Offer> GetWareOffers (string culture, string wareId, User user);

        /// <summary>
        /// Возвращает данные авто по модификации в составе:
        /// Данные марки (Marka)
        /// Данные модели (Model)
        /// </summary>
        /// <param name="modifId">Код модификации</param>
        /// <param name="culture">Код языка</param> 
        /// <returns>Данные модификации</returns>
        AutoModification GetAutoDataByModif(int modifId, string culture);

        /// <summary>
        /// Сохраняет метаинформацию для марки авто
        /// </summary>
        /// <param name="info">Метаинформация для сохранения</param>
        /// <param name="culture">Код языка</param> 
        void SaveAutoMarkMeta(AutoMarkMetaInfo info, string culture);

        /// <summary>
        /// Возвращает категории товаров для спец. предложений
        /// </summary>
        /// <param name="culture"></param>
        /// <returns></returns>
        List<Group> GetActionCategories(string culture);

        /// <summary>
        /// Возвращает информацию об акции для товара
        /// </summary>
        /// <param name="culture">Код языка</param>
        /// <param name="wareId">Код товара</param>
        /// <param name="discGroupTypeId">Код группы скидки</param>
        /// <param name="clientId">Код текущего клиента</param>
        /// <returns></returns>
        List<WareProperty> GetWareActionInfo(string culture, string wareId, int? discGroupTypeId, string clientId);*/
    }
}
