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
    public class SponsorsController : ApiController
    {
        private BsidesScotlandWSContext db = new BsidesScotlandWSContext();

        // GET: api/Sponsors
        public IQueryable<Sponsor> GetSponsors()
        {
            return db.Sponsors;
        }

        // GET: api/Sponsors/5
        [ResponseType(typeof(Sponsor))]
        public async Task<IHttpActionResult> GetSponsor(int id)
        {
            Sponsor sponsor = await db.Sponsors.FindAsync(id);
            if (sponsor == null)
            {
                return NotFound();
            }

            return Ok(sponsor);
        }

        // PUT: api/Sponsors/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSponsor(int id, Sponsor sponsor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sponsor.SponsorId)
            {
                return BadRequest();
            }

            db.Entry(sponsor).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SponsorExists(id))
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

        // POST: api/Sponsors
        [ResponseType(typeof(Sponsor))]
        public async Task<IHttpActionResult> PostSponsor(Sponsor sponsor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sponsors.Add(sponsor);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = sponsor.SponsorId }, sponsor);
        }

        // DELETE: api/Sponsors/5
        [ResponseType(typeof(Sponsor))]
        public async Task<IHttpActionResult> DeleteSponsor(int id)
        {
            Sponsor sponsor = await db.Sponsors.FindAsync(id);
            if (sponsor == null)
            {
                return NotFound();
            }

            db.Sponsors.Remove(sponsor);
            await db.SaveChangesAsync();

            return Ok(sponsor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SponsorExists(int id)
        {
            return db.Sponsors.Count(e => e.SponsorId == id) > 0;
        }
    }
}