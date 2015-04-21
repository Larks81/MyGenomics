using MyGenomics.Attributes;
using MyGenomics.Common.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace MyGenomics.Controllers
{
    public class KitResultsController : ApiController
    {
        [AuthorizeMultiple(UserType.Administrator)]
        public IEnumerable<string> Get()
        {
            var principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var customClaimValue = principal.Claims.Where(c => c.Type == ClaimTypes.Role).Single().Value;

            return new List<string>() { "ciao", "miao", "bao" };
        }

        
    }
}
