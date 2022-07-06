using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono02.Common
{
    public class BetweenFilter

    {
        public int min = 0;
        public int max = 999999999;
        public string sName = "carPrice";
        public BetweenFilter()
        {
            min = 0;
            max = 99999999;
            sName = "";
        }
        public BetweenFilter(int sMin, int sMax, string sNam)
        {
            min = sMin;
            max = sMax;
            sName = sNam;
        }



    }
}
