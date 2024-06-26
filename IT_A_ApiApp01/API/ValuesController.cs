﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IT_A_ApiApp01.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value " + id;
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
            return;
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
            return;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            return;
        }
    }
}
