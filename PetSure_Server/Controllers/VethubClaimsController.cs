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
using PetSure_Server.Models;

namespace PetSure_Server.Controllers
{
    public class VethubClaimsController : ApiController
    {
        private PetSureEntities db = new PetSureEntities();

        public class VethubQuery
        {
            public int PolicyNumber { get; set; }
            public string PolicyHolder { get; set; }
            public string VetPractice { get; set; }
            public string PetName { get; set; }
            public string Status { get; set; }
            public int VethubRefNo { get; set; }
            public int ClaimRefNo { get; set; }
            public int ClaimNo { get; set; }
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
        }

        // GET: api/VethubClaims
        //public IQueryable<VethubClaim> GetVethubClaims()
        //{
        //    return db.VethubClaims;
        //}

        // GET: api/VethubClaims/5
        [ResponseType(typeof(VethubClaim))]
        public IHttpActionResult GetVethubClaim([FromUri] VethubQuery query)
        {
            DateTime date1 = new DateTime(2017, 1, 10);
            DateTime date2 = new DateTime(2017, 4, 10);
            var result = db.getVethubClaims(null, query.PolicyHolder, "test", "scooby", "in progress", 100, 200, 300, date1 , date2 ,0,10, "PetName").ToList();
            //var result = db.getAllVethubClaims().ToList();
            //VethubClaim vethubClaim = db.VethubClaims.Find(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // PUT: api/VethubClaims/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVethubClaim(int id, VethubClaim vethubClaim)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vethubClaim.PolicyNumber)
            {
                return BadRequest();
            }

            db.Entry(vethubClaim).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VethubClaimExists(id))
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

        // POST: api/VethubClaims
        [ResponseType(typeof(VethubClaim))]
        public IHttpActionResult PostVethubClaim(VethubClaim vethubClaim)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VethubClaims.Add(vethubClaim);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (VethubClaimExists(vethubClaim.PolicyNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = vethubClaim.PolicyNumber }, vethubClaim);
        }

        // DELETE: api/VethubClaims/5
        [ResponseType(typeof(VethubClaim))]
        public IHttpActionResult DeleteVethubClaim(int id)
        {
            VethubClaim vethubClaim = db.VethubClaims.Find(id);
            if (vethubClaim == null)
            {
                return NotFound();
            }

            db.VethubClaims.Remove(vethubClaim);
            db.SaveChanges();

            return Ok(vethubClaim);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VethubClaimExists(int id)
        {
            return db.VethubClaims.Count(e => e.PolicyNumber == id) > 0;
        }
    }
}