using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IT_A_ApiApp01.Data;
using IT_A_ApiApp01.Models;

namespace IT_A_ApiApp01.Controllers
{
    public class BookListController : Controller
    {
        private BookContext db = new BookContext();

        // GET: BookList
        public ActionResult Index()
        {
            return View(db.Books.ToList());
        }

        // GET: BookList/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Books books = db.Books.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }
    }
}
