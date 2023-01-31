using Xunit;

namespace URLShortener;

public class ShortenerTests
{
    private Shortener _shortener;

    public ShortenerTests()
    {
        _shortener = new Shortener();
    }

    [Fact]
    public void TestStoreUrl()
    {
        // Arrange
        var shortener = new Shortener();
        var shortUrl = "sho.rt/abcdef";
        var longUrl = "https://www.example.com/some-long-url";

        // Act
        shortener.StoreUrl(shortUrl, longUrl);
        var result = shortener.GetLongUrl(shortUrl);

        // Assert
        Assert.Equal(longUrl, result);
    }

    [Fact]
    public void TestGetUrl_Found()
    {
        // Arrange
        var shortener = new Shortener();
        var shortUrl = "sho.rt/abcdef";
        var longUrl = "https://www.example.com/some-long-url";
        shortener.StoreUrl(shortUrl, longUrl);

        // Act
        var result = shortener.GetLongUrl(shortUrl);

        // Assert
        Assert.Equal(longUrl, result);
    }

    [Fact]
    public void TestGetUrl_NotFound()
    {
        // Arrange
        var shortener = new Shortener();

        // Act
        var result = shortener.GetLongUrl("abcdef");

        // Assert
        Assert.Equal("Not Found", result);
    }

    [Fact]
    public void TestGenerateShortUrl()
    {
        // Arrange
        var shortener = new Shortener();
        var longUrl = "https://www.example.com/some-long-url";

        // Act
        var result = shortener.GenerateShortUrl(longUrl);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(6, result.Length);
    }

    [Fact]
    public void GenerateShortUrl_ReturnsUniqueShortUrl()
    {
        // Arrange
        string longUrl1 = "https://www.example.com/page1";
        string longUrl2 = "https://www.example.com/page2";

        // Act
        string shortUrl1 = _shortener.GenerateShortUrl(longUrl1);
        string shortUrl2 = _shortener.GenerateShortUrl(longUrl2);

        // Assert
        Assert.NotEqual(shortUrl1, shortUrl2);
        Assert.Matches("[a-zA-Z0-9]{6}", shortUrl1);
        Assert.Matches("[a-zA-Z0-9]{6}", shortUrl2);
    }
}