using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheOneSDK.Core.Models;
using TheOneSDK.Core.Request;
using TheOneSDK.Core.Request.Extensions;
using RestSharp;

namespace TheOneSDK.Core
{
    public class OneClient : IOneClient
    {
        private const string _apiUrl = "https://the-one-api.dev";
        private const string _apiVersion = "v2";
        private readonly RestClient _client;

        public OneClient(string apiKey)
        {
            _client = new RestClient(_apiUrl);
            _client.AddDefaultHeader("Authorization", $"Bearer {apiKey}");
        }

        private async Task<T> GetAsync<T>(string resource, Dictionary<string, string> parameters = null)
        {
            var request = new RestRequest($"{_apiVersion}/{resource}");
            if (parameters != null)
            {
                request.AddParameters(parameters);
            }
            var response =  await _client.ExecuteGetAsync<RequestReponse<T>>(request);

            if (!response.IsSuccessStatusCode)
                throw new Exception($"Uh oh, the one api seems to have returned an error with code: {response.StatusCode} and description: {response.Content}");

            var data = response.Data;

            return data.Docs.FirstOrDefault();
        }

        private async Task<T[]> GetManyAsync<T>(string resource, Dictionary<string, string> parameters = null, APIRequest requestOptions = null)
        {
            var request = new RestRequest($"{_apiVersion}/{resource}");
            if (parameters != null)
            {
                request.AddParameters(parameters);
            }

            if (requestOptions != null)
            {
                request.AddOptions(requestOptions);
            }

            var response = await _client.ExecuteGetAsync<RequestReponse<T>>(request);

            if (!response.IsSuccessStatusCode)
                throw new Exception($"Uh oh, the one api seems to have returned an error with code: {response.StatusCode} and description: {response.Content}");

            var data = response.Data;

            return data.Docs;
        }

        public async Task<Book> GetBookAsync(string id)
        {
            return await GetAsync<Book>($"book/{id}");
        }

        public async Task<Book[]> GetBooksAsync(APIRequest requestOptions = null)
        {
            return await GetManyAsync<Book>("book", requestOptions: requestOptions);
        }

        public async Task<Movie> GetMovieAsync(string id)
        {
            return await GetAsync<Movie>($"movie/{id}");
        }

        public async Task<Movie[]> GetMoviesAsync(APIRequest requestOptions = null)
        {
            return await GetManyAsync<Movie>("movie", requestOptions: requestOptions);
        }

        public async Task<Character> GetCharacterAsync(string id)
        {
            return await GetAsync<Character>($"character/{id}");
        }

        public async Task<Character[]> GetCharactersAsync(APIRequest requestOptions = null)
        {
            return await GetManyAsync<Character>("character", requestOptions: requestOptions);
        }

        public async Task<Quote> GetQuoteAsync(string id)
        {
            return await GetAsync<Quote>($"quote/{id}");
        }

        public async Task<Quote[]> GetQuotesAsync(APIRequest requestOptions = null)
        {
            return await GetManyAsync<Quote>("quote", requestOptions: requestOptions);
        }

        public async Task<Chapter> GetChapterAsync(string id)
        {
            return await GetAsync<Chapter>($"chapter/{id}");
        }

        public async Task<Chapter[]> GetChaptersAsync(APIRequest requestOptions = null)
        {
            return await GetManyAsync<Chapter>("chapter", requestOptions: requestOptions);
        }

        public async Task<Chapter[]> GetBookChaptersAsync(string bookId, APIRequest requestOptions = null)
        {
            return await GetManyAsync<Chapter>($"book/{bookId}/chapter", requestOptions: requestOptions);
        }

        public async Task<Quote[]> GetMovieQuotesAsync(string movieId, APIRequest requestOptions = null)
        {
            return await GetManyAsync<Quote>($"movie/{movieId}/quote", requestOptions: requestOptions);
        }

        public async Task<Quote[]> GetCharacterQuotesAsync(string characterId, APIRequest requestOptions = null)
        {
            return await GetManyAsync<Quote>($"character/{characterId}/quote", requestOptions: requestOptions);
        }
    }
}