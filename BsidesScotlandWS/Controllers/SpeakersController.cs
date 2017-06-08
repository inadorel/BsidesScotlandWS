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
    public class SpeakersController : ApiController
    {
        private BsidesScotlandWSContext db = new BsidesScotlandWSContext();

        // GET: api/Speakers
        public IQueryable<Speaker> GetSpeakers()
        {
            return db.Speakers;
        }

        // GET: api/Speakers/5
        [ResponseType(typeof(Speaker))]
        public async Task<IHttpActionResult> GetSpeaker(int id)
        {
            Speaker speaker = await db.Speakers.FindAsync(id);
            if (speaker == null)
            {
                return NotFound();
            }

            return Ok(speaker);
        }

        // PUT: api/Speakers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSpeaker(int id, Speaker speaker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != speaker.SpeakerId)
            {
                return BadRequest();
            }

            db.Entry(speaker).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpeakerExists(id))
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

        // POST: api/Speakers
        [ResponseType(typeof(Speaker))]
        public async Task<IHttpActionResult> PostSpeaker(Speaker speaker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Speakers.Add(speaker);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = speaker.SpeakerId }, speaker);
        }

        // DELETE: api/Speakers/5
        [ResponseType(typeof(Speaker))]
        public async Task<IHttpActionResult> DeleteSpeaker(int id)
        {
            Speaker speaker = await db.Speakers.FindAsync(id);
            if (speaker == null)
            {
                return NotFound();
            }

            db.Speakers.Remove(speaker);
            await db.SaveChangesAsync();

            return Ok(speaker);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SpeakerExists(int id)
        {
            return db.Speakers.Count(e => e.SpeakerId == id) > 0;
        }
    }
}