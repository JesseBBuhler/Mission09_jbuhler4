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
        //initializing repository
        private IBookstoreRepository repo;
        public HomeController(IBookstoreRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index(string category, int pageNum = 1)
        {
            //page size is 3 because I think it fits on the screen better and minimizes scrolling
            int pageSize = 3;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .Where(b => b.Category == category || category == null)
                .OrderBy(b => b.Title)
                .Skip(pageSize * (pageNum - 1))
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = (category == null
                    ? repo.Books.Count()
                    : repo.Books.Where(x => x.Category == category).Count()),
                    CurrentPage = pageNum,
                    BooksPerPage = pageSize
                }
            };
            return View(x);
        }
    }
}
