using System.Collections.Generic;
using System.Web.SessionState;
using Webmall.Model.Entities.User;

namespace Webmall.UI.Core.UserSession
{
    public class UserSessionStorage : Dictionary <string, UserSessions>
    {
        public void AddUserToActive(User user, string sessionId, HttpSessionState session)
        {
            if (user == null || session == null)
                return;
            sessionId = session.SessionID;
            if (ContainsKey(user.Login))
            {
                var sessions = this[user.Login];
                if (!sessions.ContainsKey(sessionId))
                    sessions.Add(sessionId, new UserSessionData { User = user, Session = session });
            }
            else
                Add(user.Login, new UserSessions { { sessionId, new UserSessionData { User = user, Session = session } } });
        }

        public void InvalidateUserForAllSessions(string login)
        {
            if (ContainsKey(login))
                Remove(login);
        }

        public bool IsUserActive(string login, string sessionId)
        {
            return ContainsKey(login) && (sessionId == null || this[login].ContainsKey(sessionId));
        }
    }
}