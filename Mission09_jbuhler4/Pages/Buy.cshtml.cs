using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mission09_jbuhler4.Pages
{
    public class BuyModel : PageModel
    {
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int projectId, string returnUrl)
        {
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
