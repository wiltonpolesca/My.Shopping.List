using My.Core.InMemory.Database;
using My.Shopping.List.Entities;
using System.Security.Cryptography;

namespace My.Shopping.List.Services;

public class ShoppingListService
{
    private const string ShoppingListTable = "ShoppingList";

    public IEnumerable<ShoppingList> Get()
    {
        return InMemoryDatabase.Instance.GetData<ShoppingList>(ShoppingListTable);
    }

    public ShoppingList? Get(int id)
    {
        var result =  InMemoryDatabase.Instance.TryGetById<ShoppingList>(ShoppingListTable, id);

        if (result == null)
        {
            throw new Exception("Not found");
        }

        return result;
    }


    public void Add(ShoppingList shoppingList)
    {
        IsValid(shoppingList, Actions.Add);
        InMemoryDatabase.Instance.Add(ShoppingListTable, shoppingList);
    }

    public void Update(ShoppingList shoppingList)
    {
        IsValid(shoppingList, Actions.Update);
        InMemoryDatabase.Instance.Update(ShoppingListTable, shoppingList);

    }

    public void Delete(int id)
    {
        InMemoryDatabase.Instance.Delete<ShoppingList>(ShoppingListTable, id);
    }

    private void IsValid(ShoppingList entity, Actions action)
    {
        if (string.IsNullOrWhiteSpace(entity.Name))
        {
            throw new Exception("Invalid name");
        }

        ShoppingList? exists = default;
        if (action == Actions.Add)

            exists = InMemoryDatabase
               .Instance
               .GetData<ShoppingList>(ShoppingListTable)
               .FirstOrDefault(x => x.Name.Equals(entity.Name));

        else if (action == Actions.Update)
        {
            exists = InMemoryDatabase
               .Instance
               .GetData<ShoppingList>(ShoppingListTable)
               .FirstOrDefault(x => x.Name.Equals(entity.Name) && x.Id != entity.Id);
        }

        if (exists != null)
        {
            throw new Exception("Name already exists");
        }
    }

}
