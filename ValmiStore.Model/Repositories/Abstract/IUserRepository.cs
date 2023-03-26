using System.Collections.Generic;
using System.Linq;
using Webmall.Model.Entities.User;
using Webmall.Model.Entities.VinSearch;

namespace Webmall.Model.Repositories.Abstract
{
    public interface IUserRepository
    {
        /// <summary>
        /// Проводит аутентификацию пользователя в системе
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="passwordHash">Хешированный пароль</param>
        /// <param name="ip">ip адрес пользователя</param>
        /// <param name="isSocialNetworkAuthorized">Признак авторизации через соц. сети</param>
        /// <returns>Если аутентификация прошла успешно - данные пользователя, иначе - null</returns>
        User Authentication (string login, string passwordHash, string ip, bool isSocialNetworkAuthorized);

        /// <summary>
        /// Возвращает данные пользователя по его логину
        /// </summary>
        /// <param name="userLogin">Логин пользователя</param>
        /// <returns>Данные пользователя</returns>
        User GetUser(string userLogin);

        /// <summary>
        /// Возвращает список пользователеь согласно фильтру
        /// </summary>
        /// <param name="filter">Фильтр</param>
        /// <returns>Список пользователей</returns>
        IQueryable<User> GetUsers(UserFilter filter);

        /// <summary>
        /// Возвращает hash пароля
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        string HashPassword(string password);


        /// <summary>
        /// Подтверждает регистрацию
        /// </summary>
        /// <param name="guid">Уникальный код пользователя</param>
        /// <returns>Результат подтверждения</returns>
        bool Confirmation (string guid);

        /// <summary>
        /// Отписаться от рассылки резюме заказа
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        bool BlockSendingOrderResume(string guid, string pass);

        /// <summary>
        /// Проверяет наличие пользователя по его логину
        /// </summary>
        /// <param name="userLogin">Логин пользователя</param>
        /// <returns>true - логин свободен, false - логин занят</returns>
        bool IsUserLoginFree(string userLogin);

        /// <summary>
        /// Обновляет данные существующего или создает нового пользователя
        /// </summary>
        /// <param name="user">Данные пользователя</param>
        /// <param name="createPersonalCard">Создавать ли при создании пользователя персональную карточку</param>
        /// <returns>Код сохраненного пользователя</returns>
        int SaveUser(User user, bool createPersonalCard);

        /// <summary>
        /// Удаляет пользователя из системы
        /// </summary>
        /// <param name="user">Пользователь, которого необходимо удалить</param>
        void RemoveUser(User user);

        /// <summary>
        /// Сохраняет новый пароль пользователя
        /// </summary>
        /// <param name="login">Login пользователя</param>
        /// <param name="password">Новый пароль</param>
        void UpdateUserPassword(string login, string password);

        /// <summary>
        /// Проверяет ограничение поиска по VIN кодам
        /// </summary>
        /// <param name="user">Текущий пользователь</param>
        /// <param name="vin">VIN-код поиска</param>
        /// <returns>true - допускается поиск, false - недопускается поиск</returns>
        bool CheckUserVinSearchLimit(User user, string vin);

        /// <summary>
        /// Добавляет результат поиска в историю поисков
        /// </summary>
        /// <param name="searchResult">VIN-код поиска</param>
        void AddUserVinSearch(VinSearchHistoryItem searchResult);

        /// <summary>
        /// Возвращает историю поиска по VIN для пользователя
        /// </summary>
        /// <param name="user">Текущий пользователь</param>
        /// <param name="filter">Фильтр поиска</param>
        /// <returns></returns>
        List<VinSearchHistoryItem> GetVinSearchHistory(User user, VinHistoryFilter filter);

        /// <summary>
        /// Проверка номера телефона
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        string CheckPhone(string phone, string culture);

        /// <summary>
        /// Изменяет текущего клиента у пользователя
        /// </summary>
        /// <param name="user">Текущий пользователь</param>
        void ChangeCurrentClient(User user);
    }
}
