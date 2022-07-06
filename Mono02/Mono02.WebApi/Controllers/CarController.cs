using Mono02.Common;
using Mono02.Model;
using Mono02.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Mono02.WebApi.Controllers
{
    public class CarController : ApiController
    {
        [HttpGet]
        [Route("Car")]
        public async Task<HttpResponseMessage> GetCar(int newRpp, int pageNumber, string orderBy, string sortOrder, string search, int sMax, int sMin, string sName)
        {

            Paging P = new Paging(newRpp, pageNumber);
            Sorting S = new Sorting(orderBy, sortOrder); 
            SearchFilter F = new SearchFilter(search);
            BetweenFilter B = new BetweenFilter(sMin, sMax, sName);

            CarService result = new CarService();
            List<Car> retrn = await result.GetCarAsync(P,S,F,B);

            List<CarRest> retrn2 = new List<CarRest>();

            if (retrn.Count > 0)
            {
                foreach (Car c in retrn)
                {
                    retrn2.Add(new CarRest(c.carName, c.carPrice, c.carMileage));
                }
                return Request.CreateResponse(HttpStatusCode.OK, retrn2);
                
            }

          
            else
            { return Request.CreateResponse(HttpStatusCode.NotFound, "Error"); }
        }


        [HttpGet]
        [Route("GetCar")]
        public async Task<HttpResponseMessage> Get(System.Guid id)
        {
            CarService result = new CarService();
            Car retrn = await result.GetAsync(id);
            CarRest retrn2 = new CarRest(retrn.carName, retrn.carPrice, retrn.carMileage);

            if (retrn2 == null)
            { return Request.CreateResponse(HttpStatusCode.NotFound, "ID doesn't exist"); }

            else
            { return Request.CreateResponse(HttpStatusCode.OK, retrn2); }
        }


        [HttpPost]
        [Route("AddCar")]
        public async  Task<HttpResponseMessage> PostCarDealership(Car C)
        {
            CarService result = new CarService();
            Car retrn = await result.AddCarAsync(C);
            CarRest retrn2 = new CarRest(retrn.carName, retrn.carPrice, retrn.carMileage);

            if (retrn2 == null)
            { return Request.CreateResponse(HttpStatusCode.NotFound, "ID already exists"); }

            else
            { return Request.CreateResponse(HttpStatusCode.OK, retrn2); }
        }


        [HttpPut]
        [Route("UpdateCar")]

        public async Task<HttpResponseMessage> Putt(System.Guid id, [FromBody] Car C)
        {
            CarService result = new CarService();
            Car retrn = await result.PuttAsync(id, C);
            CarRest retrn2 = new CarRest(retrn.carName, retrn.carPrice, retrn.carMileage);

            if (retrn2 == null)
            { return Request.CreateResponse(HttpStatusCode.NotFound, "ID doesn't exist"); }

            else
            { return Request.CreateResponse(HttpStatusCode.OK, retrn2); }

        }


        [HttpDelete]
        [Route("DeleteCar")]

        public async Task<HttpResponseMessage> Delete(System.Guid id)
        {

            CarService result = new CarService();
            bool retrn = await result.DeleteAsync(id);

            if (retrn == false)
            { return Request.CreateResponse(HttpStatusCode.NotFound, "ID doesn't exist"); }

            else
            { return Request.CreateResponse(HttpStatusCode.OK, "Deleted"); }
        }




    }
}