using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using FSL.ModelBinderInMvcAndWebApi.Models;

namespace FSL.ModelBinderInMvcAndWebApi.Services.Controllers
{
    public class BaseApiController : ApiController, IEnvironmentInfoController
    {
        public EnvironmentInfo GetEnvinromentInfo()
        {
            return new EnvironmentInfo()
            {
                UserId = "32423423432",// get authenticated user id 
                RequestedUrl = Request.RequestUri.ToString()
            };
        }
    }
}