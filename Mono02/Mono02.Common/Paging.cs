using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono02.Common
{
    public class Paging
    {
        public Paging(){
            rpp = 10;
            pageNumber = 1;
        }
        public Paging(int newrpp, int newPageNumber)
        {
            rpp = newrpp;
            pageNumber = newPageNumber;
        }
        public int rpp;
        public int pageNumber;
    }
}
