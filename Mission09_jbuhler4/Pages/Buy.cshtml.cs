using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission09_jbuhler4.Infrastructure;
using Mission09_jbuhler4.Models;

namespace Mission09_jbuhler4.Pages
{
    public class BuyModel : PageModel
    {
        private IBookstoreRepository repo { get; set; }

        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }

        public BuyModel (IBookstoreRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }
        public void OnGet(string returnUrl)
        {
            //if there is no return url then redirect to the home page
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            //grab the book that was selected
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);
           
            //add the book to the basket with a quantity of 1
            basket.AddItem(b, 1);

            //return the user back to the page that they were on before
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Book.BookId == bookId).Book);
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
