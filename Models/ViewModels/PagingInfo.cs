using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS_413_Assignment_5.Models.ViewModels
{
    public class PagingInfo
    {
        public int TotalNumItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }

        //casting cause two ints round down
        //round up
        //cast all as int
        public int TotalPages => (int)(Math.Ceiling((decimal) TotalNumItems / ItemsPerPage));
    }
}
