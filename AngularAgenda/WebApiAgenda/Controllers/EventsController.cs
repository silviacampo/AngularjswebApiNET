using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebApiAgenda.Models;

namespace WebApiAgenda.Controllers
{
    public class AeventsController : ApiController
    {
        private agenda2Entities db = new agenda2Entities();

        // GET api/Events
        public IEnumerable<aevent> Getaevents()
        {
            return db.aevents.AsEnumerable();
        }

        // GET api/Events/5
        public aevent Getaevent(int id)
        {
            aevent aevent = db.aevents.First(c => c.id == id);
            if (aevent == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return aevent;
        }

        // PUT api/Events/5
        public HttpResponseMessage Putaevent(int id, aevent aevent)
        {
            if (ModelState.IsValid && id == aevent.id)
            {
                //db.Entry(aevent).State = System.Data.Entity.EntityState.Modified;

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

        // POST api/Events
        public HttpResponseMessage Postaevent(aevent aevent)
        {
            if (ModelState.IsValid)
            {
                db.aevents.AddObject(aevent);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, aevent);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = aevent.id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Events/5
        public HttpResponseMessage Deleteaevent(int id)
        {
            aevent aevent = db.aevents.First(c=>c.id == id);
            if (aevent == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.aevents.DeleteObject(aevent);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, aevent);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}