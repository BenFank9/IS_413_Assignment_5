using IS_413_Assignment_5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IS_413_Assignment_5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IBookstoreRepository _bookstoreRepository;

        public HomeController(ILogger<HomeController> logger, IBookstoreRepository bookstoreRepository)
        {
            _logger = logger;
            _bookstoreRepository = bookstoreRepository;
        }

        public IActionResult Index()
        {
            return View(_bookstoreRepository.Books);
        }

   

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
