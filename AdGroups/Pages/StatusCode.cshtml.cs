using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;

namespace AdGroups.Pages
{
    public class StatusCodeModel : PageModel
    {
        public string? PageStatus { get; set; }

        public void OnGet(HttpStatusCode? statusCode = null)
        {
            PageStatus = $"{statusCode}";
        }
    }
}
