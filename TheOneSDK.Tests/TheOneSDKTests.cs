using System.Threading.Tasks;
using TheOneSDK.Core;
using TheOneSDK.Core.Request.Options;
using TheOneSDK.Core.Request;
using Xunit;

namespace TheOneSDK.Tests;

public class TheOneSDKTests
{
    private const string ApiKey = "QwcZRx7pC_w0MN-IUbVr";
    private readonly OneClient _client;

    public TheOneSDKTests()
    {
        _client = new OneClient(ApiKey);
    }

    [Fact]
    public async Task ShouldGetOneMovie()
    {
        var movie = await _client.GetMovieAsync("5cd95395de30eff6ebccde59");

        Assert.Equal("The Desolation of Smaug", movie.Name);
    }

    [Fact]
    public async Task ShouldGetOneBook()
    {
        var book = await _client.GetBookAsync("5cf58077b53e011a64671583");

        Assert.Equal("The Two Towers", book.Name);
    }

    [Fact]
    public async Task ShouldGetManyMovies()
    {
        var requestOptions = new APIRequest
        {
            Pagination = new PaginationOptions
            {
                PageSize = 3,
                PageNumber = 1
            }
        };
        var movies = await _client.GetMoviesAsync(requestOptions);

        Assert.Equal(3, movies.Length);
    }

    [Fact]
    public async Task ShouldGetManyBooks() 
    {
        var requestOptions = new APIRequest
        {
            Pagination = new PaginationOptions
            {
                PageSize = 2,
                PageNumber = 1
            }
        };
        var books = await _client.GetBooksAsync(requestOptions);

        Assert.Equal(2, books.Length);
    }

    [Fact]
    public async Task ShouldGetOneCharacter()
    {
        var character = await _client.GetCharacterAsync("5cd99d4bde30eff6ebccfe9e");

        Assert.Equal("Gollum", character.Name);
    }

    [Fact]
    public async Task ShouldGetManyCharacters()
    {
        var requestOptions = new APIRequest
        {
            Pagination = new PaginationOptions
            {
                PageSize = 2,
                PageNumber = 1
            }
        };
        var characters = await _client.GetCharactersAsync(requestOptions);

        Assert.Equal(2, characters.Length);
    }

    [Fact]
    public async Task ShouldGetOneQuote()
    {
        var quote = await _client.GetQuoteAsync("5cd96e05de30eff6ebcce7e9");

        Assert.Equal("Deagol!", quote.Dialog);
    }

    [Fact]
    public async Task ShouldGetManyQuotes()
    {
        var requestOptions = new APIRequest
        {
            Pagination = new PaginationOptions
            {
                PageSize = 15,
                PageNumber = 1
            }
        };
        var quotes = await _client.GetQuotesAsync(requestOptions);

        Assert.Equal(15, quotes.Length);
    }

    [Fact]
    public async Task ShouldGetOneChapter() 
    {
        var chapter = await _client.GetChapterAsync("6091b6d6d58360f988133ba8");

        Assert.Equal("The Road to Isengard", chapter.Name);
    }

    [Fact]
    public async Task ShouldGetManyChapters() 
    {
        var requestOptions = new APIRequest
        {
            Pagination = new PaginationOptions
            {
                PageSize = 7,
                PageNumber = 1
            }
        };
        var chapters = await _client.GetChaptersAsync(requestOptions);

        Assert.Equal(7, chapters.Length);
    }

    [Fact]
    public async Task ShouldGetChaptersByBookId() 
    {
        var requestOptions = new APIRequest
        {
            Pagination = new PaginationOptions
            {
                PageSize = 5,
                PageNumber = 1
            }
        };
        var chapters = await _client.GetBookChaptersAsync("5cf5805fb53e011a64671582", requestOptions);

        Assert.Equal(5, chapters.Length);
    }

    [Fact]
    public async Task ShouldGetQuotesByMovieId()
    {
        var requestOptions = new APIRequest
        {
            Pagination = new PaginationOptions
            {
                PageSize = 20,
                PageNumber = 1
            }
        };
        var quotes = await _client.GetMovieQuotesAsync("5cd95395de30eff6ebccde5d", requestOptions);

        Assert.Equal(20, quotes.Length);
    }

    [Fact]
    public async Task ShouldGetQuotesByCharacterId()
    {
        var requestOptions = new APIRequest
        {
            Pagination = new PaginationOptions
            {
                PageSize = 3,
                PageNumber = 1
            }
        };
        var quotes = await _client.GetCharacterQuotesAsync("5cd99d4bde30eff6ebccfe9e", requestOptions);

        Assert.Equal(3, quotes.Length);
    }

}