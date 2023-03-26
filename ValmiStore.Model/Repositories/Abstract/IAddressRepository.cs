using System.Collections.Generic;
using Webmall.Model.Entities.Address;
using Webmall.Model.Entities.Delivery;
using Webmall.Model.Entities.References;
using Webmall.Model.Entities.User;

namespace Webmall.Model.Repositories.Abstract
{
    public interface IAddressRepository
    {
        /// <summary>
        /// Возвращает список населенных пунктов
        /// </summary>
        /// <param name="user">Текущий пользователь</param>
        /// <param name="culture">Код языка</param>
        /// <param name="countryId">Не используется </param>
        /// <returns>Список населенных пунктов</returns>
        List<SimpleReferenceItem> GetRegions(User user, string culture, string countryId = null);

        /// <summary>
        /// Возвращает список населенных пунктов
        /// </summary>
        /// <param name="user">Текущий пользователь</param>
        /// <param name="culture">Код языка</param>
        /// <param name="regionId"></param>
        /// <param name="countryId">Не используется </param>
        /// <param name="withCarrier">Только с возможнойтью доставки</param>
        /// <returns>Список населенных пунктов</returns>
        List<LocalityReference> GetLocalities(User user, string culture, string regionId, string countryId = null, bool withCarrier = false);

        /// <summary>
        /// Возвращает список улиц
        /// </summary>
        /// <param name="culture">Код языка</param>
        /// <param name="cityId">Код населенного пункта</param>
        /// <returns>Список улиц</returns>
        List<StreetReference> GetStreets(string culture, int? cityId);

        /// <summary>
        /// Возвращает список перевозчиков с доставкой в заданный населенный пункт
        /// </summary>
        /// <param name="localityId"></param>
        /// <param name="clientId"></param>
        /// <returns>Список населенных пунктов</returns>
        List<CarrierServiceInfo> GetCarriers(string localityId, string clientId);

        /// <summary>
        /// Возвращает список пунктов выдачи перевозчика в заданном населенном пункте
        /// </summary>
        /// <param name="localityId"></param>
        /// <param name="carrierId"></param>
        /// <returns>Список населенных пунктов</returns>
        List<PickupPointInfo> GetCarrierPickupPoints(string localityId, string carrierId);

        /// <summary>
        /// Возвращает список адресов доставки для клиента
        /// </summary>
        /// <param name="user">Текущий пользователь</param>
        /// <param name="clientId">Код клиента</param>
        /// <param name="culture">Код языка</param>
        /// <returns>Список адресов доставки</returns>
        List<DeliveryAddress> GetDeliveryAddresses(User user, string clientId, string culture);

        /// <summary>
        /// Сохраняет данные адреса доставки
        /// </summary>
        /// <param name="user">Текущий пользователь</param>
        /// <param name="clientId">Код клиента</param>
        /// <param name="deliveryAddress">Объект адреса доставки</param>
        void SaveDeliveryAddress(User user, string clientId, DeliveryAddress deliveryAddress);

        /// <summary>
        /// Удаляет адрес доставки
        /// </summary>
        /// <param name="id">Код адреса доставки</param>
        /// <param name="clientId">Код клиента</param>
        void RemoveDeliveryAddress(string id, string clientId);

        /// <summary>
        /// Устанавливает адрес доставки по-умолчанию
        /// </summary>
        /// <param name="user">Текущий пользователь</param>
        /// <param name="clientId">Текущий пользователь</param>
        /// <param name="id">Идентификатор адреса доставки</param>
        void SetDefaultDeliveryAddress(User user, string clientId, string id);
    }
}
