using System.Collections.Generic;
using System.Web.Mvc;
using Webmall.Model.Entities;
using Webmall.Model.Entities.Client;
using Webmall.Model.Entities.User;

namespace Webmall.Model.Repositories.Abstract
{
    public interface IReferenceRepository
    {
        /// <summary>
        /// Возвращает список складов
        /// </summary>
        /// <param name="clientId">Код клиента</param>
        /// <param name="culture">Код языка</param>
        /// <returns>Список складов</returns>
        List<Warehouse> GetWarehouses(string clientId, string culture);

        /// <summary>
        /// Возвращает список организаций для розничного клиента
        /// </summary>
        /// <param name="culture">Код языка</param>
        /// <param name="country"></param>
        /// <returns>Список организаций для розничного клиента</returns>
        List<SelectListItem> GetAvailableRetailOrganizations(string culture, string country);

        ///// <summary>
        ///// Возвращает список валют
        ///// </summary>
        ///// <param name="culture">Код языка</param>
        ///// <param name="user">Текущий пользователь</param>
        ///// <returns>Список валют</returns>
        //List<Valute> GetValutes(User user, string culture);

        /// <summary>
        /// Возвращает список форм оплаты
        /// </summary>
        /// <param name="culture">Код языка</param>
        /// <returns>Список форм оплаты</returns>
        List<SelectListItem> GetPaymentForms(string culture);

        /// <summary>
        /// Возвращает список типов документов
        /// </summary>
        /// <param name="culture">Код языка</param>
        /// <returns>Список типов документов</returns>
        List<SelectListItem> GetDocumentTypes(string culture);

        /// <summary>
        /// Возвращает список статусов оплаты
        /// </summary>
        /// <param name="culture">Код языка</param>
        /// <returns>Список статусов оплаты</returns>
        List<SelectListItem> GetPaymentStatuses(string culture);

        ///// <summary>
        ///// Возвращает список комбинаций для подбора шин
        ///// </summary>
        ///// <param name="culture">Код языка</param>
        ///// <param name="groupId">Код группы</param>
        ///// <param name="warePropTypeId1">Код параметра</param>
        ///// <param name="warePropTypeId2">Код параметра</param>
        ///// <param name="warePropTypeId3">Код параметра</param>
        ///// <param name="warePropTypeId4">Код параметра</param>
        ///// <param name="warePropTypeId5">Код параметра</param>
        ///// <returns></returns>
        //List<TiresCombination> GetTiresCombinations(string culture, string groupId, int? warePropTypeId1, int? warePropTypeId2, int? warePropTypeId3, int? warePropTypeId4, int? warePropTypeId5);

        ///// <summary>
        ///// Возвращает список автосервисов для записи
        ///// </summary>
        ///// <param name="culture">Код языка</param>
        ///// <returns>Список автосервисов с детализацией услуг</returns>
        //List<AutoServiceInfo> GetAutoServices(string culture);

        /// <summary>
        /// Возвращает список валют
        /// </summary>
        /// <param name="culture">Код языка</param>
        /// <param name="user">Текущий пользователь</param>
        /// <returns>Список валют</returns>
        List<Valute> GetValutes(User user, string culture);

        /// <summary>
        /// Сбрасывает кэш валюты клиента
        /// </summary>
        /// <param name="user"></param>
        /// <param name="culture"></param>
        void ClearValuteCache(User user, string culture);

        /// <summary>
        /// Возвращает доступный для клиента список типов доставки
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        List<SelectListItem> GetDeliveryTypes(string clientId, string culture);
    }
}
