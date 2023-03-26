using System;
using System.Collections.Generic;
using ValmiStore.Model.Entities.User;
using Webmall.Model.Entities.User;

namespace Webmall.Model.Repositories.Abstract
{
    public interface IFinanceRepository
    {
        /// <summary>
        /// Формирует акт сверки
        /// </summary>
        /// <param name="user">Текущий пользователь</param>
        /// <param name="startDate">Дата начала периода</param>
        /// <param name="endDate">Дата конца периода</param>
        /// <param name="culture">Код языка</param>
        /// <param name="filter">Фильтры Key:параметр, Value: значение</param>
        /// <returns>Список позиций акта сверки</returns>
        List<ComparisionAct> GetComparisionAct(User user, DateTime? startDate, DateTime? endDate, string culture, List<KeyValuePair<string, string>> filter);

        /// <summary>
        /// Расшифровка строки акта сверки
        /// </summary>
        /// <param name="currentUser">Текущий пользователь</param>
        /// <param name="docId">Код документа для расшифровки</param>
        /// <param name="docTypeId">Код типа документа для расшифровки</param>
        /// <param name="culture">Код языка</param>
        /// <returns>Список позиций для расшифровки</returns>
        List<ComparisionActDetail> GetComparisionActDetail(User currentUser, string docId, string docTypeId, string culture);

    }
}
