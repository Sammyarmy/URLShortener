using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace URLShortener.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IShortener _shortener;

        [BindProperty]
        public string? LongUrl { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IShortener shortener)
        {
            _logger = logger;
            _shortener = shortener;
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            var shortUrl = _shortener.GenerateShortUrl(LongUrl);
            _shortener.StoreUrl(LongUrl, shortUrl);
        }
    }
}