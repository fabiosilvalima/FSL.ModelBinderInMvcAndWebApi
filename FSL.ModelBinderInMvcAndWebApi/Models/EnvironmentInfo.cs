using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FSL.ModelBinderInMvcAndWebApi.Models
{
    public class EnvironmentInfo
    {
        public string UserId { get; set; }

        public bool IsLogged
        {
            get
            {
                return !string.IsNullOrEmpty(UserId);
            }
        }

        public string RequestedUrl { get; set; }
    }
}