using System.Collections.Generic;

namespace Webmall.Model.Repositories.Abstract
{
    public interface IReportsRepository
    {
        byte [] GetInvoice (string clientId, string orderId, string type);

        byte[] GetComparisionAct(string clientId, string culture, bool detailed, string docId, string docTypeId, string endDate, string startDate, string type, List<KeyValuePair<string, string>> filter);
    }
}