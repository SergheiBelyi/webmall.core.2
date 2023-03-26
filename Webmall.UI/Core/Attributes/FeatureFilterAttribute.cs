using System;
using System.Linq;
using System.Web.Mvc;
using ValmiStore.Model.Entities.Configuration.Features;
using ViewRes;
using Webmall.Model;

namespace Webmall.UI.Core.Attributes
{
    public class FeatureFilterAttribute : ActionFilterAttribute
    {
        private readonly string _propertyName;
        private readonly string _featureTypeName;

        public FeatureFilterAttribute(Type featureType, string propertyName)
        {
            _featureTypeName = featureType.FullName;
            _propertyName = propertyName;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var featureConfigProperty = typeof(Features).GetProperties().SingleOrDefault(p => p.PropertyType.FullName == _featureTypeName);
            if (featureConfigProperty != null)
            {
                var featureConfig = featureConfigProperty.GetValue(ConfigHelper.FeaturesConfig);
                var property = featureConfig.GetType().GetProperties().SingleOrDefault(p => p.Name == _propertyName);
                if (property != null)
                {
                    var result = (bool) property.GetValue(featureConfig);
                    if (!result)
                    {
                        filterContext.Controller.TempData["Message"] = SharedResources.FeatureDisabled;
                        filterContext.Controller.TempData["Title"] = SharedResources.AccessDenied;
                        filterContext.RedirectToAction("Show", "Message");
                    }
                }
            } 
            
            base.OnActionExecuting(filterContext);
        }
    }
}