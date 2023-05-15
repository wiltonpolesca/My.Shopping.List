using Microsoft.AspNetCore.Mvc;
using My.Core.InMemory.Database;
using My.Shopping.List.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace My.Shopping.List.API.Controllers;

/// <summary>
/// Classe só para exemplo de persistência sem utilizar IEntity
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private const string ProductTable = "Product";

    [HttpGet]
    public IEnumerable<object> Get()
    {
        return InMemoryDatabase.Instance.GetData(ProductTable);
    }

    [HttpPost]
    public void Post([FromBody] Product value)
    {
        InMemoryDatabase.Instance.AddNewItem(ProductTable, value);
    }

}
