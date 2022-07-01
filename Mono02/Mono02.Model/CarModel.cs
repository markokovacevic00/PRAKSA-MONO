using Mono02.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono02.Model
{
    public class Car : ICar
    {
        public Car(System.Guid id, string name, int price,int mileage)
        { 
            carId = id;
            carName = name;
            carPrice = price;
            carMileage = mileage;
        }
        public System.Guid carId;
       // public System.Guid carDealershipId;
        public string carName;
        public int carPrice;
        public int carMileage;
    }
}
