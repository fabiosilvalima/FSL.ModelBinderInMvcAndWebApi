using FSL.ModelBinderInMvcAndWebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FSL.ModelBinderInMvcAndWebApi.Binders
{
    public class EnvironmentInfoModelBinder : System.Web.Mvc.IModelBinder, System.Web.Http.ModelBinding.IModelBinder
    {
        /// <summary>
        /// versão MVC
        /// </summary>
        /// <param name="controllerContext"></param>
        /// <param name="bindingContext"></param>
        /// <returns></returns>
        public object BindModel(System.Web.Mvc.ControllerContext controllerContext,
            System.Web.Mvc.ModelBindingContext bindingContext)
        {
            var controller = controllerContext.Controller as IEnvironmentInfoController;

            return controller != null ? controller.GetEnvinromentInfo() : null;
        }

        /// <summary>
        /// versão WEB API
        /// </summary>
        /// <param name="actionContext"></param>
        /// <param name="bindingContext"></param>
        /// <returns></returns>
        public bool BindModel(System.Web.Http.Controllers.HttpActionContext actionContext,
            System.Web.Http.ModelBinding.ModelBindingContext bindingContext)
        {
            var controller = actionContext.ControllerContext.Controller as IEnvironmentInfoController;
            if (controller != null)
            {
                bindingContext.Model = controller.GetEnvinromentInfo();

                return true;
            }

            return false;
        }
    }
}