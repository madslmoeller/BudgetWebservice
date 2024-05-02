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
using BudgetWebservice;

namespace BudgetWebservice.Controllers
{
    public class LineItemsController : ApiController
    {
        private BudgetContext db = new BudgetContext();

        // GET: api/LineItems
        public IQueryable<LineItem> GetLineItems()
        {
            return db.LineItems;
        }

        // GET: api/LineItems/5
        [ResponseType(typeof(LineItem))]
        public IHttpActionResult GetLineItem(int id)
        {
            LineItem lineItem = db.LineItems.Find(id);
            if (lineItem == null)
            {
                return NotFound();
            }

            return Ok(lineItem);
        }

        // PUT: api/LineItems/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLineItem(int id, LineItem lineItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lineItem.Id)
            {
                return BadRequest();
            }

            db.Entry(lineItem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LineItemExists(id))
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

        // POST: api/LineItems
        [ResponseType(typeof(LineItem))]
        public IHttpActionResult PostLineItem(LineItem lineItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LineItems.Add(lineItem);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (LineItemExists(lineItem.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = lineItem.Id }, lineItem);
        }

        // DELETE: api/LineItems/5
        [ResponseType(typeof(LineItem))]
        public IHttpActionResult DeleteLineItem(int id)
        {
            LineItem lineItem = db.LineItems.Find(id);
            if (lineItem == null)
            {
                return NotFound();
            }

            db.LineItems.Remove(lineItem);
            db.SaveChanges();

            return Ok(lineItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LineItemExists(int id)
        {
            return db.LineItems.Count(e => e.Id == id) > 0;
        }
    }
}