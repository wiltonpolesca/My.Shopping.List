using My.Core.InMemory.Database;
using My.Shopping.List.Entities;

namespace My.Shopping.List.Services;

public class ShoppingListService 
{
    public const string ShoppingListTable = "ShoppingList";

    public void Add(ShoppingList shoppingList)
    {
        IsValid(shoppingList);
        InMemoryDatabase.Instance.AddNewItem(ShoppingListTable, shoppingList);
    }

    private void IsValid(ShoppingList entity)
    {
        if (string.IsNullOrWhiteSpace(entity.Name))
        {
            throw new Exception("Invalid name");
        }

        var exists = InMemoryDatabase
            .Instance
            .GetData<ShoppingList>(ShoppingListTable)
            .FirstOrDefault(x => x.Name.Equals(entity.Name));

        if (exists != null) {
            throw new Exception("Name already exists");
        }
    }

}
