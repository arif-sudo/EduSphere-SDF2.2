using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using IT_A_ApiApp01.Data;
using IT_A_ApiApp01.Models;

namespace IT_A_ApiApp01.Controllers
{
    public class UserController : Controller
    {
        private UserContext db = new UserContext();

        // GET: User
        public async Task<ActionResult> Index()
        {
            // Bypassing SSL certificate validation
            // !Not recommended for production code,it can be useful for testing purposes
            // This is API version, we make a GET Request to the users API endpoint
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

        // GET: User | Normal version
        //public ActionResult Index()
        //{
        //    return View(db.users.ToList());
        //}

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,Email,Password")] Users users)
        {
            if (ModelState.IsValid)
            {
                Users user = db.users.SingleOrDefault(u => u.UserName == users.UserName);
                if (user != null)
                {
                    TempData["WarningMessage"] = "A user with this username already exists. Please choose a different username";
                    return RedirectToAction("Index");
                }

                users.Password = BCrypt.Net.BCrypt.HashPassword(users.Password, 7);

                db.users.Add(users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(users);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,Email,Password")] Users users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(users);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Users users = db.users.Find(id);
            db.users.Remove(users);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
