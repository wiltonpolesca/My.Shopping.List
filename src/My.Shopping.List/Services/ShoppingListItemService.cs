using My.Core.InMemory.Database;
using My.Shopping.List.Entities;

namespace My.Shopping.List.Services;

public class ShoppingListItemService
{
    private const string ShoppingListTable = "ShoppingListItem";

    public IEnumerable<ShoppingListItem> Get()
    {
        return InMemoryDatabase.Instance.GetData<ShoppingListItem>(ShoppingListTable);
    }

    public ShoppingListItem? Get(int id)
    {
        var result = InMemoryDatabase.Instance.TryGetById<ShoppingListItem>(ShoppingListTable, id);

        if (result == null)
        {
            throw new Exception("Not found");
        }

        return result;
    }


    public void Add(ShoppingListItem shoppingList)
    {
        IsValid(shoppingList, Actions.Add);
        InMemoryDatabase.Instance.Add(ShoppingListTable, shoppingList);
    }

    public void Update(ShoppingListItem shoppingList)
    {
        IsValid(shoppingList, Actions.Update);
        InMemoryDatabase.Instance.Update(ShoppingListTable, shoppingList);

    }

    public void Delete(int id)
    {
        InMemoryDatabase.Instance.Delete<ShoppingListItem>(ShoppingListTable, id);
    }

    private void IsValid(ShoppingListItem entity, Actions action)
    {
        if (string.IsNullOrWhiteSpace(entity.Name))
        {
            throw new Exception("Invalid name");
        }

        ShoppingListItem? exists = default;
        if (action == Actions.Add)

            exists = InMemoryDatabase
               .Instance
               .GetData<ShoppingListItem>(ShoppingListTable)
               .Where(x => x.Name.Equals(entity.Name))
               .Where(x => x.ShoppingListId.Equals(entity.ShoppingListId))
               .FirstOrDefault();

        else if (action == Actions.Update)
        {
            exists = InMemoryDatabase
               .Instance
               .GetData<ShoppingListItem>(ShoppingListTable)
               .Where(x => x.Name.Equals(entity.Name))
               .Where(x => x.ShoppingListId.Equals(entity.ShoppingListId))
               .Where(x => x.Id != entity.Id)
               .FirstOrDefault();
        }

        if (exists != null)
        {
            throw new Exception("Name already exists");
        }
    }

}
