using Microsoft.AspNetCore.Mvc;
using Mission09_jbuhler4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_jbuhler4.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository repo;

        public HomeController(IBookstoreRepository temp)
        {
            repo = temp;
        }
        public IActionResult Index()
        {
            var books = repo.Books.ToList();
            return View(books);
        }
    }
}
