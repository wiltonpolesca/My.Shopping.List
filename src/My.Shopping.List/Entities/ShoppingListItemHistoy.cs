namespace My.Shopping.List.Entities;

public class ShoppingListItemHistory : Entity
{
    public ShoppingListItem? ListItem { get; set; }
    public int Qtde { get; set; } = 0;
    public double Price { get; set; } = 0;
    public string Store { get; set; } = string.Empty;
}
