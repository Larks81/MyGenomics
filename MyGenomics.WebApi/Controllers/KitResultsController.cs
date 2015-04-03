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
        [Authorize(Roles = "customer")]
        public IEnumerable<string> Get()
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var customClaimValue = principal.Claims.Where(c => c.Type == ClaimTypes.Role).Single().Value;

            return new List<string>() { "ciao", "miao", "bao" };
        }

        
    }
}
