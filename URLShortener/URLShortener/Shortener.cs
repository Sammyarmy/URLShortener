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
            urlDict.Add(shortUrl, longUrl); //This would ideally store into a persistent data store, instead I'm creating this class as a singleton to store the dict over the lifetime of the application
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