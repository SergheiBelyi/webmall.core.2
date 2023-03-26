﻿using System.Linq;
using System.Web.Mvc;

namespace Webmall.UI.Core.Attributes
{
    public class ValidateOnlyIncomingValuesAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var modelState = filterContext.Controller.ViewData.ModelState;
            var incomingValues = filterContext.Controller.ValueProvider;
            var keys = modelState.Keys.Where(x => !incomingValues.ContainsPrefix(x));
            foreach (var key in keys)
            {
                modelState[key].Errors.Clear();
            }
        }
    }
}