using System.Web;
using Webmall.Model.Entities;
using Webmall.Model.Entities.Catalog;
using Webmall.Model.Entities.User;

namespace Webmall.Model.Repositories.Abstract
{
    public interface IDemandRequestRepository
    {
        /// <summary>
        /// Заполенение таблицы превышения спроса
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <param name="request">Заголовок запроса</param>
        /// <param name="requestType">Тип запроса</param>
        /// <param name="ware">Информация о товаре</param>
        /// <param name="searchString">Строка поиска</param>
        /// <param name="requestQnt">Запрошенное количество</param>
        void DemandRequest(User user, HttpRequestBase request, DemandRequestTypes requestType, Ware ware,
            string searchString = null, int? requestQnt = null);
    }
}
