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
        public IEnumerable<VethubClaims> Get() {
            PetSureEntities entities = new PetSureEntities();
            {
                //var product = products.FirstOrDefault((p) => p.Id == id);
                var items = entities.VethubClaims;
                return items.ToList();

            }
        }
    }
}
