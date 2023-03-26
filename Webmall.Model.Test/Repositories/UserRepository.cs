using System;
using System.Collections.Generic;
using System.Linq;
using log4net;
using log4net.Config;
using Webmall.Model.CoreHelpers;
using Webmall.Model.Entities.User;
using Webmall.Model.Entities.VinSearch;
using Webmall.Model.Repositories.Abstract;
using Webmall.Model.Test.Repositories.TestData;

namespace Webmall.Model.Test.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region Logger

        private static readonly ILog Log = LogManager.GetLogger(typeof(UserRepository));

        static UserRepository()
        {
            XmlConfigurator.Configure();
        }

        #endregion

        // ReSharper disable once InconsistentNaming
        private readonly UserTestData _testData;

        public UserRepository()
        {
            _testData = new UserTestData();
        }

        public void AddUserVinSearch(VinSearchHistoryItem item)
        {
            Log.Debug($"AddUserVinSearch: {item.ToJson()}");
        }

        public User Authentication(string login, string passwordHash, string ip, bool isSocialNetworkAuthorized)
        {
            var result = _testData.User;
            result.IP = ip;
            result.CurrentPresenter = result.Presenters.FirstOrDefault();

            return result;
        }

        public bool BlockSendingOrderResume(string guid, string pass)
        {
            throw new NotImplementedException();
        }

        public string CheckPhone(string phone, string culture)
        {
            throw new NotImplementedException();
        }

        public bool CheckUserVinSearchLimit(User user, string vin)
        {
            return vin == "VF1FLJWB68Y280218";
        }

        public bool Confirmation(string guid)
        {
            throw new NotImplementedException();
        }

        public void ChangeCurrentClient(User user)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string userLogin)
        {
            var result = _testData.User; 

            return result;
        }

        public IQueryable<User> GetUsers(UserFilter filter)
        {
            throw new NotImplementedException();
        }

        public List<VinSearchHistoryItem> GetVinSearchHistory(User user, VinHistoryFilter filter)
        {
            return new List<VinSearchHistoryItem>
            {
                new VinSearchHistoryItem { AutoName = "BMW X5", Date = DateTime.Now.AddDays(-1), Id = 1, IsSuccessful = true, UserId = 1, VIN = "VF1FLJWB68Y280218"},
                new VinSearchHistoryItem { AutoName = "BMW X25", Date = DateTime.Now.AddDays(-1), Id = 1, IsSuccessful = false, UserId = 1, VIN = "VF1FLJWB68Y280218"}
            };
        }

        public string HashPassword(string password)
        {
            return password.HashSha1();
        }

        public bool IsUserLoginFree(string userLogin)
        {
            return true;
        }

        public void RemoveUser(User user)
        {
            throw new NotImplementedException();
        }

        public int SaveUser(User user, bool createPersonalCard)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserPassword(string login, string password)
        {
            throw new NotImplementedException();
        }
               
    }
}
