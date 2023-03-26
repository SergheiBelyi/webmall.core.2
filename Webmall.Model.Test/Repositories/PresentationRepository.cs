using System;
using System.Collections.Generic;
using Webmall.Model.Entities.User;
using Webmall.Model.Repositories.Abstract;

namespace Webmall.Model.Test.Repositories
{
    public class PresentationRepository : IPresentationRepository
    {
        public void AddRepresentation(User user, string clientCode, bool accept, long roles)
        {
            throw new NotImplementedException();
        }

        ClientPresenter IPresentationRepository.ApproveRepresentation(int id)
        {
            throw new NotImplementedException();
        }

        public long ChangeRepresentationRole(int id, string role, bool set)
        {
            throw new NotImplementedException();
        }

        public ClientPresenter GetClientPresenter(int id)
        {
            throw new NotImplementedException();
        }

        public void AddRepresentation(int userId, string clientCode, bool accept, long roles)
        {
            throw new NotImplementedException();
        }

        public List<ClientPresenter> GetPresentationsList(string clientId)
        {
            throw new NotImplementedException();
        }

        public ClientPresenter RemoveRepresentation(int id)
        {
            throw new NotImplementedException();
        }

        public void SavePresentationRequest(User user, ClientPresenter request)
        {
            throw new NotImplementedException();
        }
    }
}
