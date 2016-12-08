# FSL.ModelBinderInMvcAndWebApi

**Use of Model Binder in MVC and Web API**

The goal is to show how to create a custom Model Binder to use in both MVC and WEB API applications.

---

What is in the source code?
---

#### <i class="icon-file"></i> FSL.ModelBinderInMvcAndWebApi

- Visual Studio solution file;
- MVC and Web API application from .NET template;
- Classes for our solution; 

> **Remarks:**

> - I created the application using the Web Application template and I have checked MVC and Web API checkboxes. Visual Studio created a lot of files, views, scripts. I do not use them. Let's concentrate just the model binders.

---

What is the goal?
---

I have a lot information of environment like logged user id, requested url, frontend id, credentials, browser info and so on. Some those information may or not be in the fronend form*

* Will be available here in next version.

**Assumptions:**
- The model binder class must work in both MVC and Web Api controllers;
- I do not want to explicit call those environment info as a local variable.


Explaining...
---

**Binders/EnvironmentInfoModelBinder.cs**
```csharp
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
```

**Services/Controllers/PersonApiController.cs**
```csharp
[RoutePrefix("api/person")]
    public class PersonApiController : ApiController
    {
        [Route("")]
        public IHttpActionResult Get(Models.EnvironmentInfo environmentInfo)
        {
            var result = new
            {
                EnvironmentInfo = environmentInfo
            };

            return Ok(result);
        }
    }
```


**Controller/HomeController.cs**
```csharp
public class HomeController : Controller
    {
        public ActionResult Index(Models.EnvironmentInfo environmentInfo)
        {
            return View();
        }
    }
```

**Global.asax.cs**
```csharp
protected void Application_Start()
        {
            // MVC model binder version
                        ModelBinders.Binders.Add(typeof(Models.EnvironmentInfo), new Binders.EnvironmentInfoModelBinder());
                        
        }
```

**App_Start/WebApiConfig.cs**
```csharp
public static void Register(HttpConfiguration config)
        {
            // Web API model binder version

            config.BindParameter(typeof(Models.EnvironmentInfo), new Binders.EnvironmentInfoModelBinder());
            
        }
```

----------

References:
---

- ASP.NET MVC [here][1];

Licence:
---

- [Licence MIT][4]


  [1]: https://www.asp.net/mvc
