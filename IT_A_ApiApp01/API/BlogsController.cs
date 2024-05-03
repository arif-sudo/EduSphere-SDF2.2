using IT_A_ApiApp01.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IT_A_ApiApp01.Controllers
{
    public class BlogsController : ApiController
    {
        public IEnumerable<Blog> Get()
        {
            BlogContext context = new BlogContext();
            using (context)
            {
                return context.blogs.ToList();
            }

        }
        public HttpResponseMessage Get(int id)
        {
            BlogContext context = new BlogContext();
            Blog b1;
            using (context)
            {
                b1 = context.blogs.SingleOrDefault(b => b.Id == id);
            }
            if (b1 != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, b1);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Blog with " + id.ToString() + " number not found");
            }
        }
        public HttpResponseMessage Post([FromBody]Blog blog)
        {
            try
            {
                BlogContext context = new BlogContext();
                using (context)
                {
                    context.blogs.Add(blog);
                    context.SaveChanges();
                }
                var message = Request.CreateResponse(HttpStatusCode.Created, blog);
                message.Headers.Location = new Uri(Request.RequestUri + blog.Id.ToString());
                return message;
            }
            catch (DataException de)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NoContent, de);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }   
        public HttpResponseMessage Put(int id, [FromBody] Blog updatedBlog)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }

                using (var context = new BlogContext())
                {
                    var existingBlog = context.blogs.Find(id);
                    if (existingBlog == null)
                    {       
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Blog with ID {id} not found.");
                    }

                    // Update existing blog with data from updatedBlog
                    existingBlog.Title = updatedBlog.Title;
                    existingBlog.Description = updatedBlog.Description;

                    context.SaveChanges();
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (DbUpdateException ex)
            {
                // Handle database update exception
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error occurred while updating the blog.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
