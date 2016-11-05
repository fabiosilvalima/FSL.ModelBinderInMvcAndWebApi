using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FSL.ModelBinderInMvcAndWebApi.Models;

namespace FSL.ModelBinderInMvcAndWebApi.Controllers
{
    public class BaseController : Controller, IEnvironmentInfoController
    {
        public EnvironmentInfo GetEnvinromentInfo()
        {
            return new EnvironmentInfo()
            {
                UserId = "32423423432",// get authenticated user id 
                RequestedUrl = Request.Url.ToString()
            };
        }
    }
}