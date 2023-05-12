using Microsoft.AspNetCore.Mvc;
using My.Core.InMemory.Database;
using My.Shopping.List.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace My.Shopping.List.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShoppingListController : ControllerBase
{
    private const string ShoppingListTable = "ShoppingList";

    [HttpGet]
    public IEnumerable<ShoppingList> Get()
    {
        return InMemoryDatabase.Instance.GetData<ShoppingList>(ShoppingListTable);
    }

    [HttpGet("{id}")]
    public ShoppingList? Get(int id)
    {
        return InMemoryDatabase.Instance.TryGetById<ShoppingList>(ShoppingListTable, id);
    }

    [HttpPost]
    public void Post([FromBody] ShoppingList value)
    {
        InMemoryDatabase.Instance.AddNewItem(ShoppingListTable, value);
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] ShoppingList value)
    {
        InMemoryDatabase.Instance.UpdateItem(ShoppingListTable, id, value);
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        InMemoryDatabase.Instance.DeleteItem<ShoppingList>(ShoppingListTable, id);
    }
}
