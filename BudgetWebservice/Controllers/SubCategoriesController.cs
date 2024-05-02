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
    public class SubCategoriesController : ApiController
    {
        private BudgetContext db = new BudgetContext();

        // GET: api/SubCategories
        public IQueryable<SubCategory> GetSubCategories()
        {
            return db.SubCategories;
        }

        // GET: api/SubCategories/5
        [ResponseType(typeof(SubCategory))]
        public IHttpActionResult GetSubCategory(int id)
        {
            SubCategory subCategory = db.SubCategories.Find(id);
            if (subCategory == null)
            {
                return NotFound();
            }

            return Ok(subCategory);
        }

        // PUT: api/SubCategories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSubCategory(int id, SubCategory subCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subCategory.Id)
            {
                return BadRequest();
            }

            db.Entry(subCategory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubCategoryExists(id))
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

        // POST: api/SubCategories
        [ResponseType(typeof(SubCategory))]
        public IHttpActionResult PostSubCategory(SubCategory subCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SubCategories.Add(subCategory);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SubCategoryExists(subCategory.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = subCategory.Id }, subCategory);
        }

        // DELETE: api/SubCategories/5
        [ResponseType(typeof(SubCategory))]
        public IHttpActionResult DeleteSubCategory(int id)
        {
            SubCategory subCategory = db.SubCategories.Find(id);
            if (subCategory == null)
            {
                return NotFound();
            }

            db.SubCategories.Remove(subCategory);
            db.SaveChanges();

            return Ok(subCategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubCategoryExists(int id)
        {
            return db.SubCategories.Count(e => e.Id == id) > 0;
        }
    }
}