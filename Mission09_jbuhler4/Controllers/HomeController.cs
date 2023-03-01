using Microsoft.AspNetCore.Mvc;
using Mission09_jbuhler4.Models;
using Mission09_jbuhler4.Models.ViewModels;
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
        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 5;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .Skip(pageSize * (pageNum - 1))
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = repo.Books.Count(),
                    CurrentPage = pageNum,
                    BooksPerPage = pageSize
                }
            };
            return View(x);
        }
    }
}
