namespace My.Shopping.List.Entities;

public class ShoppingList
{
    public ShoppingList()
    {
        Name = string.Empty;
        Items = new List<ShoppingListItem>();
    }

    public ShoppingList(string name)
        : this()
    {
        Name = name;
    }

    public string Name { get; set; }
    public IList<ShoppingListItem> Items { get; private set; }

    public double TotalValue()
    {
        var total = 0.0;
        foreach (var item in Items)
        {
            if (item.IsChecked)
            {
                total += item.Qtde * item.Price;
            }
        }

        return total;
    }
}
