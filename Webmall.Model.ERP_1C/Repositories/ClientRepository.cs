using System.Collections.Generic;
using log4net;
using log4net.Config;
using Webmall.Model.Entities.Client;
using Webmall.Model.Entities.Delivery;
using Webmall.Model.Entities.User;
using Webmall.Model.ERP_1C.Connect1C;
using Webmall.Model.ERP_1C.ERP_1C_ServiceReference;
using Webmall.Model.Repositories.Abstract;

namespace Webmall.Model.ERP_1C.Repositories
{
    public class ClientRepository : IClientRepository
    {
        #region Logger

        private static readonly ILog Log = LogManager.GetLogger(typeof(ClientRepository));

        static ClientRepository()
        {
            XmlConfigurator.Configure();
        }

        #endregion

        // ReSharper disable once InconsistentNaming

        private readonly TW_SiteIntegrationPortTypeClient _erpClient;

        public ClientRepository(TW_SiteIntegrationPortTypeClient erpClient)
        {
            _erpClient = erpClient;
        }

        public string CreateClient(UserRegistrationData user)
        {
            throw new System.NotImplementedException();
        }

        public List<Contract> GetClientContracts(string clientId, string langId = "")
        {
            var response = _erpClient.GetClientAgreements(clientId, langId);
            List<Contract> result = ResponseFrom1C<List<Contract>>.Get(response, nameof(_erpClient.GetClientAgreements));
            return result;
        }

        public List<Contact> GetClientContacts(string clientId)
        {
            throw new System.NotImplementedException();
            //var response = _erpClient.GetClientAgreements(clientId, langId);
            //List<Contact> result = ResponseFrom1C<List<Contact>>.Get(response, nameof(_erpClient.GetClientAgreements));
            //return result;
        }

        public List<DeliveryAddress> GetDeliveryAddresses(User user, string clientId, string culture)
        {
            //var response = _erpClient.GetClientDeliveryAddresses(null, clientId);
            //List<DeliveryAddress> result = ResponseFrom1C<List<DeliveryAddress>>.Get(response, nameof(_erpClient.GetClientDeliveryAddresses));
            //return result;
            return new List<DeliveryAddress>();
        }

        public void SaveDeliveryAddress(User user, string clientId, DeliveryAddress deliveryAddress)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveDeliveryAddress(string id, string clientId)
        {
            throw new System.NotImplementedException();
        }

        public void SetDefaultDeliveryAddress(User user, string clientId, string id)
        {
            throw new System.NotImplementedException();
        }

        public void ChangeDefaultWarehouse(User user, string clientId, string warehouseId)
        {
            throw new System.NotImplementedException();
        }

        public Client GetFullClientInfo(string clientId)
        {
            var response = _erpClient.GetClientData(clientId);
            Client result = ResponseFrom1C<Client>.Get(response, nameof(_erpClient.GetClientData));
            //result.Uid = result.Id;
            return result;
        }

        public decimal? GetClientTurnover(User user, System.DateTime startDate, System.DateTime endDate)
        {
            throw new System.NotImplementedException();
        }

        public List<Client> GetClientsList(string clientIds)
        {
            var response = _erpClient.GetClientsList(clientIds, null);
            List<Client> result = ResponseFrom1C<List<Client>>.Get(response, nameof(_erpClient.GetClientsList));
            foreach (var client in result)
            {
                client.Uid = client.Id;
            }
            return result;
        }

        public List<Client> GetManagedClientsList(string userExternalId)
        {
            var response = _erpClient.GetManagerClientsList(null, userExternalId);
            List<Client> result = ResponseFrom1C<List<Client>>.Get(response, nameof(_erpClient.GetManagerClientsList));
            return result;
        }

        public BreefingData GetBreefing(string clientId)
        {
            return new BreefingData
            {
                ActiveOrdersCount = 0,
                Balance = 100,
                CarsPositionsCount = 0,
                DebtMessage = null,
                NotificationsCount = 0
            };
            //var response = _erpClient.GetClientBreefing(clientId, null);
            //BreefingData result = ResponseFrom1C<BreefingData>.Get(response, nameof(_erpClient.GetClientBreefing));
            //return result;
        }

        public string SaveClientContact(User currentUser, string currentClientId, Contact contact)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveClientContact(User currentUser, string id, string clientId)
        {
            throw new System.NotImplementedException();
        }
    }
}