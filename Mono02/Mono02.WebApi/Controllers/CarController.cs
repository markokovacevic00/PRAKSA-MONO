using Mono02.Model;
using Mono02.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Mono02.WebApi.Controllers
{
    public class CarController : ApiController
    {
        [HttpGet]
        [Route("Car")]
        public HttpResponseMessage GetCar()
        {
            CarService result = new CarService();
            List<Car> retrn = result.GetCar();

            if (retrn == null)
            { return Request.CreateResponse(HttpStatusCode.NotFound, "Error"); }

            else
            { return Request.CreateResponse(HttpStatusCode.OK, retrn); }
        }


        [HttpGet]
        [Route("GetCar")]
        public HttpResponseMessage Get(System.Guid id)
        {
            CarService result = new CarService();
            Car retrn = result.Get(id);

            if (retrn == null)
            { return Request.CreateResponse(HttpStatusCode.NotFound, "ID doesn't exist"); }

            else
            { return Request.CreateResponse(HttpStatusCode.OK, retrn); }
        }


        [HttpPost]
        [Route("AddCar")]
        public HttpResponseMessage PostCarDealership(Car C)
        {
            CarService result = new CarService();
            Car retrn = result.AddCar(C);

            if (retrn == null)
            { return Request.CreateResponse(HttpStatusCode.NotFound, "ID already exists"); }

            else
            { return Request.CreateResponse(HttpStatusCode.OK, retrn); }
        }


        [HttpPut]
        [Route("UpdateCar")]

        public HttpResponseMessage Putt(System.Guid id, [FromBody] Car C)
        {
            CarService result = new CarService();
            Car retrn = result.Putt(id, C);

            if (retrn == null)
            { return Request.CreateResponse(HttpStatusCode.NotFound, "ID doesn't exist"); }

            else
            { return Request.CreateResponse(HttpStatusCode.OK, retrn); }

        }


        [HttpDelete]
        [Route("DeleteCar")]

        public HttpResponseMessage Delete(System.Guid id)
        {

            CarService result = new CarService();
            bool retrn = result.Delete(id);

            if (retrn == false)
            { return Request.CreateResponse(HttpStatusCode.NotFound, "ID doesn't exist"); }

            else
            { return Request.CreateResponse(HttpStatusCode.OK, "Deleted"); }
        }




    }
}