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
using efDemo.Models;

namespace efDemo.Controllers
{
    public class MiceController : ApiController
    {
        private efContext db = new efContext();

        // GET: api/Mice
        public IQueryable<Mouse> GetMice()
        {
            return db.Mice;
        }

        // GET: api/Mice/5
        [ResponseType(typeof(Mouse))]
        public async Task<IHttpActionResult> GetMouse(int id)
        {
            Mouse mouse = await db.Mice.FindAsync(id);
            if (mouse == null)
            {
                return NotFound();
            }

            return Ok(mouse);
        }

        // PUT: api/Mice/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMouse(int id, Mouse mouse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mouse.MouseId)
            {
                return BadRequest();
            }

            db.Entry(mouse).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MouseExists(id))
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

        // POST: api/Mice
        [ResponseType(typeof(Mouse))]
        public async Task<IHttpActionResult> PostMouse(Mouse mouse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Mice.Add(mouse);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = mouse.MouseId }, mouse);
        }

        // DELETE: api/Mice/5
        [ResponseType(typeof(Mouse))]
        public async Task<IHttpActionResult> DeleteMouse(int id)
        {
            Mouse mouse = await db.Mice.FindAsync(id);
            if (mouse == null)
            {
                return NotFound();
            }

            db.Mice.Remove(mouse);
            await db.SaveChangesAsync();

            return Ok(mouse);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MouseExists(int id)
        {
            return db.Mice.Count(e => e.MouseId == id) > 0;
        }
    }
}