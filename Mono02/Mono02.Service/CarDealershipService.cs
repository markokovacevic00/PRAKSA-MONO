using Mono02.Model;
using Mono02.Repository;
using Mono02.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono02.Service
{
    public class CarDealershipService : ICarDealershipService
    {
        public List<CarDealership> GetCarDealership()
        {
            CarDealershipRepository retrn = new CarDealershipRepository();
            return retrn.GetCarDealerShip();
        }
        public CarDealership Get(System.Guid id)
        {
            CarDealershipRepository retrn = new CarDealershipRepository();
            return retrn.Get(id);
        }
        public CarDealership PostCarDealership(CarDealership C)
        {
            CarDealershipRepository retrn = new CarDealershipRepository();
            return retrn.PostCarDealership(C);
        }
        public CarDealership Putt(System.Guid id, CarDealership C)
        {
            CarDealershipRepository retrn = new CarDealershipRepository();
            return retrn.Putt(id,C);
        }
        public bool Delete(System.Guid id)
        {
            CarDealershipRepository retrn = new CarDealershipRepository();
            return retrn.Delete(id);
        }


    }
}
