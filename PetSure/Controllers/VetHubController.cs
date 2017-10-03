using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PetSure.Controllers
{
    public class GeoPoint
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class VetHubController : ApiController
    {
        public HttpResponseMessage Get([FromUri] int id)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, id);
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
