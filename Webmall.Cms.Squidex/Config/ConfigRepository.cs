using AutoMapper;
using System.Reflection;
using System.Web;
using ValmiStore.Model.Entities.Configuration.Features;
using Webmall.Cms.Squidex.Config.Models.Email;
using Webmall.Cms.Squidex.Helpers;
using Webmall.Model;
using Webmall.Model.Repositories.Abstract;

namespace Webmall.Cms.Squidex.Config
{
    public class ConfigRepository : IConfigRepository
    {
        private readonly IMapper _mapper;
        private ClientManager _clientManager;

        private static readonly object Lock = new object();

        public ConfigRepository(IMapper mapper)
        {
            _mapper = mapper;
            _clientManager = ClientManagerFactory.Creator(ClientManagerType.Client);
        }

        public ValmiStore.Model.Entities.Configuration.EmailConfig GetEmailConfig()
        {
            var key = MethodBase.GetCurrentMethod().Name;
            return HttpRuntime.Cache.Get(key, Lock, () =>
            {
                var data = _clientManager.GetSingle<EmailConfig, EmailConfigData>();
                return _mapper.Map<ValmiStore.Model.Entities.Configuration.EmailConfig>(data);
            });
        }

        public Features GetFeatures()
        {
            return new Features();
        }

    }
}
