using System.Collections.Generic;
using System.Web.Mvc;
using Webmall.Model.Entities.Auto;
using Webmall.Model.Entities.Catalog;

namespace Webmall.Model.Repositories.Abstract
{
    public interface IAutoDataRepository
    {
        /// <summary>
        /// Возвращает список автомобильных марок
        /// </summary>
        List<AutoMarka> GetMarksList(string localeId);

        /// <summary>
        /// Возвращает список моделей для заданной марки
        /// </summary>
        /// <param name="localeId">Код локали (пример: ru-RU, uk-UA, ro-RO, RU)</param>
        /// <param name="markaId">Идентификатор марки автомобиля</param>
        List<AutoModel> GetModelsList(string localeId, string markaId);

        ///// <summary>
        ///// Возвращает список модификаций по модели и параметрам отбора
        ///// </summary>
        ///// <param name="localeId">Код локали (пример: ru-RU, uk-UA, ro-RO, RU)</param>
        ///// <param name="modelId">Идентификатор модели автомобиля</param>
        //List<AutoModification> GetModifList(string localeId, string modelId);

        /// <summary>
        /// Возвращает данные модификаций по ее идентификатору
        /// </summary>
        /// <param name="localeId">Код локали (пример: ru-RU, uk-UA, ro-RO, RU)</param>
        /// <param name="modifId">Идентификатор модификации автомобиля</param>
        AutoModification GetModifData(string localeId, string modifId);

        /// <summary>
        /// Возвращает дерево узлов автомобиля
        /// </summary>
        /// <param name="localeId">Код локали (пример: ru-RU, uk-UA, ro-RO, RU)</param>
        /// <param name="modifId">Идентификатор модификации автомобиля</param>
        List<Group> GetTecDocAssembliesTree(string localeId, string modifId);

        /// <summary>
        /// Возвращает список товаров для узла автомобиля
        /// </summary>
        /// <param name="localeId">Код локали (пример: ru-RU, uk-UA, ro-RO, RU)</param>
        /// <param name="modifId">Идентификатор модификации автомобиля</param>
        /// <param name="assemlyId">Идентификатор узла автомобиля</param>
        List<WareListItem> GetTecDocAssemblyWares(string localeId, string modifId, string assemlyId);

        /// <summary>
        /// Возвращает список видов топлива для фильтровки списка модификаций
        /// </summary>
        /// <param name="culture">Код языка</param>
        /// <param name="modelId">Идентификатор модели автомобиля</param>
        /// <returns>Список видов топлива</returns>
        List<SelectListItem> GetFuelTypes(string culture, string modelId);

        /// <summary>
        /// Возвращает список модификаций по модели
        /// </summary>
        /// <param name="culture">Код локали (пример: ru-RU, uk-UA, ro-RO, RU)</param>
        /// <param name="modelId">Код модели</param>
        /// <param name="yearOfProduce"></param>
        /// <param name="volume"></param>
        /// <param name="volumePercent"></param>
        /// <param name="fuelType"></param>
        /// <param name="power"></param>
        /// <param name="powerUnits"></param>
        /// <param name="powerPercent"></param>
        /// <returns>Список модификаций</returns>
        List<AutoModification> GetModifList(string culture, string modelId, int? yearOfProduce = null, int? volume = null, int? volumePercent = null, int? fuelType = null, int? power = null, int? powerUnits = null, int? powerPercent = null);
    }
}
