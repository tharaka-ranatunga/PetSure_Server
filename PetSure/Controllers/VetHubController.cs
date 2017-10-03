using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PetSure.Controllers
{

    public class VetHubController : ApiController
    {
        public class VethubQuery {
            public int PolicyNumber{ get; set;}
            public string PolicyHolder{ get; set;}
            public string VetPractice{ get; set;}
            public string PetName{ get; set;}
            public string Status{ get; set;}
            public int VethubRefNo{ get; set;}
            public int ClaimRefNo{ get; set;}
            public int ClaimNo{ get; set;}
            public string Start{ get; set;}
            public string End{ get; set;}
        }

        private Boolean validate()
        {
            return true;
        }

        public HttpResponseMessage Get([FromUri] VethubQuery search)
        {
            Dictionary<string, string> Pairs = new Dictionary<string, string>();

            if (!String.IsNullOrWhiteSpace(search.PolicyHolder)){Pairs.Add("PolicyNumber", search.PolicyHolder);}
             
            if (!String.IsNullOrWhiteSpace(search.PolicyHolder))
            {
                Pairs.Add("PolicyHolder", search.PolicyHolder);
            }
            if (!String.IsNullOrWhiteSpace(search.PolicyHolder))
            {
                Pairs.Add("VetPractice", search.PolicyHolder);
            }
            if (!String.IsNullOrWhiteSpace(search.PolicyHolder))
            {
                Pairs.Add("PetName", search.PolicyHolder);
            }
            if (!String.IsNullOrWhiteSpace(search.PolicyHolder))
            {
                Pairs.Add("Status", search.PolicyHolder);
            }
            if (!String.IsNullOrWhiteSpace(search.PolicyHolder))
            {
                Pairs.Add("VethubRefNo", search.PolicyHolder);
            }
            if (!String.IsNullOrWhiteSpace(search.PolicyHolder))
            {
                Pairs.Add("ClaimRefNo", search.PolicyHolder);
            }
            if (!String.IsNullOrWhiteSpace(search.PolicyHolder))
            {
                Pairs.Add("ClaimNo", search.PolicyHolder);
            }
            if (!String.IsNullOrWhiteSpace(search.PolicyHolder))
            {
                Pairs.Add("Start", search.PolicyHolder);
            }
            if (!String.IsNullOrWhiteSpace(search.PolicyHolder))
            {
                Pairs.Add("End", search.PolicyHolder);
            }

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, search);
                return response;
        }

        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
