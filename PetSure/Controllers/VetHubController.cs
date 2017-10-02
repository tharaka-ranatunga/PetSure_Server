using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PetSure.Controllers
{
    //[Authorize]
    public class VetHubController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {

            PetSureEntities entities = new PetSureEntities();
            var product = entities.VethubClaims.FirstOrDefault(p => p.PolicyNumber == id);


            return "teer";

            //{
            //    var product = entities.VethubClaims.FirstOrDefault(p => p.PolicyNumber == amount);
            //    return product;

            //}
        }

        // POST api/values
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
