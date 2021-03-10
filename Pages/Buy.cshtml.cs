using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IS_413_Assignment_5.Infrastructure;
using IS_413_Assignment_5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IS_413_Assignment_5.Pages
{
    public class BuyModel : PageModel
    {
        private IBookstoreRepository repository;

        //constructor
        public BuyModel(IBookstoreRepository repo)
        {
            repository = repo;
        }

        //build the cart
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        //methods
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(long bookId, string returnUrl)
        {
            Books books = repository.Books.FirstOrDefault(p => p.BookId == bookId);

            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            Cart.AddItem(books, 1);
            HttpContext.Session.SetJson("cart", Cart);

            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
