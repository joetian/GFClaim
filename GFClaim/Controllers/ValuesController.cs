using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GFClaim.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] {"PUBLISHED!@ feature1 Branch after merge feature1 and edit master", "first name", "peter", "Last Name", "John" };
        }


    }
}
