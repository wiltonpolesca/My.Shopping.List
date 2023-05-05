using Microsoft.AspNetCore.Mvc;
using My.Shopping.List.Entities;
using My.Shopping.List.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace My.Shopping.List.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShoppingListController : ControllerBase
{
    private const string ShoppingListTable = "ShoppingList";

    [HttpGet]
    public IEnumerable<object> Get()
    {
        return InMemoryDatabase.Instance.GetData(ShoppingListTable);
    }

    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    [HttpPost]
    public void Post([FromBody] ShoppingList value)
    {
        InMemoryDatabase.Instance.AddNewItem(ShoppingListTable,value);
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
