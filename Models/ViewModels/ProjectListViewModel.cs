using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS_413_Assignment_5.Models.ViewModels
{
    public class ProjectListViewModel
    {
        //contains the books and the paging info
        public IEnumerable<Books> Books { get; set; }
        public PagingInfo PagingInfo { get; set; }

        
    }
}
