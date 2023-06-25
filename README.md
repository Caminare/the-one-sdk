# The One API SDK
This is an SDK that encapsulates the LOTR The One Api (https://the-one-api.dev/). <br />
It supports all the endpoints as of the date that was create (25/06/2023). <br />
The SDK is for use with .NET 6+ applications.

## Requirements
.NET 6 SDK <br />
An API key for https://the-one-api.dev/, you will need to create an account to generate one

## Installation
This SDK is available in Nuget, to install it in your project, run the following command in dotnet CLI
``` 
dotnet add package TheOneSDK.Core --version 1.0.0
```

## Test
To run the tests, clone this repo, restore the packages and run the command in solution folder
``` 
dotnet test
```

## Usage
Import the SDK in your class project
```
using TheOneSDK.Core;
```

Init the client providing your API Key
```
var client = new OneClient("yoursupersecretkey");
```

And then you can enjoy yourself, little example to get one book or many books
```
var book = await client.GetBookAsync("id");
var books = await client.GetBooksAsync();
```

## Filtering
You may want to filter your requests (when requesting from multiple results methods), and, well, you have and nice request model to do that and customize your requests. <br />
You will need to import the necessary packages from the sdk:
```
using TheOneSDK.Core.Request;
using TheOneSDK.Core.Request.Options;
```

### For pagination
```
var pagination = new PaginationOptions
{
    PageSize = 2,
    PageNumber = 1
};

var requestOptions = new APIRequest
{
    Pagination = pagination
};

//And then provide the requestOptions in method call
var books = await client.GetBooksAsync(requestOptions);
```

### For sorting
```
var sorting = new SortingOptions
{
    PropName = "RuntimeInMinutes",
    Order = SortOrder.Asc
};

var requestOptions = new APIRequest
{
    Sorting = sorting
};

//And then provide the requestOptions in method call
var movies = await client.GetMoviesAsync(requestOptions);
```

### For filtering
```
var filter = new Filter<object> ("Name", "Aerin", FilterOperator.Equals);

var requestOptions = new APIRequest
{
    Filters = new List<Filter<object>>
    {
        filter
    }
};

//And then provide the requestOptions in method call
var characters = await client.GetCharactersAsync(requestOptions);
```

To build an filter, you need to provide the following parameters: <br />
- `PropName`
- `Value` (Optional in case of Exists/NotExists filtering)
- `Operator`
  - The operators should be from the FilterOperator enum, and the available ones are `Equals, NotEquals, GreaterThan, GreaterThanOrEqual, LessThanOrEqual, Contains, NotContains, Like, NotLike, Exists, NotExists`    


### Put everything together
```
var pagination = new PaginationOptions
{
    PageSize = 5,
    PageNumber = 1
};
var sorting = new SortingOptions
{
    PropName = "Gender",
    Order = SortOrder.Desc
};
var filter = new Filter<object> ("Race", "Elf", FilterOperator.Equals);
var requestOptions = new APIRequest
{
    Pagination = pagination,
    Sorting = sorting,
    Filters = new List<Filter<object>>
    {
        filter
    }
};

var characters = await client.GetCharactersAsync(requestOptions);
```
