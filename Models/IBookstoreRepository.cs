using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS_413_Assignment_5.Models
{
    //this is a template that is defining what needs to be set up and in what way
    public interface IBookstoreRepository
    {
        IQueryable<Books> Books { get; }
    }
}
