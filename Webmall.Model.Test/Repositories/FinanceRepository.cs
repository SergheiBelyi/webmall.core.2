using System;
using System.Collections.Generic;
using ValmiStore.Model.Entities.User;
using Webmall.Model.Entities.User;
using Webmall.Model.Repositories.Abstract;

namespace Webmall.Model.Test.Repositories
{
    public class FinanceRepository : IFinanceRepository
    {
        public List<ComparisionAct> GetComparisionAct(User user, DateTime? startDate, DateTime? endDate, string culture, List<KeyValuePair<string, string>> filter)
        {
            throw new NotImplementedException();
        }

        public List<ComparisionActDetail> GetComparisionActDetail(User currentUser, string docId, string docTypeId, string culture)
        {
            throw new NotImplementedException();
        }
    }
}
