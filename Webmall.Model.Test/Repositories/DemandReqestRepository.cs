using System;
using System.Web;
using Webmall.Model.Entities;
using Webmall.Model.Entities.Catalog;
using Webmall.Model.Entities.User;
using Webmall.Model.Repositories.Abstract;

namespace Webmall.Model.Test.Repositories
{
    public class DemandReqestRepository : IDemandRequestRepository
    {
        public void DemandRequest(User user, HttpRequestBase request, DemandRequestTypes requestType, Ware ware,
            string searchString = null, int? requestQnt = null)
        {
            throw new NotImplementedException();
        }
    }
}
