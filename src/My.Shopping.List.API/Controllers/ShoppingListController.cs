using Microsoft.AspNetCore.Mvc;
using My.Core.InMemory.Database;
using My.Shopping.List.Entities;
using My.Shopping.List.Services;
using System.Runtime.CompilerServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace My.Shopping.List.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShoppingListController : ControllerBase
{
    private readonly ShoppingListService service = new ShoppingListService();

    [HttpGet]
    public IEnumerable<ShoppingList> Get()
    {
        return InMemoryDatabase.Instance.GetData<ShoppingList>(ShoppingListService.ShoppingListTable);
    }

    [HttpGet("{id}")]
    public ShoppingList? Get(int id)
    {
        return InMemoryDatabase.Instance.TryGetById<ShoppingList>(ShoppingListService.ShoppingListTable, id);
    }

    [HttpPost]
    public void Post([FromBody] ShoppingList value)
    {
        service.Add(value);
    }

    [HttpPut]
    public void Put([FromBody] ShoppingList value)
    {
        service.Update(value);
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        InMemoryDatabase.Instance.DeleteItem<ShoppingList>(ShoppingListService.ShoppingListTable, id);
    }
}
