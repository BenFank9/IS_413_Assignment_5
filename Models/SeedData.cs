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
                        Classification = "Fiction",
                        Category = "Classic",
                        Price = 9.95,
                        Pages = 1488
                    },

                     new Books
                     {
                         /*BookId = 2,*/
                         Title = "Team of Rivals",
                         AuthorFirst = "Doris Kearns",
                         AuthorLast = "Goodwin",
                         Publisher = "Simon & Schuster",
                         ISBN = "978-0743270755",
                         Classification = "Non-Fiction",
                         Category = "Biography",
                         Price = 14.58,
                         Pages = 944
                     },

                     new Books
                     {
                         /*BookId = 3,*/
                         Title = "Sycamore Row",
                         AuthorFirst = "John",
                         AuthorLast = "Grisham",
                         Publisher = "Bantam",
                         ISBN = "978-0553393613",
                         Classification = "Fiction",
                         Category = "Thrillers",
                         Price = 15.03,
                         Pages = 642

                     },

                     new Books
                     {
                         /*BookId = 4,*/
                         Title = "Unbroken",
                         AuthorFirst = "Laura",
                         AuthorLast = "Hillenbrand",
                         Publisher = "Random House",
                         ISBN = "978-0812974492",
                         Classification = "Non-Fiction",
                         Category = "Historical",
                         Price = 13.33,
                         Pages = 528
                     },
                     
                    
                      new Books
                      {
                          
                          Title = "The Virgin Way",
                          AuthorFirst = "Richard",
                          AuthorLast = "Branson",
                          Publisher = "Portfolio",
                          ISBN = "978-1591847984",
                          Classification = "Non-Fiction",
                          Category = "Business",
                          Price = 29.16,
                          Pages = 400
                      },

                       new Books
                       {
                           
                           Title = "It's Your Ship",
                           AuthorFirst = "Micheal",
                           AuthorLast = "Abrashoff",
                           Publisher = "Grand Central Publishing",
                           ISBN = "978-1455523023",
                           Classification = "Non-Fiction",
                           Category = "Self-Help",
                           Price = 21.66,
                           Pages = 240
                         
                       },


                        new Books
                        {
                            
                            Title = "Deep Work",
                            AuthorFirst = "Cal",
                            AuthorLast = "Newport",
                            Publisher = "Grand Central Publishing",
                            ISBN = "978-1455586691",
                            Classification = "Non-Fiction",
                            Category = "Self-Help",
                            Price = 14.99,
                            Pages = 304
                        },

                        //three new books entered into the seed data

                        new Books
                        {

                            Title = "Harry Potter 3",
                            AuthorFirst = "JK",
                            AuthorLast = "Rowling",
                            Publisher = "Bloomsbury",
                            ISBN = "747-5421556691",
                            Classification = "Fiction",
                            Category = "Fantasy",
                            Price = 6.99,
                            Pages = 464
                        },

                        new Books
                        {

                            Title = "Holes",
                            AuthorFirst = "Louis",
                            AuthorLast = "Sachar",
                            Publisher = "Farrar",
                            ISBN = "978-0786221868",
                            Classification = "Fiction",
                            Category = "Adventure",
                            Price = 3.99,
                            Pages = 272
                        },

                        new Books
                        {

                            Title = "Harry Potter 5",
                            AuthorFirst = "JK",
                            AuthorLast = "Rowling",
                            Publisher = "Bloomsbury",
                            ISBN = "978-1455586691",
                            Classification = "Fiction",
                            Category = "Fantasy",
                            Price = 6.99,
                            Pages = 766
                        }
                    );

                context.SaveChanges();
            }
        }
    }
}
