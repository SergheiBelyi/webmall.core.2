using System;
using System.Collections.Generic;
using ValmiStore.Model.Entities;
using ValmiStore.Model.Repositories.Abstract;

namespace Webmall.Model.Test.Repositories
{
    public class SuppliersRepository : ISuppliersRepository
    {
        public List<SupplierPrice> GetSuppliersPrice(string clientId)
        {
            throw new NotImplementedException();
        }

        public void SetKros(string clientId, List<Kros> kroslist)
        {
            throw new NotImplementedException();
        }

        public void SetSuppliersPrice(string clientId, List<SupplierPrice> supplierPriceList)
        {
            throw new NotImplementedException();
        }
    }
}
