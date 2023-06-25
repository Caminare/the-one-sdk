// See https://aka.ms/new-console-template for more information

using TheOneSDK.Core;
using TheOneSDK.Core.Request;
using TheOneSDK.Core.Request.Options;
using System.Text.Json;

var client = new OneClient("QwcZRx7pC_w0MN-IUbVr");

var request = new APIRequest
{
    Pagination = new PaginationOptions
    {
        PageSize = 2,
        PageNumber = 1
    },
    Sorting = new SortingOptions
    {
        PropName = "Name",
        Order = SortOrder.Desc
    },
    Filters = new List<Filter<object>>
    {
        new Filter<object> ("Name", "The Two Towers", FilterOperator.Equals)
    }
};

var requestBuilder = new RequestBuilder();
requestBuilder = requestBuilder.AddPagination(request.Pagination).AddSorting(request.Sorting);

if (request.Filters != null)
{
    foreach (var filter in request.Filters)
    {
        requestBuilder = requestBuilder.AddFilter(filter);
    }
}


var book = await client.GetBookAsync("5cf5805fb53e011a64671582");
var books = await client.GetBooksAsync(request);

Console.WriteLine("Hello, World!");
Console.WriteLine(book.Name);
Console.WriteLine(books.Length);
Console.WriteLine(JsonSerializer.Serialize(books));
Console.WriteLine(requestBuilder.Build());