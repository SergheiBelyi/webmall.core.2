using System.Collections.Generic;
using Webmall.Model.Entities;
using Webmall.Model.Entities.Order;
using Webmall.Model.Entities.Order.Checkout;
using Webmall.Model.Entities.User;

namespace Webmall.Model.Repositories.Abstract
{
    public interface IOrderRepository
    {
        /// <summary>
        /// Формирует справочник статусов заказа
        /// </summary>
        /// <param name="locale">Язык</param>
        /// <returns>Список статусов заказа</returns>
        List<RefOrderStatus> GetOrderStatuses(string locale);

        /// <summary>
        /// Формирует справочник статусов позиции заказа
        /// </summary>
        /// <param name="locale">Язык</param>
        /// <returns>Список статусов позиции заказа</returns>
        List<RefOrderStatus> GetOrderPositionStatuses(string locale);

        /// <summary>
        /// Формирует список заказов для визуализации пользователю по заданным критериям.
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="filter">Фильтрационный блок</param>
        /// <param name="options">Параметры пагинации</param>
        /// <returns>Список заказов</returns>
        OrderList GetOrderList(string clientId, OrderFilterOptions filter, PageOptions options);

        /// <summary>
        /// Формирует список заказов для визуализации в торговом зале.
        /// </summary>
        /// <param name="locale">Язык</param>
        /// <param name="warehouseId">Код склада/торгового зала</param>
        /// <returns>Список заказов</returns>
        List<OrderListItem> GetPublicOrderList(string locale, string warehouseId);

        /// <summary>
        /// Формирует список позиций заказов для визуализации пользователю по заданным критериям
        /// </summary>
        /// <param name="clientId">Код клиента</param>
        /// <param name="filter">Фильтрационный блок</param>
        /// <param name="options">Параметры пагинации</param>
        /// <returns>Список заказов</returns>
        OrderPositionsList GetOrderPositionsList (string clientId, OrderFilterOptions filter, PageOptions options);

        /// <summary>
        /// Получить полные данные заказа
        /// </summary>
        /// <param name="orderId">Код заказа</param>
        /// <param name="locale">Текущий язык</param>
        /// <param name="clientId">Код клиента</param>
        /// <param name="onlyHeader">Возвращает только данные без позиций</param>
        /// <returns></returns>
        Order GetOrder(string locale, string clientId, string orderId, bool onlyHeader = false);

        /// <summary>
        /// Создает новый заказ
        /// </summary>
        /// <param name="orderData">Информация для создания заказа </param>
        /// <returns>Идентификатор созданного заказа</returns>
        string CreateOrder(CheckoutOrderData orderData);

        /// <summary>
        /// Изменяет способ доставки заказа
        /// </summary>
        /// <param name="deliveryData">Информация для изменения способа доставки заказа</param>
        /// <returns>Идентификатор измененного заказа</returns>
        string SetOrderDelivery(SetOrderDeliveryData deliveryData);

        /// <summary>
        /// Удаляет заказ
        /// </summary>
        /// <param name="user">Текущий пользователь</param>
        /// <param name="id">Идентификатор заказа</param>
        void DeleteOrder(User user, string id);

        ///// <summary>
        ///// Возвращает список позиций заказа
        ///// </summary>
        ///// <param name="user">Текущий пользователь</param>
        ///// <param name="orderId">Код заказа</param>
        ///// <returns></returns>
        List<OrderPosition> GetOrderPositions(string locale, string clientId, string orderId);




        ///// <summary>
        ///// Добавляет позиции корзины в существующий заказ
        ///// </summary>
        ///// <param name="user">Пользователь</param>
        ///// <param name="orderId">Код заказа</param>
        ///// <param name="cartPositions">Список идентификаторов позиций корзины</param>
        //void AddCartPositionsToOrder(User user, string orderId, int[] cartPositions);

        ///// <summary>
        ///// Обновляет заказ.
        ///// </summary>
        ///// <param name="user">Текущий пользователь</param>
        ///// <param name="order">Данные заказа</param>
        ///// <param name="sendToStock">Признак отправки на склад</param>
        ///// <returns>Код/номер/Id созданного заказа</returns>
        //string SaveOrder(User user, Order order, bool? sendToStock);

