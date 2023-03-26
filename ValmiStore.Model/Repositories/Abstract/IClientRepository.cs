using System;
using System.Collections.Generic;
using Webmall.Model.Entities.Client;
using Webmall.Model.Entities.User;

namespace Webmall.Model.Repositories.Abstract
{
    public interface IClientRepository
    {
        /// <summary>
        /// Создает нового клиента по данным пользователя
        /// </summary>
        /// <returns>код созданного клиента</returns>
        string CreateClient (UserRegistrationData user);

        /// <summary>
        /// Возвращает список договоров клиента
        /// </summary>
        /// <param name="langId">Код языка</param>
        /// <param name="clientId">Код клиента</param>
        /// <returns>Список договоров</returns>
        List<Contract> GetClientContracts(string clientId, string langId = "");

        /// <summary>
        /// Возвращает список контактных лиц клиента
        /// </summary>
        /// <param name="clientId">Код клиента</param>
        /// <returns></returns>
        List<Contact> GetClientContacts(string clientId);

        /// <summary>
        /// Устанавливает склад отгрузки по-умолчанию
        /// </summary>
        /// <param name="user">Текущий пользователь</param>
        /// <param name="clientId">Код клиента</param>
        /// <param name="warehouseId">Код склада</param>
        void ChangeDefaultWarehouse(User user, string clientId, string warehouseId);

        /// <summary>
        /// Возвращает информацию о клиенте по его коду
        /// </summary>
        /// <param name="clientId">Код клиента</param>
        /// <returns>Информация по клиенту</returns>
        Client GetFullClientInfo(string clientId);

        /// <summary>
        /// Получение нформации об обороте клиента
        /// </summary>
        /// <param name="user"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        decimal? GetClientTurnover(User user, DateTime startDate, DateTime endDate);

        List<Client> GetClientsList(string clientId);

        List<Client> GetManagedClientsList(string userExternalId);

        BreefingData GetBreefing(string clientId);
        string SaveClientContact(User currentUser, string currentClientId, Contact contact);
        void RemoveClientContact(User currentUser, string id, string clientId);
    }
}
