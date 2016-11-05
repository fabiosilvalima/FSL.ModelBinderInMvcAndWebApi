namespace FSL.ModelBinderInMvcAndWebApi.Binders
{
    public class EnvironmentInfoModelBinder : System.Web.Mvc.IModelBinder, System.Web.Http.ModelBinding.IModelBinder
    {
        /// <summary>
        /// MVC version
        /// </summary>
        /// <param name="controllerContext"></param>
        /// <param name="bindingContext"></param>
        /// <returns></returns>
        public object BindModel(System.Web.Mvc.ControllerContext controllerContext,
            System.Web.Mvc.ModelBindingContext bindingContext)
        {
            var info = new Models.EnvironmentInfo();
            info.RequestedUrl = controllerContext.RequestContext.HttpContext.Request.Url.ToString();
            info.UserId = GetLoggedUser();

            // you also can get form/request properties

            return info;
        }

        /// <summary>
        /// WEB API version
        /// </summary>
        /// <param name="actionContext"></param>
        /// <param name="bindingContext"></param>
        /// <returns></returns>
        public bool BindModel(System.Web.Http.Controllers.HttpActionContext actionContext,
            System.Web.Http.ModelBinding.ModelBindingContext bindingContext)
        {
            var info = new Models.EnvironmentInfo();
            info.RequestedUrl = actionContext.Request.RequestUri.ToString();
            info.UserId = GetLoggedUser();

            // you also can get form/request properties

            bindingContext.Model = info;

            return true;
        }

        private string GetLoggedUser()
        {
            //just a sample
            return "3242423423";
        }
    }
}