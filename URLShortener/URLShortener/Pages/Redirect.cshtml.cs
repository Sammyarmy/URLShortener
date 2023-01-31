using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace URLShortener.Pages
{
    public class RedirectModel : PageModel
    {
        private readonly ILogger<RedirectModel> _logger;

        public RedirectModel(ILogger<RedirectModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}