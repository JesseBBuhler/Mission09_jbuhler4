using Microsoft.AspNetCore.Mvc;
using Mission09_jbuhler4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_jbuhler4.Components
{
    public class CategoryViewComponent : ViewComponent
    {
        private IBookstoreRepository repo { get; set; }

        //connecting repository to the model so that the default category component view can access the categories it needs to display
        public CategoryViewComponent(IBookstoreRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            //storing currently selected category in the viewbag so it can be highlighted
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            var category = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(category);
        }
    }
}
