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
    public class AccountsCurrentYearController : ApiController
    {
        private BudgetContext db = new BudgetContext();

        // GET: api/AccountsCurrentYear
        public IQueryable<AccountsCurrentYear> GetAccountsCurrentYears()
        {
            return db.AccountsCurrentYears;
        }

        //// GET: api/AccountsCurrentYear/5
        //[ResponseType(typeof(AccountsCurrentYear))]
        //public IHttpActionResult GetAccountsCurrentYear(string id)
        //{
        //    AccountsCurrentYear accountsCurrentYear = db.AccountsCurrentYears.Find(id);
        //    if (accountsCurrentYear == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(accountsCurrentYear);
        //}

        //// PUT: api/AccountsCurrentYear/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutAccountsCurrentYear(string id, AccountsCurrentYear accountsCurrentYear)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != accountsCurrentYear.Subcategory)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(accountsCurrentYear).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AccountsCurrentYearExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/AccountsCurrentYear
        //[ResponseType(typeof(AccountsCurrentYear))]
        //public IHttpActionResult PostAccountsCurrentYear(AccountsCurrentYear accountsCurrentYear)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.AccountsCurrentYears.Add(accountsCurrentYear);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (AccountsCurrentYearExists(accountsCurrentYear.Subcategory))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = accountsCurrentYear.Subcategory }, accountsCurrentYear);
        //}

        //// DELETE: api/AccountsCurrentYear/5
        //[ResponseType(typeof(AccountsCurrentYear))]
        //public IHttpActionResult DeleteAccountsCurrentYear(string id)
        //{
        //    AccountsCurrentYear accountsCurrentYear = db.AccountsCurrentYears.Find(id);
        //    if (accountsCurrentYear == null)
        //    {
        //        return NotFound();
        //    }

        //    db.AccountsCurrentYears.Remove(accountsCurrentYear);
        //    db.SaveChanges();

        //    return Ok(accountsCurrentYear);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AccountsCurrentYearExists(string id)
        {
            return db.AccountsCurrentYears.Count(e => e.Subcategory == id) > 0;
        }
    }
}