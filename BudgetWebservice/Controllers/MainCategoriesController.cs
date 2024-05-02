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
    public class MainCategoriesController : ApiController
    {
        private BudgetContext db = new BudgetContext();

        // GET: api/MainCategories
        public IQueryable<MainCategory> GetMainCategories()
        {
            return db.MainCategories;
        }

        // GET: api/MainCategories/5
        [ResponseType(typeof(MainCategory))]
        public IHttpActionResult GetMainCategory(int id)
        {
            MainCategory mainCategory = db.MainCategories.Find(id);
            if (mainCategory == null)
            {
                return NotFound();
            }

            return Ok(mainCategory);
        }

        // PUT: api/MainCategories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMainCategory(int id, MainCategory mainCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mainCategory.Id)
            {
                return BadRequest();
            }

            db.Entry(mainCategory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MainCategoryExists(id))
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

        // POST: api/MainCategories
        [ResponseType(typeof(MainCategory))]
        public IHttpActionResult PostMainCategory(MainCategory mainCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MainCategories.Add(mainCategory);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MainCategoryExists(mainCategory.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mainCategory.Id }, mainCategory);
        }

        // DELETE: api/MainCategories/5
        [ResponseType(typeof(MainCategory))]
        public IHttpActionResult DeleteMainCategory(int id)
        {
            MainCategory mainCategory = db.MainCategories.Find(id);
            if (mainCategory == null)
            {
                return NotFound();
            }

            db.MainCategories.Remove(mainCategory);
            db.SaveChanges();

            return Ok(mainCategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MainCategoryExists(int id)
        {
            return db.MainCategories.Count(e => e.Id == id) > 0;
        }
    }
}