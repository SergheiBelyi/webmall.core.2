using System;
using System.Collections.Generic;
using ValmiStore.Model.Entities.MarketingActions;

namespace Webmall.Model.Repositories.Abstract
{
    public interface IMarketingActionsRepository
    {
        List<MarketingAction> GetActions(string clientId, DateTime dateStart, DateTime dateEnd);
    }
}
