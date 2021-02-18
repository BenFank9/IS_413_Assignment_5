using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS_413_Assignment_5.Models
{
    public class SeedData
    {
        public static void EnsurePopulated (IApplicationBuilder application)
        {
            //just do this lol
            BookstoreDbContext context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<BookstoreDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Books.Any())
            {
                context.Books.AddRange(

                    new Books
                    {
                        /*BookId = 1,*/
                        Title = "Les Miserables",
                        AuthorFirst = "Victor",
                        AuthorLast = "Hugo",
                        Publisher = "Signet",
                        ISBN = "978-0451419439",
                        Category = "Fiction",
                        Classification = "Classic",
                        Price = 9.95
                    },

                     new Books
                     {
                         /*BookId = 2,*/
                         Title = "Team of Rivals",
                         AuthorFirst = "Doris Kearns",
                         AuthorLast = "Goodwin",
                         Publisher = "Simon & Schuster",
                         ISBN = "978-0743270755",
                         Category = "Non-Fiction",
                         Classification = "Biography",
                         Price = 14.58
                     },

                     new Books
                     {
                         /*BookId = 3,*/
                         Title = "Sycamore Row",
                         AuthorFirst = "John",
                         AuthorLast = "Grisham",
                         Publisher = "Bantam",
                         ISBN = "978-0553393613",
                         Category = "Fiction",
                         Classification = "Thrillers",
                         Price = 15.03
                     },

                     new Books
                     {
                         /*BookId = 4,*/
                         Title = "Unbroken",
                         AuthorFirst = "Laura",
                         AuthorLast = "Hillenbrand",
                         Publisher = "Random House",
                         ISBN = "978-0812974492",
                         Category = "Non-Fiction",
                         Classification = "Historical",
                         Price = 13.33
                     }


                    );

                context.SaveChanges();
            }
        }
    }
}
