using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Runtime.InteropServices;
using Mono02.Model;
using Mono02.Service;

namespace Mono02.WebApi.Controllers
{
   
    public class CarDealershipController : ApiController
    {
        [HttpGet]
        [Route("CarDealership")]
        public HttpResponseMessage GetCarDealerShip()
        {
            CarDealershipService result = new CarDealershipService();
            List<CarDealership> retrn = result.GetCarDealership();

            if (retrn == null)
                { return Request.CreateResponse(HttpStatusCode.NotFound, "Error"); }

            else 
                { return Request.CreateResponse(HttpStatusCode.OK, retrn); }    
        }
        

        [HttpGet]
        [Route("GetCarDealership")]
        public HttpResponseMessage Get(System.Guid id)
        {
            CarDealershipService result = new CarDealershipService();
            CarDealership retrn = result.Get(id);

            if (retrn == null)
            { return Request.CreateResponse(HttpStatusCode.NotFound, "ID doesn't exist"); }

            else
            { return Request.CreateResponse(HttpStatusCode.OK, retrn); }
        }


        [HttpPost]
        [Route("AddCarDealership")]
        public HttpResponseMessage PostCarDealership(CarDealership C)
        {
            CarDealershipService result = new CarDealershipService();
            CarDealership retrn = result.PostCarDealership(C);

            if (retrn == null)
            { return Request.CreateResponse(HttpStatusCode.NotFound, "ID already exists"); }

            else
            { return Request.CreateResponse(HttpStatusCode.OK, retrn); }
        }


        [HttpPut]
        [Route("UpdateCarDealership")]

        public HttpResponseMessage Putt(System.Guid id, [FromBody] CarDealership C)
        {
            CarDealershipService result = new CarDealershipService();
            CarDealership retrn = result.Putt(id, C);

            if (retrn == null)
            { return Request.CreateResponse(HttpStatusCode.NotFound, "ID doesn't exist"); }

            else
            { return Request.CreateResponse(HttpStatusCode.OK, retrn); }

        }


        [HttpDelete]
        [Route("DeleteCarDealership")]

        public HttpResponseMessage Delete(System.Guid id)
        {

            CarDealershipService result = new CarDealershipService();
            bool retrn = result.Delete(id);

            if (retrn == false)
            { return Request.CreateResponse(HttpStatusCode.NotFound, "ID doesn't exist"); }

            else
            { return Request.CreateResponse(HttpStatusCode.OK, "Deleted"); }
        }






    }//APi
}

