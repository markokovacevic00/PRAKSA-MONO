using Mono02.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono02.Repository.Common
{
    public interface ICarRepository
    { 
        List<Car> GetCar();
        Car Get(System.Guid id);
        Car AddCar(Car C);
        Car Putt(System.Guid id, Car C);
        bool Delete(System.Guid id);
    }
}
