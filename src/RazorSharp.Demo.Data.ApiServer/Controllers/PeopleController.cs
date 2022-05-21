namespace RazorSharp.Demo.Data.ApiServer.Controllers;

using System.Text;

using Microsoft.AspNetCore.Mvc;

using RazorSharp.Demo.Data.Abstractions.Services;
using RazorSharp.Demo.Data.Models;
using RazorSharp.Demo.Search;

[ApiController]
[Route("api/[controller]")]
public sealed class PeopleController
{
    private readonly IReadOnlyDictionary<Person, StringBuilder> _data;

    public PeopleController(IDataProvider<IReadOnlyDictionary<Person, StringBuilder>> dataProvider)
        => _data = dataProvider.GetData();

    [HttpGet("search")]
    public IEnumerable<Person> Search([FromQuery] string value)
    {
        if (!string.IsNullOrWhiteSpace(value))
        {
            foreach (var item in _data)
            {
                if (SearchInputMatcher.IsMatch(item.Value, value))
                {
                    yield return item.Key;
                }
            }
        }
    }
}