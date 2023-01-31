using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Moq;
using Xunit;

namespace URLShortener.Pages.Tests
{
    public class IndexModelTests
    {
        private readonly Mock<IShortener> _shortenerMock = new Mock<IShortener>();

        [Fact]
        public void OnGet_WithShortUrl_ShouldRedirect()
        {
            // Arrange
            var model = new IndexModel(_shortenerMock.Object);
            var shortUrl = "abc123";
            var longUrl = "https://www.example.com";
            _shortenerMock.Setup(s => s.GetLongUrl(shortUrl)).Returns(longUrl);

            // Act
            var result = model.OnGet(shortUrl);

            // Assert
            Assert.IsType<RedirectResult>(result);
            var redirectResult = result as RedirectResult;
            Assert.Equal($"https://{longUrl}", redirectResult.Url);
        }

        [Fact]
        public void OnGet_WithInvalidShortUrl_ShouldRedirect()
        {
            // Arrange
            var model = new IndexModel(_shortenerMock.Object);
            var shortUrl = "abc123";
            _shortenerMock.Setup(s => s.GetLongUrl(shortUrl)).Returns(string.Empty);

            // Act
            var result = model.OnGet(shortUrl);

            // Assert
            Assert.IsType<RedirectResult>(result);
            var redirectResult = result as RedirectResult;
            Assert.Equal("redirect", redirectResult.Url);
        }

        [Fact]
        public void OnGet_WithoutShortUrl_ShouldReturnPageResult()
        {
            // Arrange
            var model = new IndexModel(_shortenerMock.Object);

            // Act
            var result = model.OnGet(null);

            // Assert
            Assert.IsType<PageResult>(result);
        }

        [Fact]
        public void OnPost_WithValidLongUrl_ShouldGenerateShortUrl()
        {
            // Arrange
            var model = new IndexModel(_shortenerMock.Object);
            model.LongUrl = "https://www.example.com";
            var shortUrl = "abc123";
            _shortenerMock.Setup(s => s.GenerateShortUrl(model.LongUrl)).Returns(shortUrl);

            // Act
            model.OnPost();

            // Assert
            Assert.Equal(shortUrl, model.ShortUrl);
            _shortenerMock.Verify(s => s.StoreUrl(shortUrl, model.LongUrl), Times.Once());
        }
    }
}