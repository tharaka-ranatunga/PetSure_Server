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
            using (PetSureEntities entities = new PetSureEntities())
            {
                return entities.VethubClaims1.ToList();
            }
        }
    }
}
