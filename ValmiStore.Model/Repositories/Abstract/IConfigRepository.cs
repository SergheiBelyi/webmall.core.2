using ValmiStore.Model.Entities.Configuration;
using ValmiStore.Model.Entities.Configuration.Features;

namespace Webmall.Model.Repositories.Abstract
{
    public interface IConfigRepository
    {
        EmailConfig GetEmailConfig();

        Features GetFeatures();
    }
}