        /// <summary>
        /// Дублирирует заказ
        /// </summary>
        /// <param name="user">Текущий пользователь</param>
        /// <param name="orderId">Код дублируемого заказа</param>
        /// <returns>Код нового заказа</returns>
        string DuplicateOrder(User user, string orderId);

        ///// <summary>
        ///// Возвращает список позиций заказа (для обновления цены)
        ///// </summary>
        ///// <param name="user">Текущий пользователь</param>
        ///// <param name="orderId">Код заказа</param>
        ///// <param name="calcAvailability">Признак расчета наличия позиций по складам (поле WarehouseQnt)</param>
        ///// <param name="culture">Язык</param>
        ///// <returns></returns>
        //List<OrderPosition> GetOrderPositions(User user, string orderId, bool calcAvailability, string culture);


        /// <summary>
        /// Получить полные данные заказа
        /// </summary>
        /// <param name="clientId">Код клиента</param>
        /// <param name="orderId">Код заказа</param>
        /// <param name="type">Тип генерируемого файла</param>
        /// <returns></returns>
        byte[] DownloadOrderCard(string clientId, string orderId, string type);

        ///// <summary>
        ///// Удаляет позиции
        ///// </summary>
        ///// <param name="positionstList">Список кодов удаляемых позиций</param>
        ///// <param name="user">Текущий пользователь</param>
        ///// <param name="orderId">Код заказа</param>
        //void DeletePositions(User user, string orderId, List<string> positionstList);

        ///// <summary>
        ///// Изменяет кол-во товара в позиции заказа
        ///// </summary>
        ///// <param name="positionId">Код позиции</param>
        ///// <param name="quantity">Кол-во</param>
        //string UpdateOrderPositionQuantity(string positionId, decimal quantity);

        ///// <summary>
        ///// Переносит позиции в корзину
        ///// </summary>
        ///// <param name="user">Текущий пользователь</param>
        ///// <param name="orderId">Код заказа</param>
        ///// <param name="positionstList">Список кодов отправляемых в корзину позиций</param>
        //void SendPositionstoCart(User user, string orderId, List<string> positionstList);

        ///// <summary>
        ///// Отменяет заказ
        ///// </summary>
        ///// <param name="user">Текущий пользователь</param>
        ///// <param name="id">Идентификатор заказа</param>
        //void CancelOrder(User user, string id);

        ///// <summary>
        ///// Отправляет заказ в работу
        ///// </summary>
        ///// <param name="user">Текущий пользователь</param>
        ///// <param name="id">Идентификатор заказа</param>
        //string SendToWork (User user, string id);

        ///// <summary>
        ///// Отправляет заказ на склад (если все есть на складе)
        ///// </summary>
        ///// <param name="user">Текущий пользователь</param>
        ///// <param name="id">Идентификатор заказа</param>
        //string SendToStock(User user, string id);

        ///// <summary>
        ///// Удаляет позиции заказа
        ///// </summary>
        ///// <param name="user">Текущий пользователь</param>
        ///// <param name="orderId">Код заказа</param>
        ///// <param name="positions">Список удаляемых позиций</param>
        //void RemoveOrderPositions(User user, string orderId, IEnumerable<string> positions);

        ///// <summary>
        ///// Выделяет часть заказа в другой заказ
        ///// </summary>
        ///// <param name="user">Текущий пользователь</param>
        ///// <param name="positions">Список выделяемых позиций</param>
        ///// <returns>Код нового сформированного заказа</returns>
        //string ExtractToOrder(User user, IEnumerable<OrderPosition> positions);


        ///// <summary>
        ///// Выделяет часть заказа в другой заказ
        ///// </summary>
        ///// <param name="user">Текущий пользователь</param>
        ///// <param name="orderId">Код заказа</param>
        ///// <param name="positions">Список выделяемых позиций</param>
        //string ExtractToOrder(User user, string orderId, IEnumerable<string> positions);

        ///// <summary>
        ///// Возвращает варианты домтупности позиции товара по складам
        ///// </summary>
        ///// <param name="wareId">Код товара</param>
        ///// <param name="wantedQuantity">Заказанное кол-во товара</param>
        ///// <param name="warehouseId">Код склада отгрузки</param>
        ///// <param name="wantedTime"></param>
        ///// <returns></returns>
        //WareAvailabilityWrapper GetPositionAvailability (string wareId, decimal? wantedQuantity, string warehouseId, DateTime wantedTime);

