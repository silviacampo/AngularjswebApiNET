using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.Entity;
//using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebApiAgenda.Models;
using System.Data.SQLite;
using System.Data.Entity.Infrastructure;

namespace WebApiAgenda.Controllers
{
    public class UsersController : ApiController
    {
        private agenda2Entities db = new agenda2Entities();

        // GET api/Users
        public IEnumerable<user> Getusers()
        {
            //using (var connection = new SQLiteConnection("data source=C:\\Users\\Silvia\\Desktop\\agenda2.sqlite"))
            //using (var command = connection.CreateCommand())
            //{
            //    command.CommandText = "create table Posts(Id int identity(1,1) primary key not null,Content varchar(1200))";

            //    connection.Open();
            //    command.ExecuteNonQuery();
            //}
            HttpContext.Current.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            return db.users.AsEnumerable();
        }

        // GET api/Users/5
        public user Getuser(int id)
        {
            user user = db.users.First(c=>c.id == id);
            if (user == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            HttpContext.Current.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            return user;
        }

        // PUT api/Users/5
        public HttpResponseMessage Putuser(int id, user user)
        {
            HttpContext.Current.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            if (ModelState.IsValid && id == user.id)
            {
                db.users.Attach(user);
                db.ObjectStateManager.ChangeObjectState(user, EntityState.Modified);
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Users
        public HttpResponseMessage Postuser(user user)
        {
            HttpContext.Current.Response.AppendHeader("Access-Control-Allow-Origin", "*");

            if (ModelState.IsValid)
            {
                db.users.AddObject(user);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, user);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = user.id }));

                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Users/5
        public HttpResponseMessage Deleteuser(int id)
        {
            HttpContext.Current.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            HttpContext.Current.Response.AppendHeader("Access-Control-Allow-Methods", "POST, GET, OPTIONS, PUT, DELETE");
            HttpContext.Current.Response.AppendHeader("Access-Control-Allow-Headers", "Content-Type");
            user user = db.users.First(c=>c.id == id);
            if (user == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.users.DeleteObject(user);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        // OPTIONS api/Users/5
        public HttpResponseMessage Optionsuser(int id)
        {            
            HttpContext.Current.Response.AppendHeader("access-control-allow-origin", "*");
            HttpContext.Current.Response.AppendHeader("access-control-allow-methods", "GET, POST, PUT, DELETE, OPTIONS");
            HttpContext.Current.Response.AppendHeader("access-control-allow-headers", "content-type, accept");
            HttpContext.Current.Response.AppendHeader("access-control-max-age", "10");
            HttpContext.Current.Response.AppendHeader("content-length", "0"); 
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        // OPTIONS api/Users
        public HttpResponseMessage Optionsuser()
        {
            HttpContext.Current.Response.AppendHeader("access-control-allow-origin", "*");
            HttpContext.Current.Response.AppendHeader("access-control-allow-methods", "GET, POST, PUT, DELETE, OPTIONS");
            HttpContext.Current.Response.AppendHeader("access-control-allow-headers", "content-type, accept");
            HttpContext.Current.Response.AppendHeader("access-control-max-age", "10");
            HttpContext.Current.Response.AppendHeader("content-length", "0");
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}