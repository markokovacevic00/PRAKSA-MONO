using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mono02.WebApi.Controllers
{
    public class CarRest
    {        public CarRest(string name, int price, int mileage)
        {
            carName = name;
            carPrice = price;
            carMileage = mileage;
        }
        public string carName;
        public int carPrice;
        public int carMileage;
    
    }
}