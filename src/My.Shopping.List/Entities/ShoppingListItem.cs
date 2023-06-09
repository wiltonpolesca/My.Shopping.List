﻿using My.Core.Abstracts;

namespace My.Shopping.List.Entities;

public class ShoppingListItem : Entity
{
    public int ShoppingListId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Qtde { get; set; }
    public double Price { get; set; }
    public bool IsChecked { get; set; }
}
