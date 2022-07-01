using Mono02.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono02.Repository.Common
{
    public interface ICarDealershipRepository
    {
        List<CarDealership> GetCarDealerShip();
        CarDealership Get(System.Guid id);
        CarDealership PostCarDealership(CarDealership C);
        CarDealership Putt(System.Guid id, CarDealership C);
        bool Delete(System.Guid id);

    }
}
