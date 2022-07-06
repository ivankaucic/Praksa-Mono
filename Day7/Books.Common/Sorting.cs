using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Common
{
    public class Sorting
    {
        public string OrderBy { get; set; }
        public string SortBy { get; set; }

        public Sorting(string orderBy, string sortBy)
        {
            this.OrderBy = orderBy;
            this.SortBy = sortBy;
        }

        public Sorting()
        {

        }


    }
}
