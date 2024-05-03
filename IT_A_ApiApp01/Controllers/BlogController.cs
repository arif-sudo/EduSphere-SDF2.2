using IT_A_ApiApp01.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IT_A_ApiApp01.Controllers
{
    public class BlogController : Controller
    {
       
        // GET: Blog
        public async Task<ActionResult> Index()
        {
            // Bypassing SSL certificate validation
            // !Not recommended for production code,it can be useful for testing purposes
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            HttpClient client = new HttpClient(handler);
            HttpResponseMessage response = await client.GetAsync("https://localhost:44387/api/blogs");

            if (response.IsSuccessStatusCode)
            {
                var blogs = await response.Content.ReadAsAsync<IEnumerable<Blog>>();
                return View(blogs);
            }
            else {
                // handle error
                return View("Error");
            }
        }
        public ActionResult Create()
        {
            return View();
        }
        // POST: Blog/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Blog blog)
        {
            if (ModelState.IsValid)
            {
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

                // Save the blog to the database or perform necessary actions
                using (var client = new HttpClient(handler))
                {
                    var json = JsonConvert.SerializeObject(blog);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    // Post the JSON data to the API endpoint
                    var response = await client.PostAsync("https://localhost:44387/api/blogs", content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Redirect to a success page or another action
                        return RedirectToAction("Index", "Blog");
                    }
                    else
                    {
                        // If the request was not successful, handle the error
                        ViewBag.Error = "Failed to create blog. Please try again.";
                        return View(blog);
                    }
                }
            }
            // If the model state is not valid, redisplay the form with validation errors
            return View(blog);
        }
    }
}