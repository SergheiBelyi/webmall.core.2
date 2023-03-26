using System.Collections.Generic;
using System.Web.Mvc;
using Webmall.Model.Entities.Cms.Localization;
using Webmall.Model.Repositories.Abstract;

namespace Webmall.UI.Core
{
    public static class CmsHelper
    {
        private static ICmsRepository _cmsRepository;

        public static void Init(IDependencyResolver resolver)
        {
            _cmsRepository = (ICmsRepository)resolver.GetService(typeof(ICmsRepository));
        }

        public static List<Language> Languages => _cmsRepository?.GetLanguages();

        public static List<Language> GetLanguages()
        {
            return Languages;
        }
    }
}