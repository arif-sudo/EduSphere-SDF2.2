using IT_A_ApiApp01.Data;
using IT_A_ApiApp01.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IT_A_ApiApp01.API
{
    public class UsersController : ApiController
    {
        // GET: Users
        public IEnumerable<Users> Get()
        {
            UserContext context = new UserContext();
            using (context)
            {
                return context.users.ToList();
            }
        }
        public HttpResponseMessage Get(int id)
        {
            UserContext context = new UserContext();
            Users u1;
            using (context)
            {
                u1 = context.users.SingleOrDefault(u => u.Id == id);
            }
            if (u1 != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, u1);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "User with ID" + id.ToString() + " not found");
            }
        }
    }
}