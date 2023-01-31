namespace URLShortener
{
    public interface IShortener
    {
        string GenerateShortUrl(string longUrl);
        void StoreUrl(string shortUrl, string longUrl);
        string GetLongUrl(string shortUrl);
    }
}