        ///// <summary>
        ///// Возвращает график доставок
        ///// Фильтрует графики в зависимости от параметров оплаты и заказа (что неправильно, так как для этого есть процедура)
        ///// </summary>
        ///// <param name="user">Текущий пользователь</param>
        ///// <param name="orderId">Код заказа</param>
        ///// <param name="addressId">Код адреса доставки</param>
        ///// <param name="deliveryDate">Дата доставки</param>
        ///// <param name="warehouseId">Код склада отгрузки</param>
        ///// <param name="paymentType">Тип оплаты</param>
        ///// <param name="culture">Код культуры</param>
        ///// <param name="messTxt">В случае, если список пуст, содержит сообщение о причине</param>
        ///// <returns>Графики доставок</returns>
        //List<DeliverySchedule> GetDeliverySchedule(User user, string orderId, string addressId, string warehouseId, DateTime deliveryDate, int? paymentType, string culture, out string messTxt);

        ///// <summary>
        ///// Возвращает список доступных для заказа доставок
        ///// Фильтрует доставки в зависимости от параметров оплаты и заказа (что неправильно, так как для этого есть процедура)
        ///// </summary>
        ///// <param name="orderId">Код заказа</param>
        ///// <param name="user">Текущий пользователь</param>
        ///// <param name="filterDate">Минимальная дата доставки</param>
        ///// <param name="paymentType">Тип оплаты</param>
        ///// <param name="addressId">Код адреса доставки для подфильтровки (null - нет фильтра)</param>
        ///// <returns>Список доставок</returns>
        //List<AvailableDelivery> GetAvailableDeliveries(string orderId, User user, DateTime filterDate, int? paymentType, string addressId);

        ///// <summary>
        ///// Сохраняет новую доставку
        ///// </summary>
        ///// <param name="user">Текущий пользователь</param>
        ///// <param name="orderId">Код заказа</param>
        ///// <param name="delivery">Информация о доставке</param>
        ///// <param name="scheduleId">Код расписания</param>
        ///// <returns>Код созданной доставки</returns>
        //int? CreateNewDelivery(User user, string orderId, AvailableDelivery delivery, int scheduleId);

        ///// <summary>
        ///// Обновляет доставку
        ///// </summary>
        ///// <param name="user">Текущий пользователь</param>
        ///// <param name="deliveryId">Код изменяемой доставки</param>
        ///// <param name="delivery">Детали доставки</param>
        ///// <param name="scheduleId">код расписания</param>
        //void UpdateDelivery(User user, int? deliveryId, AvailableDelivery delivery, int scheduleId);

        ///// <summary>
        ///// Выполняет проверку наличия задолженности у текущего клиента
        ///// </summary>
        ///// <param name="user">Текущий пользователь</param>
        ///// <param name="culture">Код культуры</param>
        ///// <param name="orderId">Номер заказа</param>
        ///// <returns>null - нет задолженности, иначе текст сообщения для пользователя</returns>
        //DebtInfo CheckClientDebtBlock(User user, string orderId, string culture);

        ///// <summary>
        ///// Обновляет код доверенного лица в заказе
        ///// </summary>
        ///// <param name="user">Текущий пользователь</param>
        ///// <param name="orderId">Код заказа</param>
        ///// <param name="trustedPersonId">Код доверенного лица</param>
        //void UpdateOrderTrustedPerson(User user, string orderId, string trustedPersonId);

        ///// <summary>
        ///// Возвращает список пунктов выдачи
        ///// </summary>
        ///// <param name="orderId">Идентификатор заказа</param>
        ///// <param name="clientId">Идентификатор клиента</param>
        ///// <param name="culture">Язык</param>
        ///// <returns></returns>
        //List<PickupPoint> GetPickupPoints(string orderId, string clientId, string culture);

        /// <summary>
        /// Возвращает список собственных пунктов выдачи, доступных для клиента
        /// </summary>
        /// <param name="clientId">Код клиента</param>
        /// <param name="cityId">Код населенного пункта</param>
        List<PickupPointInfo> GetPickupPoints(string cityId, string clientId);

    }
}