using System;
using ValmiStore.Model.Entities.Configuration;
using ValmiStore.Model.Entities.Configuration.Features;
using Webmall.Model.Repositories.Abstract;

namespace Webmall.Model.Test.Repositories
{
    public class ConfigRepository : IConfigRepository
    {
        public EmailConfig GetEmailConfig()
        {
            throw new NotImplementedException();
        }

        public Features GetFeatures()
        {
            throw new NotImplementedException();
        }
    }
}
