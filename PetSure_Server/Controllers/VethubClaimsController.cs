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
using System.Linq.Dynamic;
using System.Collections;

namespace PetSure_Server.Controllers
{
    public class VethubClaimsController : ApiController
    {
        public class VethubQuery
        {
            public string PolicyNumber { get; set; }
            public string PolicyHolder { get; set; }
            public string VetPractice { get; set; }
            public string PetName { get; set; }
            public string Status { get; set; }
            public string VethubRefNo { get; set; }
            public string ClaimRefNo { get; set; }
            public string ClaimNo { get; set; }
            public string Start { get; set; }
            public string End { get; set; }
        }


        private PetSureEntities db = new PetSureEntities();

        // GET: api/VethubClaims
        //public IQueryable<VethubClaim> GetVethubClaims()
        //{
        //    return db.VethubClaims;
        //}

        // GET: api/VethubClaims/5
        [ResponseType(typeof(VethubClaim))]
        public IHttpActionResult GetVethubClaim([FromUri] VethubQuery search)
        {
            IDictionary<int, string> numbers = new Dictionary<int, string>();

            //ArrayList numbers = new ArrayList();
            if (!string.IsNullOrWhiteSpace(search.PolicyNumber)){ numbers.Add(0, "PolicyNumber"); }
            if (!string.IsNullOrWhiteSpace(search.PolicyHolder)) { numbers.Add(1,"PolicyHolder"); }
            if (!string.IsNullOrWhiteSpace(search.PetName)) { numbers.Add(2, "PetName"); }
            if (!string.IsNullOrWhiteSpace(search.VetPractice)) { numbers.Add(3,"VetPractise"); }
            if (!string.IsNullOrWhiteSpace(search.Status)) { numbers.Add(4,"Status"); }
            if (!string.IsNullOrWhiteSpace(search.VethubRefNo)) { numbers.Add(5,"VethubRefNo"); }
            if (!string.IsNullOrWhiteSpace(search.ClaimRefNo)) { numbers.Add(6,"ClaimRefNo"); }
            if (!string.IsNullOrWhiteSpace(search.ClaimNo)) { numbers.Add(7,"ClaimNo"); }
            if (!string.IsNullOrWhiteSpace(search.Start)) { numbers.Add(8,"Start"); }
            if (!string.IsNullOrWhiteSpace(search.End)) { numbers.Add(9,"End"); }

            string query = string.Empty;

            foreach (KeyValuePair<int, string> entry in numbers )
            {
                query = query + entry.Value+"=@"+ entry.Key + " and ";
            }

            string name = query.Substring(0, query.Length - 5);

            System.Diagnostics.Debug.WriteLine(query);
            System.Diagnostics.Debug.WriteLine(name);



            var vethubClaim = db.VethubClaims.Where(name, Convert.ToInt32(search.PolicyNumber), search.PolicyHolder, search.PetName).ToList();

            if (vethubClaim == null)
            {
                return NotFound();
            }

            return Ok(vethubClaim);
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