using System;
using System.Collections.Generic;
using ValmiStore.Model.Entities.MarketingActions;
using Webmall.Model.Repositories.Abstract;

namespace Webmall.Model.Test.Repositories
{
    public class MarketingActionsRepository : IMarketingActionsRepository
    {
        public List<MarketingAction> GetActions(string clientId, DateTime dateStart, DateTime dateEnd)
        {
            throw new NotImplementedException();
        }
    }
}
