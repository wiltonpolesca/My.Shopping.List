namespace My.Shopping.List.Entities;

public class ShoppingList : Entity
{
    public string Name { get; set; } = string.Empty;
    public int Order { get; set; }
    public IList<ShoppingListItem> Items { get; private set; } = new List<ShoppingListItem>();

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
