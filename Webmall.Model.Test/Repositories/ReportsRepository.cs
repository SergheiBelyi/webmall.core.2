using System;
using System.Collections.Generic;
using Webmall.Model.Repositories.Abstract;

namespace Webmall.Model.Test.Repositories
{
    public class ReportsRepository : IReportsRepository
    {
        public byte[] GetComparisionAct(string clientId, string culture, bool detailed, string docId, string docTypeId, string endDate, string startDate, string type, List<KeyValuePair<string, string>> filter)
        {
            throw new NotImplementedException();
        }

        public byte[] GetInvoice(string clientId, string orderId, string type)
        {
            throw new NotImplementedException();
        }
    }
}
