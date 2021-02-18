using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS_413_Assignment_5.Models
{
    public class EFBookstoreRepository : IBookstoreRepository
    {
        private BookstoreDbContext _context;

        //constructor
        public EFBookstoreRepository (BookstoreDbContext context)
        {
            //pass context into the private context
            _context = context;
        }

        //Books are set to the context
        public IQueryable<Books> Books => _context.Books;
    }
}
