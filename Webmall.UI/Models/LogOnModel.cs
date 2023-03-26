using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using ViewRes;
using Webmall.UI.Core.Attributes;

namespace Webmall.UI.Models
{
    public class LogOnModel
    {
        [Required(ErrorMessageResourceName = "RequiredErrorMessage", ErrorMessageResourceType = typeof(SharedResources))]
        [DisplayNameEx("UserName", NameResourceType = typeof(SecurityResources))]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceName = "RequiredErrorMessage", ErrorMessageResourceType = typeof(SharedResources))]
        [DisplayNameEx("Password", NameResourceType = typeof(SecurityResources))]
        [JsonIgnore]
        public string Pass { get; set; }

        [DisplayNameEx("RememberMe", NameResourceType = typeof(SecurityResources))]
        public bool RememberMe { get; set; }

        public bool AllowBackend { get; set; }

        public string ReturnUrl { get; set; }

    }
}