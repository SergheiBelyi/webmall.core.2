using System;
using System.Collections.Generic;
using System.Linq;
using Webmall.Model.Entities.Client;
using Webmall.Model.Entities.Delivery;
using Webmall.Model.Entities.User;
using Webmall.Model.Repositories.Abstract;
using Webmall.Model.Test.Repositories.TestData;

namespace Webmall.Model.Test.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly IGarageRepository _garageRepository;

        private readonly ClientTestData _testData;

        public ClientRepository(IGarageRepository garageRepository)
        {
            _garageRepository = garageRepository;
            _testData = new ClientTestData();
        }

        public void ChangeDefaultWarehouse(User user, string clientId, string warehouseId)
        {
            throw new NotImplementedException();
        }

        public List<Client> GetManagedClientsList(string userExternalId)
        {
            return _testData.ManagedClients;
        }

        public BreefingData GetBreefing(string clientId)
        {
            return new BreefingData
            {
                ActiveOrdersCount = 0,
                Balance = 100,
                CarsPositionsCount = _garageRepository.GetCars(clientId).Count,
                DebtMessage = null,
                NotificationsCount = 0
            };
        }

        public string SaveClientContact(User currentUser, string currentClientId, Contact contact)
        {
            var client = currentUser.CurrentPresenter.Client;
            if (string.IsNullOrEmpty(contact.Id))
            {
                contact.Id = Guid.NewGuid().ToString();
            }
            else
            {
                client.Contacts.Remove(
                    client.Contacts.FirstOrDefault(i => i.Id == contact.Id));
            }
            client.Contacts.Add(contact);
            return contact.Id;
        }

        public virtual void RemoveClientContact(User currentUser, string id, string clientId)
        {
            var client = currentUser.CurrentPresenter.Client;
            client.Contacts.Remove(
                client.Contacts.FirstOrDefault(i => i.Id == id));
        }

        public virtual string CreateClient(UserRegistrationData user)
        {
            throw new NotImplementedException();
        }

        public List<Contract> GetClientContracts(string clientId, string langId = "")
        {
            return _testData.Clients.FirstOrDefault(i=>i.Id == clientId)?.Contracts;
        }

        public List<Contact> GetClientContacts(string clientId)
        {
            return _testData.Clients.FirstOrDefault(i => i.Id == clientId)?.Contacts;
        }

        public virtual List<Client> GetClientsList (string clientId)
        {
            return _testData.Clients;
        }

        public decimal? GetClientTurnover(User user, DateTime startDate, DateTime endDate)
        {
            return 500M;
        }

        public List<DeliveryAddress> GetDeliveryAddresses(User user, string clientId, string culture)
        {
            return new List<DeliveryAddress>
            {
                new DeliveryAddress { AddressId = "1", Comment = "Comment 1", 
                    RegionId = "1", RegionName = "Region 1", LocalityId = "1", LocalityName = "Locality 1", StreetId = "1", StreetName = "Street 1", House = "1/1", Flat = "1",
                    Zip = "MD-1111", IsDefault = true, IsDeletePossible = false, IsSelectable = true },
                new DeliveryAddress { AddressId = "2", Comment = "Comment 2",
                    RegionId = "2", RegionName = "Region 2", LocalityId = "2", LocalityName = "Locality 2", StreetId = "2", StreetName = "Street 2", House = "2/2", Flat = "2",
                    Zip = "MD-2222", IsDefault = true, IsDeletePossible = false, IsSelectable = true }
            };
        }

        public virtual Client GetFullClientInfo(string clientId)
        {
            return _testData.Clients.FirstOrDefault(i => i.Id == clientId);
        }

        public virtual void RemoveDeliveryAddress(string id, string clientId)
        {
            throw new NotImplementedException();
        }

        public void SaveDeliveryAddress(User user, string clientId, DeliveryAddress deliveryAddress)
        {
            throw new NotImplementedException();
        }

        public void SetDefaultDeliveryAddress(User user, string clientId, string id)
        {
            throw new NotImplementedException();
        }
    }
}
