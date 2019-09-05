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
    public class KeyboardsController : ApiController
    {
        private efContext db = new efContext();

        // GET: api/Keyboards
        public IQueryable<Keyboard> GetKeyboards()
        {
            return db.Keyboards;
        }

        // GET: api/Keyboards/5
        [ResponseType(typeof(Keyboard))]
        public async Task<IHttpActionResult> GetKeyboard(int id)
        {
            Keyboard keyboard = await db.Keyboards.FindAsync(id);
            if (keyboard == null)
            {
                return NotFound();
            }

            return Ok(keyboard);
        }

        // PUT: api/Keyboards/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutKeyboard(int id, Keyboard keyboard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != keyboard.ID)
            {
                return BadRequest();
            }

            db.Entry(keyboard).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KeyboardExists(id))
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

        // POST: api/Keyboards
        [ResponseType(typeof(Keyboard))]
        public async Task<IHttpActionResult> PostKeyboard(Keyboard keyboard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Keyboards.Add(keyboard);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = keyboard.ID }, keyboard);
        }

        // DELETE: api/Keyboards/5
        [ResponseType(typeof(Keyboard))]
        public async Task<IHttpActionResult> DeleteKeyboard(int id)
        {
            Keyboard keyboard = await db.Keyboards.FindAsync(id);
            if (keyboard == null)
            {
                return NotFound();
            }

            db.Keyboards.Remove(keyboard);
            await db.SaveChangesAsync();

            return Ok(keyboard);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KeyboardExists(int id)
        {
            return db.Keyboards.Count(e => e.ID == id) > 0;
        }
    }
}