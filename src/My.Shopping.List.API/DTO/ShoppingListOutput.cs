using My.Shopping.List.Entities;

namespace My.Shopping.List.API.DTO;

public class ShoppingListOutput
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Order { get; set; }
    public bool IsArchived { get; set; }

    public static ShoppingListOutput FromEntity(ShoppingList entity)
    {
        return new ShoppingListOutput
        {
            Id = entity.Id,
            Name = entity.Name,
            Order = entity.Order,
            IsArchived = entity.IsArchived
        };
    }

    public static ShoppingList ToEntity(ShoppingListOutput dto)
    {
        return new ShoppingList
        {
            Id = dto.Id,
            Name = dto.Name,
            Order = dto.Order,
            IsArchived = dto.IsArchived
        };
    }

}
