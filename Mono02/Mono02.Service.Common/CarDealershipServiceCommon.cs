using Mono02.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono02.Service.Common
{
    public interface ICarDealershipService
    {
        List<CarDealership> GetCarDealership();
        CarDealership Get(System.Guid id);
        CarDealership PostCarDealership(CarDealership C);
        CarDealership Putt(System.Guid id, CarDealership C);
        bool Delete(System.Guid id);
    }
}
