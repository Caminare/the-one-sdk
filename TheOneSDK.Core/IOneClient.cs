using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheOneSDK.Core.Models;
using TheOneSDK.Core.Request;

namespace TheOneSDK.Core
{
    public interface IOneClient
    {
        Task<Book[]> GetBooksAsync(APIRequest requestOptions = null);
        Task<Movie[]> GetMoviesAsync(APIRequest requestOptions = null);
        Task<Character[]> GetCharactersAsync(APIRequest requestOptions = null);
        Task<Quote[]> GetQuotesAsync(APIRequest requestOptions = null);
        Task<Chapter[]> GetChaptersAsync(APIRequest requestOptions = null);
        Task<Book> GetBookAsync(string id);
        Task<Movie> GetMovieAsync(string id);
        Task<Character> GetCharacterAsync(string id);
        Task<Quote> GetQuoteAsync(string id);
        Task<Chapter> GetChapterAsync(string id);
        Task<Chapter[]> GetBookChaptersAsync(string bookId, APIRequest requestOptions = null);
        Task<Quote[]> GetMovieQuotesAsync(string movieId, APIRequest requestOptions = null);
        Task<Quote[]> GetCharacterQuotesAsync(string characterId, APIRequest requestOptions = null);

    }
}