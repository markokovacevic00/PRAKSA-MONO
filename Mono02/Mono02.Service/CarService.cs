using Mono02.Common;
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
    public class CarService : ICarServiceCommon
    {
        public async Task<List<Car>> GetCarAsync(Paging P, Sorting S, SearchFilter F, BetweenFilter B)
        {
            CarRepository retrn = new CarRepository();
            return await retrn.GetCarAsync(P,S,F,B);
        }
        public async Task<Car> GetAsync(System.Guid id)
        {
            CarRepository retrn = new CarRepository();
            return await retrn.GetAsync(id);
        }
        public async Task<Car> AddCarAsync(Car C)
        {
            CarRepository retrn = new CarRepository();
            return await retrn.AddCarAsync(C);
        }
        public async Task<Car> PuttAsync(System.Guid id, Car C)
        {
            CarRepository retrn = new CarRepository();
            return await retrn.PuttAsync(id, C);
        }
        public async Task<bool> DeleteAsync(System.Guid id)
        {
            CarRepository retrn = new CarRepository();
            return await retrn.DeleteAsync(id);
        }

    }
}
