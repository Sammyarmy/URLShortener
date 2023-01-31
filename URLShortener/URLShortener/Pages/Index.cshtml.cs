using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace URLShortener.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IShortener _shortener;

        [BindProperty(SupportsGet = true)]
        public string? LongUrl { get; set; }

        public string? ShortUrl { get; set; }

        public IndexModel(IShortener shortener)
        {
            _shortener = shortener;
        }

        public IActionResult OnGet(string shortUrl)
        {
            if (!string.IsNullOrEmpty(shortUrl))
            {
                var longUrl = _shortener.GetLongUrl(shortUrl);
                if (!string.IsNullOrEmpty(longUrl) && longUrl != "Not Found")
                {
                    return Redirect($"https://{longUrl}");
                }
                return Redirect("redirect");
            }

            return Page();
        }

        public void OnPost()
        {
            if (!string.IsNullOrWhiteSpace(LongUrl))
            {
                ShortUrl = _shortener.GenerateShortUrl(LongUrl);
                _shortener.StoreUrl(ShortUrl, LongUrl);
            }
        }
    }
}