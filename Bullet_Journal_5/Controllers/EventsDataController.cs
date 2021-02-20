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
using Bullet_Journal_5.Models;

namespace Bullet_Journal_5.Controllers
{
    public class EventsDataController : ApiController
    {
        private BulletJournalDBcontext db = new BulletJournalDBcontext();

        // GET: api/EventsData
        public IQueryable<Event> GetEvents()
        {
            return db.Events;
        }

        // GET: api/EventsData/5
        [ResponseType(typeof(Event))]
        public IHttpActionResult GetEvent(int id)
        {
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return NotFound();
            }

            return Ok(@event);
        }

        // PUT: api/EventsData/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEvent(int id, Event @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @event.EventID)
            {
                return BadRequest();
            }

            db.Entry(@event).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
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

        // POST: api/EventsData
        [ResponseType(typeof(Event))]
        public IHttpActionResult PostEvent(Event @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Events.Add(@event);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = @event.EventID }, @event);
        }

        // DELETE: api/EventsData/5
        [ResponseType(typeof(Event))]
        public IHttpActionResult DeleteEvent(int id)
        {
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return NotFound();
            }

            db.Events.Remove(@event);
            db.SaveChanges();

            return Ok(@event);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventExists(int id)
        {
            return db.Events.Count(e => e.EventID == id) > 0;
        }
    }
}