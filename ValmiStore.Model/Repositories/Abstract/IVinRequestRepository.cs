using System.Collections.Generic;
using System.Linq;
using Webmall.Model.Entities.User;

namespace Webmall.Model.Repositories.Abstract
{
    public interface IVinRequestRepository
    {
        /// <summary>
        /// Сохраняет VIN-запрос
        /// </summary>
        /// <param name="user">Пользователь, выполняющий запрос</param>
        /// <param name="request">Данные запроса</param>
        void SaveVINRequest(User user, VINRequest request);

        /// <summary>
        /// Сохраняет ответ на запрос
        /// </summary>
        /// <param name="posId">Код позиции запроса</param>
        /// <param name="nums">Подобранные позиции</param>
        /// <param name="comment">Комментарий</param>
        void SaveVINRequestAnswer(int posId, string nums, string comment);

        /// <summary>
        /// Заершить ответ на запрос
        /// </summary>
        /// <param name="reqId">Код запроса</param>
        void MarkVINRequestAsAnswered(int reqId);

        /// <summary>
        /// Получает список запросов, выполненных пользователем
        /// </summary>
        /// <param name="user">Пользователь, список чьих запросов требуется</param>
        /// <param name="filter">Набор фильтров</param>
        /// <returns>Список запросов</returns>
        IQueryable<VINRequest> GetUserRequestsList(User user, VINRequestFilter filter);

        /// <summary>
        /// Получает один запрос по его идентификатору
        /// </summary>
        /// <param name="requestId">Идентификатор запроса</param>
        /// <param name="user">Пользователь</param>
        /// <returns>Полные данные запроса</returns>
        VINRequest GetVINRequest(User user, int requestId);

        /// <summary>
        /// Удаляет запросы
        /// </summary>
        /// <param name="user">пользователь</param>
        /// <param name="ids">Список идентификаторов</param>
        void RemoveVINRequests(User user, List<string> ids);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string GetVINRequestManagersMails();

    }
}
