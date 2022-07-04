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
        public async Task<List<CarDealership>> GetCarDealershipAsync()
        {
            CarDealershipRepository retrn = new CarDealershipRepository();
            return await retrn.GetCarDealerShipAsync();
        }
        public async Task<CarDealership> GetAsync(System.Guid id)
        {
            CarDealershipRepository retrn = new CarDealershipRepository();
            return await retrn.GetAsync(id);
        }
        public async Task<CarDealership> PostCarDealershipAsync(CarDealership C)
        {
            CarDealershipRepository retrn = new CarDealershipRepository();
            return await retrn.PostCarDealershipAsync(C);
        }
        public async Task<CarDealership> PuttAsync(System.Guid id, CarDealership C)
        {
            CarDealershipRepository retrn = new CarDealershipRepository();
            return await retrn.PuttAsync(id,C);
        }
        public async Task<bool> DeleteAsync(System.Guid id)
        {
            CarDealershipRepository retrn = new CarDealershipRepository();
            return await retrn.DeleteAsync(id);
        }


    }
}
