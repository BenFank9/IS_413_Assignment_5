using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS_413_Assignment_5.Models
{
    //inherits from a DbContext file or session of the database
    public class BookstoreDbContext : DbContext
    {
        //create a constructor
        public BookstoreDbContext (DbContextOptions<BookstoreDbContext> options) : base (options)
        {

        }

        //create a set of the books
        public DbSet<Books> Books { get; set; }
    }
}
