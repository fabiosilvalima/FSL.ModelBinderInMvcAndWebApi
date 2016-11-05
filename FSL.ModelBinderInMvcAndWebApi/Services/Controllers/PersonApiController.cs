using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using FSL.ModelBinderInMvcAndWebApi.Models;

namespace FSL.ModelBinderInMvcAndWebApi.Services.Controllers
{
    [RoutePrefix("api/person")]
    public class PersonApiController : BaseApiController
    {
        [Route("")]
        public IHttpActionResult Get(EnvironmentInfo environmentInfo)
        {
            var result = new
            {
                EnvironmentInfo = environmentInfo
            };

            return Ok(result);
        }
    }
}