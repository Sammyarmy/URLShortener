namespace URLShortener
{
    public class Shortener : IShortener
    {
        private Dictionary<string, string> urlDict = new Dictionary<string, string>();

        public Shortener()
        {
        }

        public void StoreUrl(string shortUrl, string longUrl)
        {
            urlDict.Add(shortUrl, longUrl);
        }

        public string GenerateShortUrl(string longUrl)
        {
            return new string($"{Guid.NewGuid().ToString("N").Substring(0, 6)}");
        }

        public string GetLongUrl(string shortUrl)
        {
            if (urlDict.TryGetValue(shortUrl, out string longUrl))
                return longUrl;

            return "Not Found";
        }
    }
}