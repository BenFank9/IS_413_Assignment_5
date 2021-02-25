using IS_413_Assignment_5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IS_413_Assignment_5.Models.ViewModels;

namespace IS_413_Assignment_5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IBookstoreRepository _bookstoreRepository;

        public int PageSize = 5;
        public HomeController(ILogger<HomeController> logger, IBookstoreRepository bookstoreRepository)
        {
            _logger = logger;
            _bookstoreRepository = bookstoreRepository;
        }

        //default page 1
        public IActionResult Index(int page = 1)
        {
            //this is saying order by the book id. bring back 0-4 and on the 5th element in the array go to a new page. show 5 items per page
            //this is a query in link!
            /*  return View(_bookstoreRepository.Books
                  .OrderBy(p => p.BookId)
                  .Skip((page - 1) * ItemsPerPage)
                  .Take(ItemsPerPage)
                  );*/
            return View(new ProjectListViewModel
            {
                Books = _bookstoreRepository.Books
                  .OrderBy(p => p.BookId)
                  .Skip((page - 1) * PageSize)
                  .Take(PageSize)

                  ,
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalNumItems = _bookstoreRepository.Books.Count()
                    }
            });
        }

   

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
