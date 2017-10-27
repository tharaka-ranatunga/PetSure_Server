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
using System.Web.Http.Cors;

namespace PetSure_Server.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VethubClaimsController : ApiController
    {
        private PetSureEntities db = new PetSureEntities();

        public class VethubQuery
        {
            public string policyNumber { get; set; }
            public string policyHolder { get; set; }
            public string vetPractice { get; set; }
            public string petName { get; set; }
            public string status { get; set; }
            public string vetHubRef { get; set; }
            public string claimRef { get; set; }
            public string claim { get; set; }
            public string dateSubmittedFrom { get; set; }
            public string dateSubmittedTo { get; set; }
            public string startIndex { get; set; }
            public string endIndex { get; set; }
            public string sort { get; set; }
        }

        // GET: api/VethubClaims
        //public IQueryable<VethubClaim> GetVethubClaims()
        //{
        //    return db.VethubClaims;
        //}

        // GET: api/VethubClaims/5
        // GET api/values/5
        [ResponseType(typeof(VethubClaim))]
        public IHttpActionResult Get(string id)
        {
            var result = db.getdetails(id);
            if (result == null)
            {
                return NotFound();
            }

            return Json(result);
        }

        [ResponseType(typeof(VethubClaim))]
        public IHttpActionResult GetVethubClaim([FromUri] VethubQuery query)
        {

            Nullable<int> policyNumber = null;
            Nullable<int> vethubRefNo = null;
            Nullable<int> claimRefNo = null;
            Nullable<int> claimNo = null;
            Nullable<int> startIndex = null;
            Nullable<int> endIndex = null;
            Nullable<DateTime> startDate = null;
            Nullable<DateTime> endDate = null;

            if (!string.IsNullOrWhiteSpace(query.policyNumber)) { policyNumber = Convert.ToInt32(query.policyNumber); }
            if (!string.IsNullOrWhiteSpace(query.vetHubRef)) { vethubRefNo = Convert.ToInt32(query.vetHubRef); }
            if (!string.IsNullOrWhiteSpace(query.claimRef)) { claimRefNo = Convert.ToInt32(query.claimRef); }
            if (!string.IsNullOrWhiteSpace(query.claim)) { claimNo = Convert.ToInt32(query.claim); }
            if (!string.IsNullOrWhiteSpace(query.startIndex)) { startIndex = Convert.ToInt32(query.startIndex); }
            if (!string.IsNullOrWhiteSpace(query.endIndex)) { endIndex = Convert.ToInt32(query.endIndex); }
            if (!string.IsNullOrWhiteSpace(query.dateSubmittedFrom)) { startDate = Convert.ToDateTime(query.dateSubmittedFrom); }
            if (!string.IsNullOrWhiteSpace(query.dateSubmittedTo)) { endDate = Convert.ToDateTime(query.dateSubmittedTo); }

            var result = db.getVethubClaims(policyNumber, query.policyHolder, query.vetPractice, query.petName, query.status, vethubRefNo, claimRefNo, claimNo, startDate , endDate ,startIndex ,endIndex, query.sort);
            if (result == null)
            {
                return NotFound();
            }

            return Json(result);
        }

        // PUT: api/VethubClaims/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVethubClaim(int id, VethubClaim vethubClaim)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vethubClaim.policyNumber)
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
                if (VethubClaimExists(vethubClaim.policyNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = vethubClaim.policyNumber }, vethubClaim);
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
            return db.VethubClaims.Count(e => e.policyNumber == id) > 0;
        }
    }
}