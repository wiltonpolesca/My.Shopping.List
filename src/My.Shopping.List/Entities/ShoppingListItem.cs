namespace My.Shopping.List.Entities;

public class ShoppingListItem
{
    public string Name { get; set; } = string.Empty;
    public int Qtde { get; set; }
    public double Price { get; set; }
    public bool IsChecked { get; set; } = true;
}
