using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using Webmall.Model.CoreHelpers;
using Webmall.Model.Database.DataLayer;
using Webmall.Model.Database.DataLayer.Models;
using Webmall.Model.Entities.Client;
using Webmall.Model.Entities.User;
using Webmall.Model.Entities.VinSearch;
using Webmall.Model.Repositories.Abstract;
using Newtonsoft.Json;


namespace Webmall.Model.Database.Repositories
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
        readonly WebmallDbContext _db = new WebmallDbContext();
        private readonly IMapper _mapper;
        private readonly IClientRepository _clientRepository;

        public UserRepository(IMapper mapper, IClientRepository clientRepository)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
        }

        ~UserRepository()
        {
            try
            {
                _db.Dispose();
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        public void AddUserVinSearch(VinSearchHistoryItem item)
        {
            var today = DateTime.Now.Date;
            if (_db.VinSearchHistories.Any(i => (i.UserId == item.UserId || (i.UserId == null && item.UserId == 0)) && i.IP == item.UserIP && i.Date == today && i.Vin == item.VIN))
                return;

            _db.VinSearchHistories.Add(_mapper.Map<DbVinSearchHistory>(item));
            _db.SaveChanges();
        }

        public User Authentication(string login, string passwordHash, string ip, bool isSocialNetworkAuthorized)
        {
            var dbUser = _db.Users//.Include(i => i.Addresses).Include(i => i.Presentations)
                            .FirstOrDefault(i => (i.Login == login || i.PhoneMobile == login) && (i.Password == passwordHash || isSocialNetworkAuthorized));
            if (dbUser == null)
                return null;

            var result = _mapper.Map<User>(dbUser);
            result.IP = ip;

            var logRecord = new DbBootLog { IP = ip, Login = result.Login, LoginTime = DateTime.Now };
            _db.BootLog.Add(logRecord);
            dbUser.LastLogOnDate = DateTime.Now;
            _db.SaveChanges();

            return result;
        }

        public bool BlockSendingOrderResume(string aGuid, string pass)
        {
            var guid = Guid.Parse(aGuid);

            var dbUser = _db.Users.FirstOrDefault(i => i.Guid == guid && i.Password == pass);
            if (dbUser != null)
            {
                dbUser.Configuration.SendOrderResume = false;
                _db.SaveChanges();
                return true;
            }

            return false;
        }

        public string CheckPhone(string phone, string culture)
        {
            return _db.Users.Any(i => i.PhoneMobile == phone) ? "Phone already registered" : null;
        }

        public bool CheckUserVinSearchLimit(User user, string vin)
        {
            if (!(user.IsVinSearchUnlimited &&
                  (!user.VinSearchLimitDate.HasValue || user.VinSearchLimitDate > DateTime.Now)))
            {
                var today = DateTime.Now.Date;
                int limit = (user.Id == 0)
                    ? ConfigHelper.VinSearchLimit
                    : (user.VinSearchLimitCounter > 0 && user.VinSearchLimitDate > DateTime.Now)
                        ? user.VinSearchLimitCounter
                        : ConfigHelper.VinSearchLimitRegistered;
                var cnt = _db.VinSearchHistories.Count(i =>
                    (i.UserId == user.Id || (i.UserId == null && user.Id == 0)) && i.IP == user.IP && i.Date == today && i.Vin != vin);
                if (cnt >= limit)
                    return false;
            }

            return true;
        }

        public bool Confirmation(string aGuid)
        {
            var guid = Guid.Parse(aGuid);
            var dbUser = _db.Users.FirstOrDefault(i => i.Guid == guid);
            if (dbUser == null) return false;

            dbUser.IsAccepted = true;
            _db.SaveChanges();
            return true;

        }

        public void ChangeCurrentClient(User user)
        {
            var dbUser = _db.Users.First(i => i.Id == user.Id);
            dbUser.CurrentPresentationId = user.CurrentPresenter.Id;
            _db.SaveChanges();
        }

        public User GetUser(string userLogin)
        {
            if (string.IsNullOrEmpty(userLogin))
                return null;
            var dbUser = _db.Users.Include(i=>i.Configuration).Include(i => i.Addresses).Include(i => i.Presentations)
                .FirstOrDefault(i => i.Login == userLogin || i.PhoneMobile == userLogin);
            if (dbUser == null) return null;
            var user = _mapper.Map<User>(dbUser);

            LoadClientsList(user);
           
            user.CurrentPresenter = user.Presenters.FirstOrDefault(i => i.Id == dbUser.CurrentPresentationId);

            Log.DebugFormat("Set CurrentClient: Id {0}, result: {1}", dbUser.CurrentPresentationId, user.CurrentPresenter?.Id);
            if (user.CurrentPresenter == null && user.Presenters.Count > 0)
                user.CurrentPresenter = user.Presenters[0];
            foreach (var client in user.Presenters)
            {
                Log.Debug($"Loaded client for: {userLogin} - {client.Id}, {client.Client?.Name}, {client.IsManaged}");
            }
            user.Presenters = user.Presenters.OrderBy(i => i.Client?.Name).ToList();
            return user;
        }

        private void LoadClientsList(User user)
        {

            var presenters = user.Presenters;
            var clientString = string.Join(",", presenters.Select(i => i.ClientId.ToString()));

            var clients = string.IsNullOrEmpty(clientString) ? new List<Client>() : _clientRepository.GetClientsList(clientString);
            foreach (var presenter in presenters)
            {
                presenter.Client = clients.FirstOrDefault(i => i.Id == presenter.ClientId);
            }

            if (!string.IsNullOrEmpty(user.ExternalSystemCode))
            {
                clients = string.IsNullOrEmpty(clientString) ? new List<Client>() : _clientRepository.GetManagedClientsList(user.ExternalSystemCode);
                foreach (var client in clients)
                {
                    presenters.Add(new ClientPresenter
                    {
                        Client = client,
                        ClientId = client.Id,
                        IsAccepted = true,
                        IsManaged = true,
                        User = user,
                        Roles = 0xFFFF,
                    });
                }
            }
        }

        public IQueryable<User> GetUsers(UserFilter filter)
        {
            var query = _db.Users.AsQueryable();

            if (!string.IsNullOrEmpty(filter.FirstName))
                query = query.Where(i => i.FirstName.Contains(filter.FirstName));
            if (!string.IsNullOrEmpty(filter.LastName))
                query = query.Where(i => i.LastName.Contains(filter.LastName));
            if (!string.IsNullOrEmpty(filter.Login))
                query = query.Where(i => i.Login.Contains(filter.Login));
            //if (!string.IsNullOrEmpty(filter.ClientCode))
            //{
            //    var clientInfo = _db.vsspGetClientInfo(filter.ClientCode).FirstOrDefault();
            //    if (clientInfo != null)
            //        filter.ClientId = clientInfo.KagId;
            //}
            filter.ClientId = filter.ClientCode;
            if (filter.ClientId != null)
                query = query.Where(i => i.Presentations.Any(j => j.ClientId == filter.ClientId));
            if (filter.IsKeyRepresentative)
                query = query.Where(i =>
                    i.Presentations.Any(j => (j.Roles & (long)RepresentativeRole.KeyRepresentative) != 0));
            if (filter.IsAdmin)
                query = query.Where(i => (i.Roles & (long)UserRoles.Admin) != 0);
            if (filter.IsManager)
            {
                var code = 0L;
                //code += (long)UserRoles.CatalogManager;
                code += (long)UserRoles.RepresentativeManager;
                code += (long)UserRoles.VINRequestManager;
                query = query.Where(i => (i.Roles & code) != 0);
            }

            if (filter.IsRepresentativeManager)
            {
                const long code = (long)UserRoles.RepresentativeManager;
                query = query.Where(i => (i.Roles & code) != 0);
            }

            if (filter.IsVINRequestManager)
            {
                const long code = (long)UserRoles.VINRequestManager;
                query = query.Where(i => (i.Roles & code) != 0);
            }

            if (filter.IsBlocked.HasValue)
                query = query.Where(i => i.IsBlocked == filter.IsBlocked);

            if (filter.IsNotAccepted.HasValue)
                query = query.Where(i => i.IsAccepted == !filter.IsNotAccepted);

            var result = query.Select(i => new User
            {
                Id = i.Id,
                FirstName = i.FirstName,
                LastName = i.LastName,
                Status = i.Status,
                Login = i.Login,
                PhoneMobile = i.PhoneMobile,
                PhoneHome = i.PhoneHome,
                Roles = i.Roles,
                Guid = i.Guid,
                RegistrationDate = i.RegistrationDate,
                LastLogOnDate = i.LastLogOnDate,
                IsBlocked = i.IsBlocked,
                IsAccepted = i.IsAccepted
            });

            return result;
        }

        public List<VinSearchHistoryItem> GetVinSearchHistory(User user, VinHistoryFilter filter)
        {
            var histList = _db.VinSearchHistories.Where(i =>
                (i.UserId == user.Id || (i.UserId == null && user.Id == 0)) && i.Date >= filter.StartDate && i.Date <= filter.EndDate && i.IsSuccessful == true)
                .OrderByDescending(i => i.Date).Take(20);
            var result = _mapper.Map<List<VinSearchHistoryItem>>(histList);
            return result;

        }

        public string HashPassword(string password)
        {
            return password.HashSha1();
        }

        public bool IsUserLoginFree(string userLogin)
        {
            return !_db.Users.Any(i => i.Login == userLogin);
        }

        public void RemoveUser(User user)
        {
            var dbItem = _db.Users.FirstOrDefault(i => i.Login == user.Login);

            if (dbItem == null) return;

            foreach (var vin in _db.VINRequests.Where(i => i.ManagerId == dbItem.Id))
                vin.ManagerId = null;
            dbItem.CurrentPresentationId = null;
            _db.SaveChanges();

            AddUserToArchive(dbItem);

            foreach (var presenter in _db.ClientPresenters.Where(i => i.UserId == dbItem.Id))
                _db.ClientPresenters.Remove(presenter);
            _db.SaveChanges();

            _db.Users.Remove(dbItem);

            _db.SaveChanges();
        }

        private void AddUserToArchive(DbUser dbItem)
        {
            var userHistory = _mapper.Map<DbUserHistory>(dbItem);
            userHistory.Comment += dbItem.ToJson(new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

            _db.UsersHistory.Add(userHistory);
            _db.SaveChanges();
        }

        public int SaveUser(User user, bool createPersonalCard)
        {
            var dbUser = _db.Users.FirstOrDefault(i => i.Login == user.Login);

            if (user.Id == 0 && dbUser != null) return 0;

            if (dbUser == null)
            {
                dbUser = new DbUser { Password = HashPassword(user.Password), RegistrationDate = DateTime.Now };
                _db.Users.Add(dbUser);
            }
            else
            {
                // Обновление пароля
                if (!string.IsNullOrWhiteSpace(user.Password))
                    dbUser.Password = HashPassword(user.Password);
            }

            _mapper.Map(user, dbUser);
            _db.SaveChanges();

            return dbUser.Id;
        }

        public void UpdateUserPassword(string login, string password)
        {
            var dbUser = _db.Users.FirstOrDefault(i => i.Login == login || i.PhoneMobile == login);
            if (dbUser == null) return;

            dbUser.Password = HashPassword(password);
            _db.SaveChanges();
        }
    }
}
