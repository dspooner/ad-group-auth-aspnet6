using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdGroups.Pages
{
    public class ByConventionsModel : PageModel
    {
        private readonly ILogger<ByConventionsModel> _logger;

        public ByConventionsModel(ILogger<ByConventionsModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}