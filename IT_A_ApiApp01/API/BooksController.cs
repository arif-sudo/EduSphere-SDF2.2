using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using IT_A_ApiApp01.Data;
using IT_A_ApiApp01.Models;

namespace IT_A_ApiApp01.API
{
    public class BooksController : ApiController
    {
        private BookContext db = new BookContext();

        // GET: api/Books
        public IEnumerable<Books> GetBooks()
        {
            return db.Books.ToList();
        }

        // GET: api/Books/5
        [ResponseType(typeof(Books))]
        public IHttpActionResult GetBooks(int id)
        {
            Books books = db.Books.Find(id);
            if (books == null)
            {
                return NotFound();
            }

            return Ok(books);
        }

        // PUT: api/Books/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBooks(int id, Books books)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != books.Id)
            {
                return BadRequest();
            }

            db.Entry(books).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BooksExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Books
        [ResponseType(typeof(Books))]
        public IHttpActionResult PostBooks(Books books)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Books.Add(books);
            db.SaveChanges();
                        return CreatedAtRoute("DefaultApi", new { id = books.Id }, books);
        }

        // DELETE: api/Books/5
        [ResponseType(typeof(Books))]
        public IHttpActionResult DeleteBooks(int id)
        {
            Books books = db.Books.Find(id);
            if (books == null)
            {
                return NotFound();
            }

            db.Books.Remove(books);
            db.SaveChanges();

            return Ok(books);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BooksExists(int id)
        {
            return db.Books.Count(e => e.Id == id) > 0;
        }
    }
}