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
        private PetSureEntities db = new PetSureEntities(); //db connection

        public class VethubQuery   //defining query class for GetVethubClaim method
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

        [ResponseType(typeof(VethubClaim))]
        public IHttpActionResult Get([FromUri] string policyNum, [FromUri] string info) //get information of claims specifying policy number
        {
            if (info == "attachments")
            {
                return Json(db.getAttachments(policyNum)); //get attachment details and return in json format
            }
            else if (info == "claimdetails")
            {
                return Json(db.getDetails(policyNum)); //get claim details
            }
            else {
                return NotFound();
            }
        }
        
        [ResponseType(typeof(VethubClaim))]
        public IHttpActionResult GetVethubClaim([FromUri] VethubQuery query) //get search results with query parameters
        {

            Nullable<int> policyNumber = null; //defining nullable parameters
            Nullable<int> vethubRefNo = null;
            Nullable<int> claimRefNo = null;
            Nullable<int> claimNo = null;
            Nullable<int> startIndex = null;
            Nullable<int> endIndex = null;
            Nullable<DateTime> startDate = null;
            Nullable<DateTime> endDate = null;

            if (!string.IsNullOrWhiteSpace(query.policyNumber)) { policyNumber = Convert.ToInt32(query.policyNumber); } //assign query parameters if provided
            if (!string.IsNullOrWhiteSpace(query.vetHubRef)) { vethubRefNo = Convert.ToInt32(query.vetHubRef); }
            if (!string.IsNullOrWhiteSpace(query.claimRef)) { claimRefNo = Convert.ToInt32(query.claimRef); }
            if (!string.IsNullOrWhiteSpace(query.claim)) { claimNo = Convert.ToInt32(query.claim); }
            if (!string.IsNullOrWhiteSpace(query.startIndex)) { startIndex = Convert.ToInt32(query.startIndex); }
            if (!string.IsNullOrWhiteSpace(query.endIndex)) { endIndex = Convert.ToInt32(query.endIndex); }
            if (!string.IsNullOrWhiteSpace(query.dateSubmittedFrom)) { startDate = Convert.ToDateTime(query.dateSubmittedFrom); }
            if (!string.IsNullOrWhiteSpace(query.dateSubmittedTo)) { endDate = Convert.ToDateTime(query.dateSubmittedTo); }

            var result = db.getClaims(policyNumber, query.policyHolder, query.vetPractice, query.petName, query.status, vethubRefNo, claimRefNo, claimNo, startDate, endDate, startIndex, endIndex, query.sort); //get claims matching with provided information
            if (result == null)
            {
                return NotFound();
            }

            return Json(result);
        }
        
    }
}