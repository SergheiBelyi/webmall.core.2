using System.Collections.Generic;
using Webmall.Model.Entities.Cart;
using Webmall.Model.Entities.User;

namespace Webmall.Model.Repositories.Abstract
{
    public interface ICartRepository
    {
        /// <summary>
        /// Возвращает список позиций в корзине для текущего представительства.
        /// </summary>
        /// <param name="culture">Идентификатор языка</param>
        /// <param name="user">Пользователь</param>
        /// <param name="calcWarehouseQnt">Необходимость расчета доступности позиции корзины</param>
        /// <returns>Спсиок позиций корзины</returns>
        List<CartPosition> GetCart(string culture, User user, bool calcWarehouseQnt = false);

        /// <summary>
        /// Возвращает список позиций в корзине по идентификаторам
        /// </summary>
        /// <param name="culture">Идентификатор языка</param>
        /// <param name="user">Пользователь</param>
        /// <param name="idList"></param>
        /// <returns></returns>
        List<CartPosition> GetCartPositionsByIdList (string culture, User user, int [] idList);
        
        /// <summary>
        /// Добавляет позицию в  корзину
        /// </summary>
        /// <param name="user">Текущий пользователь</param>
        /// <param name="position">Добавляемая позиция</param>
        /// <param name="culture">Идентификатор языка</param>
        void AddCartPosition(User user, CartPosition position, string culture);

        /// <summary>
        /// Изменяем позицию в корзину
        /// </summary>
        /// <param name="user">Текущий пользователь</param>
        /// <param name="position">Добавляемая позиция</param>
        /// <param name="culture">Идентификатор языка</param>
        void EditQntCartPosition(User user, CartPosition position);

        /// <summary>
        /// Изменяем коментарий к товару
        /// </summary>
        /// <param name="user">Текущий пользователь</param>
        /// <param name="id">Ид товара в базе</param>
        /// <param name="comment">Новый коммент</param>
        void EditCommentCartPosition(User user, int id, string comment);

        /// <summary>
        /// Удаляет список позиций из заказа.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="positions">Список удаляемых позиций</param>
        void RemoveCartPosition(User user, List <int> positions);

        /// <summary>
        /// Импортирует позиции в корзину
        /// </summary>
        /// <param name="warehouseId">Код склада для которого проводится импорт</param>
        /// <param name="importPosition">Импортируемые позиции</param>
        /// <param name="clientId">Код клиента</param>
        /// <param name="userId">Код пользователя</param>
        /// <returns>Список импортированных позиций</returns>
        List<ImportResult> ImportToCart (string clientId, int userId, string warehouseId, List<ImportPosition> importPosition);

        ///// <summary>
        ///// Анализирует текст импорта
        ///// </summary>
        ///// <param name="importText">Импортируемый текст</param>
        ///// <returns>Список импортируемых позиций (для GetImportWareBrand)</returns>
        //List<ImportPosition> ParseImportText(string importText);

        ///// <summary>
        ///// Подбирает позиции по импортируемому списку
        ///// </summary>
        ///// <param name="positions">Список импортируемых позиций</param>
        ///// <param name="user">Пользователь</param>
        ///// <param name="culture">Идентификатор языка</param>
        ///// <returns>Уточненный список ипортируемых позиций</returns>
        //List<ImportPosition> GetImportWareBrand(List<ImportPosition> positions, User user, string culture);

        ///// <summary>
        ///// Подбирает товар для импорта позиции корзины.
        ///// </summary>
        ///// <param name="user">Текущий пользователь</param>
        ///// <param name="ids">Список идентификаторов импортируемых позиций</param>
        ///// <param name="criteria">Критерий подбора</param>
        ///// <param name="maxDeliveryTerm">Максимальный срок доступности</param>
        ///// <param name="culture">Идентификатор языка</param>
        ///// <returns>Спиcок подобранных товаров</returns>
        //List<Ware> GetImportWares(User user, IEnumerable<int> ids, int? maxDeliveryTerm, ImportCriteria criteria, string culture);

        /// <summary>
        /// Изменяет позицию корзины
        /// </summary>
        /// <param name="user"></param>
        /// <param name="positionId">Код позиции</param>
        /// <param name="quantity">Кол-во</param>
        void UpdatePosition(User user, int positionId, decimal quantity);
    }
}
