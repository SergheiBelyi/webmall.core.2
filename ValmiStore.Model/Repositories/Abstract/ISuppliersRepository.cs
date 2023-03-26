using System.Collections.Generic;
using ValmiStore.Model.Entities;


namespace ValmiStore.Model.Repositories.Abstract
{
    public interface ISuppliersRepository
    {
        /// <summary>
        /// Загрузка прайсов для партнерских складов
        /// </summary>
        /// <param name="clientId">Код клиента</param>
        /// <param name="supplierPriceList">Список прайсов</param>
        void SetSuppliersPrice(string clientId, List<SupplierPrice> supplierPriceList);


        /// <summary>
        /// Получение из базы прайсов для партнерских складов
        /// </summary>
        /// <param name="clientId">Код клиента</param>        
        List<SupplierPrice> GetSuppliersPrice(string clientId);


        /// <summary>
        /// Загрузка доступных брендов для партнерских складов
        /// </summary>
        /// <param name="clientId">Код клиента</param>
        /// <param name="kroslist">Список кросбрендов</param>
        void SetKros(string clientId, List<Kros> kroslist);
    }
}
