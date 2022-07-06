using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono02.Common
{
    public class Sorting
    {
        public Sorting()
        {
            orderBy = "carName";
            sortOrder = "ascending"; 
        }
        public Sorting(string newOrderBy, string newSortOrder) {
            orderBy = newOrderBy;
            sortOrder = newSortOrder;
        }


        public string orderBy;
        public string sortOrder;

    }
}
