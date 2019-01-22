using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Collections.Specialized;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages
{
    public class IndexModel : PageModel
    {
        private static WebClient client = new WebClient();

        [BindProperty]
        public string code { get; set; }
        [BindProperty]
        public string message { get; set; }

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            var parameters = new NameValueCollection { { "token", "apgnuze6arw583praf3ex92w3yg6c2" }, { "user", code }, { "message", message } };
            
            client.UploadValues("https://api.pushover.net/1/messages.json", parameters);
            return Page();
        }
    }
}
