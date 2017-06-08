using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BsidesScotlandWS.Models;

namespace BsidesScotlandWS.Controllers
{
    public class VolunteersController : ApiController
    {
        private BsidesScotlandWSContext db = new BsidesScotlandWSContext();

        // GET: api/Volunteers
        public IQueryable<Volunteer> GetVolunteers()
        {
            return db.Volunteers;
        }

        // GET: api/Volunteers/5
        [ResponseType(typeof(Volunteer))]
        public async Task<IHttpActionResult> GetVolunteer(int id)
        {
            Volunteer volunteer = await db.Volunteers.FindAsync(id);
            if (volunteer == null)
            {
                return NotFound();
            }

            return Ok(volunteer);
        }

        // PUT: api/Volunteers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVolunteer(int id, Volunteer volunteer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != volunteer.VolunteerId)
            {
                return BadRequest();
            }

            db.Entry(volunteer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VolunteerExists(id))
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

        // POST: api/Volunteers
        [ResponseType(typeof(Volunteer))]
        public async Task<IHttpActionResult> PostVolunteer(Volunteer volunteer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Volunteers.Add(volunteer);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = volunteer.VolunteerId }, volunteer);
        }

        // DELETE: api/Volunteers/5
        [ResponseType(typeof(Volunteer))]
        public async Task<IHttpActionResult> DeleteVolunteer(int id)
        {
            Volunteer volunteer = await db.Volunteers.FindAsync(id);
            if (volunteer == null)
            {
                return NotFound();
            }

            db.Volunteers.Remove(volunteer);
            await db.SaveChangesAsync();

            return Ok(volunteer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VolunteerExists(int id)
        {
            return db.Volunteers.Count(e => e.VolunteerId == id) > 0;
        }
    }
}