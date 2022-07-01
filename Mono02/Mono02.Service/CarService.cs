using Mono02.Model;
using Mono02.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono02.Service
{
    public class CarService
    {
        public List<Car> GetCar()
        {
            CarRepository retrn = new CarRepository();
            return retrn.GetCar();
        }
        public Car Get(System.Guid id)
        {
            CarRepository retrn = new CarRepository();
            return retrn.Get(id);
        }
        public Car AddCar(Car C)
        {
            CarRepository retrn = new CarRepository();
            return retrn.AddCar(C);
        }
        public Car Putt(System.Guid id, Car C)
        {
            CarRepository retrn = new CarRepository();
            return retrn.Putt(id, C);
        }
        public bool Delete(System.Guid id)
        {
            CarRepository retrn = new CarRepository();
            return retrn.Delete(id);
        }

    }
}
