using AdGroups.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdGroups.Pages
{
    [Authorize(Policy = AdGroupAuthorizationHandler.Policy)]
    public class ByPageModelModel : PageModel
    {
        private readonly ILogger<ByPageModelModel> _logger;

        public ByPageModelModel(ILogger<ByPageModelModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}