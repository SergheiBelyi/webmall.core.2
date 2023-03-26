using System;
using System.Web.SessionState;
using Webmall.Model;
using Webmall.Model.Entities.User;

namespace Webmall.UI.Core.UserSession
{
    /// <summary>
    /// Данные сессии пользователя 
    /// </summary>
    public class UserSessionData
    {
        private DateTime _nextCheckTime;
        private DateTime _lastAccessTime;
        private User _user;

        public User User
        {
            get { _lastAccessTime = DateTime.Now; return _user; }
            set
            {
                _user = value; 
                _lastAccessTime = DateTime.Now;
                _nextCheckTime = ConfigHelper.UserInvalidationPeriod > 0 ? _lastAccessTime.AddMinutes(ConfigHelper.UserInvalidationPeriod) : _lastAccessTime.AddDays(1);
            }
        }

        public DateTime LastAccessTime => _lastAccessTime;
        public DateTime LogTime { get; set; } = DateTime.Now;
        public bool NeedUserCheck => _nextCheckTime < DateTime.Now;
        public bool NeedUserRelogin { get; set; }
        public HttpSessionState Session { get; set; }
    }
}