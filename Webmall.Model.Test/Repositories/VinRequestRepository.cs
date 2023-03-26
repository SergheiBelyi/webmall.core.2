using System;
using System.Collections.Generic;
using System.Linq;
using ValmiStore.Model.Entities.User;
using Webmall.Model.Entities.User;
using Webmall.Model.Repositories.Abstract;

namespace Webmall.Model.Test.Repositories
{
    public class VinRequestRepository : IVinRequestRepository
    {
        public IQueryable<VINRequest> GetUserRequestsList(User user, VINRequestFilter filter)
        {
            throw new NotImplementedException();
        }

        public VINRequest GetVINRequest(User user, int requestId)
        {
            throw new NotImplementedException();
        }

        public void MarkVINRequestAsAnswered(int reqId)
        {
            throw new NotImplementedException();
        }

        public void RemoveVINRequests(User user, List<string> ids)
        {
            throw new NotImplementedException();
        }

        public string GetVINRequestManagersMails()
        {
            throw new NotImplementedException();
        }

        public void SaveVINRequest(User user, VINRequest request)
        {
            throw new NotImplementedException();
        }

        public void SaveVINRequestAnswer(int posId, string nums, string comment)
        {
            throw new NotImplementedException();
        }
    }
}
