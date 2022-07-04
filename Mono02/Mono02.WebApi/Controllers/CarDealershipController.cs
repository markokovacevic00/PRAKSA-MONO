using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Runtime.InteropServices;
using Mono02.Model;
using Mono02.Service;
using System.Threading.Tasks;

namespace Mono02.WebApi.Controllers
{
   
    public class CarDealershipController : ApiController
    {
        [HttpGet]
        [Route("CarDealership")]
        public async Task<HttpResponseMessage> GetCarDealerShipAsync()
        {
            CarDealershipService result = new CarDealershipService();
            List<CarDealership> retrn = await result.GetCarDealershipAsync();

            List<CarDealershipRest> retrn2 = new List<CarDealershipRest>();

            if(retrn.Count > 0)
            {
                foreach(CarDealership cd in retrn)
                {
                    retrn2.Add(new CarDealershipRest(cd.cd_Name));
                }
                return Request.CreateResponse(HttpStatusCode.OK, retrn2);
            }

            else 
                { 
                return Request.CreateResponse(HttpStatusCode.NotFound, "Error");
            }
        }
        

        [HttpGet]
        [Route("GetCarDealership")]
        public async Task<HttpResponseMessage> GetAsync(System.Guid id)
        {
            CarDealershipService result = new CarDealershipService();
            CarDealership retrn = await result.GetAsync(id);

            CarDealershipRest retrn2 = new CarDealershipRest(retrn.cd_Name);

            if (retrn2 == null)
            { return Request.CreateResponse(HttpStatusCode.NotFound, "ID doesn't exist"); }

            else
            { return Request.CreateResponse(HttpStatusCode.OK, retrn2); }
        }


        [HttpPost]
        [Route("AddCarDealership")]
        public async Task<HttpResponseMessage> PostCarDealershipAsync(CarDealership C)
        {
            CarDealershipService result = new CarDealershipService();
            CarDealership retrn = await result.PostCarDealershipAsync(C);

            CarDealershipRest retrn2 = new CarDealershipRest(retrn.cd_Name);

            if (retrn2 == null)
            { return Request.CreateResponse(HttpStatusCode.NotFound, "ID already exists"); }

            else
            { return Request.CreateResponse(HttpStatusCode.OK, retrn2); }
        }


        [HttpPut]
        [Route("UpdateCarDealership")]

        public async Task<HttpResponseMessage> PuttAsync(System.Guid id, [FromBody] CarDealership C)
        {
            CarDealershipService result = new CarDealershipService();
            CarDealership retrn = await result.PuttAsync(id, C);
            CarDealershipRest retrn2 = new CarDealershipRest(retrn.cd_Name);

            if (retrn2 == null)
            { return Request.CreateResponse(HttpStatusCode.NotFound, "ID doesn't exist"); }

            else
            { return Request.CreateResponse(HttpStatusCode.OK, retrn2); }

        }


        [HttpDelete]
        [Route("DeleteCarDealership")]

        public async Task<HttpResponseMessage> DeleteAsync(System.Guid id)
        {

            CarDealershipService result = new CarDealershipService();
            bool retrn = await result.DeleteAsync(id);

            if (retrn == false)
            { return Request.CreateResponse(HttpStatusCode.NotFound, "ID doesn't exist"); }

            else
            { return Request.CreateResponse(HttpStatusCode.OK, "Deleted"); }
        }






    }//APi
    /*
    public class CarDealershipRest
    {
        public CarDealershipRest(System.Guid g, string name)
        {
            carDealershipId = g;
            carDealershipName = name;

        }
        public System.Guid carDealershipId;
        public string carDealershipName;
    }

    public class CarDealershipCreateRest { 
        public CarDealershipCreateRest(string name)
        {
            carDealershipCreateRestName = name;
        }
        string carDealershipCreateRestName;

    }
    */




}

