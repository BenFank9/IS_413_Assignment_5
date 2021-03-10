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
        public IActionResult Index(string category, int page = 1)
        {
            //this is saying order by the book id. bring back 0-4 and on the 5th element in the array go to a new page. show 5 items per page. this also allows for filtering using categroy.
            //this is a query in linq!

            return View(new ProjectListViewModel
            {
                //add filtering
                Books = _bookstoreRepository.Books
                  .Where(p => category == null || p.Category == category)
                  .OrderBy(p => p.BookId)
                  .Skip((page - 1) * PageSize)
                  .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalNumItems = category == null ? _bookstoreRepository.Books.Count() :
                        _bookstoreRepository.Books.Where(x => x.Category == category).Count()
                },
                CurrentCategory = category
                
            }) ;
        }

   

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
