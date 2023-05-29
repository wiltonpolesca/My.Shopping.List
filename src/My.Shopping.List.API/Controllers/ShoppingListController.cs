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
    private readonly ShoppingListService _service = new ShoppingListService();

    [HttpGet]
    public IEnumerable<ShoppingList> Get()
    {
       return _service.Get();
    }

    [HttpGet("{id}")]
    public ShoppingList? Get(int id)
    {
        return _service.Get(id);
    }

    [HttpPost]
    public void Post([FromBody] ShoppingList value)
    {
        _service.Add(value);
    }

    [HttpPut]
    public void Put([FromBody] ShoppingList value)
    {
        _service.Update(value);
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        _service.Delete(id);
    }
}
