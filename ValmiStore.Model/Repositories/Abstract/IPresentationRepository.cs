using System.Collections.Generic;
using Webmall.Model.Entities.User;

namespace Webmall.Model.Repositories.Abstract
{
    public interface IPresentationRepository
    {
        /// <summary>
        /// Удаляет представительство
        /// </summary>
        /// <param name="id">Идентификатор представительства</param>
        ClientPresenter RemoveRepresentation(int id);

        /// <summary>
        /// Подтверждает представительство
        /// </summary>
        /// <param name="id">Идентификатор представительства</param>
        ClientPresenter ApproveRepresentation(int id);

        /// <summary>
        /// Устанавливает / сбрасывает роль представительства
        /// </summary>
        /// <param name="id">Код представительства</param>
        /// <param name="role">Роль (текст)</param>
        /// <param name="set">True - установить, False - сбросить</param>
        long ChangeRepresentationRole(int id, string role, bool set);

        /// <summary>
        /// Сохраняет запрос на регистрацию представительства
        /// </summary>
        /// <param name="user">Пользователь, отправляющий запрос</param>
        /// <param name="request">Данные запроса</param>
        void SavePresentationRequest(User user, ClientPresenter request);

        /// <summary>
        /// Возвращает представительство по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ClientPresenter GetClientPresenter(int id);

        /// <summary>
        /// Добавляет запрос на представительство
        /// </summary>
        /// <param name="userId">Код пользователя</param>
        /// <param name="clientCode">код клиента</param>
        /// <param name="accept">Признак автоматического утверждения</param>
        /// <param name="roles">Устанавливаемые роли</param>
        /// <returns>True - запрос выполнен успешно, False - ошибка</returns>
        void AddRepresentation(int userId, string clientCode, bool accept, long roles);

        /// <summary>
        /// Возвращает список всех запросов на представительство для заданного клиента
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns>Список представительств</returns>
        List<ClientPresenter> GetPresentationsList(string clientId);
    }
}
