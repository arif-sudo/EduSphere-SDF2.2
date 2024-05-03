using IT_A_ApiApp01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IT_A_ApiApp01.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public async Task<ActionResult> Index()
        {
            // Bypassing SSL certificate validation
            // !Not recommended for production code,it can be useful for testing purposes
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

            HttpClient client = new HttpClient(handler);
            HttpResponseMessage response = await client.GetAsync("https://localhost:44387/api/users");

            if (response.IsSuccessStatusCode)
            {
                var users = await response.Content.ReadAsAsync<IEnumerable<Users>>();
                return View(users);
            }
            else
            {
                // handle error
                return View("Error");
            }
        }
    }
}