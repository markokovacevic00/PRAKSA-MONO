using Mono02.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono02.Model
{
    public class CarDealership : ICarDealershipModel
    {
        public CarDealership(System.Guid ID, string NAME)
        {
            cd_ID = ID;
            cd_Name = NAME;
        }
        public System.Guid cd_ID;
        public string cd_Name;
    };
}
