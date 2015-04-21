using MyGenomics.Common.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MyGenomics.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class AuthorizeMultipleAttribute : AuthorizeAttribute
    {
        public AuthorizeMultipleAttribute(params UserType[] roles)
        {
            this.Roles = string.Join(",", roles.Select(r => ((int)r).ToString()));
        }
    }
    

}