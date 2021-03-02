using IS_413_Assignment_5.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS_413_Assignment_5.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IBookstoreRepository repository;

        public NavigationMenuViewComponent(IBookstoreRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            //dropping a partial view into the view at that spot where the viewComponent is going in.
            return View(repository.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x)); //figures out how to order it.
        }
    }
}
