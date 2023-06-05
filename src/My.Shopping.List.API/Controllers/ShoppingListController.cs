using Microsoft.AspNetCore.Mvc;
using My.Core.Abstracts;
using My.Core.InMemory.Database;
using My.Shopping.List.API.DTO;
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
    public IEnumerable<ShoppingListOutput> Get()
    {
        // -- Opção 1
        //return _service.Get().Select(entity => new ShoppingListOutput
        //{
        //    Id = entity.Id,
        //    Name = entity.Name,
        //    Order = entity.Order,
        //    IsArchived = entity.IsArchived
        //});

        // -- Opção 2
        //var data = _service.Get();
        //var result = new List<ShoppingListOutput>();
        //foreach (var entity in data)
        //{
        //    result.Add(new ShoppingListOutput
        //    {
        //        Id = entity.Id,
        //        Name = entity.Name,
        //        Order = entity.Order,
        //        IsArchived = entity.IsArchived
        //    });
        //}

        //return result;

        // -- Opção 3
        //return _service.Get().Select(ShoppingListOutput.FromEntity);

        // -- Opção 4
        // Obtem o dado do serviço
        var data = _service.Get();

        // Usar o LINK (função SELECT) para iterar e transformar o dado
        var result = data.Select(item => ShoppingListOutput.FromEntity(item));
        return result;

    }

    [HttpGet("{id}")]
    public ShoppingListOutput? Get(int id)
    {
        var item = _service.Get(id);
        if (item != null)
        {
            return ShoppingListOutput.FromEntity(item);
        }

        return null;
    }

    [HttpPost]
    public void Post([FromBody] ShoppingListInsertInput value)
    {
        _service.Add(new ShoppingList { Name = value.Name });
    }

    [HttpPut]
    public void Put(int id, [FromBody] ShoppingListUpdateInput value)
    {
        _service.Update(new ShoppingList
        {
            Id = id,
            Name = value.Name,
            IsArchived = value.IsArchived,
            Order = value.Order
        });
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        _service.Delete(id);
    }
}
