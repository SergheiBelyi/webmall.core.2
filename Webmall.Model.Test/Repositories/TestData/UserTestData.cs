using System.Collections.Generic;
using Webmall.Model.Entities.Client;
using Webmall.Model.Entities.User;

namespace Webmall.Model.Test.Repositories.TestData
{
    public class UserTestData
    {
        public User User => _user;
        private static readonly User _user = new User
        {
            Id = 111444777,
            FirstName = "Test Name",
            LastName = "Test LastName",
            Login = "test@test.test",
            IP = "localhost",
            IsAccepted = true,
            Roles = 235,
            Presenters = new List<ClientPresenter>
            {
                new ClientPresenter {
                    Client = new Client { Id = "100006", Code = "100006", CurrentWarehouseId = "1", Name = "Test client 1"},
                    Roles = 0x15,
                    IsAccepted = true,
                    ClientId = "100006"
                },
                new ClientPresenter {
                    Client = new Client { Id = "000000859", Code = "000000859", CurrentWarehouseId = "2", Name = "Test client 2"},
                    Roles = 0,
                    IsAccepted = true,
                    ClientId = "000000859"
                }
            },
            CurrentPresenter = new ClientPresenter
            {
                Roles = 0x15,
                IsAccepted = true,
                ClientId = "100006"
            },
        };
    }
}