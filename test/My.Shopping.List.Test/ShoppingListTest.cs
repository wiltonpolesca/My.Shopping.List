using FluentAssertions;
using My.Shopping.List.Entities;
using My.Shopping.List.Repository;

namespace My.Shopping.List.Test;

public class ShoppingListTest
{
    [Fact]
    public void Should_total_value_be_100()
    {
        var shopList = new ShoppingList
        {
            Name = "Minha lista de test"
        };
        for (int i = 0; i < 10; i++)
        {
            shopList.Items.Add(new ShoppingListItem { Qtde = 1, Price = 10.0 });
        }
        shopList.Items.Add(new ShoppingListItem { Name = "Arroz", Qtde = 1, Price = 10.0, IsChecked = false });

        shopList.TotalValue().Should().Be(100.0);
    }

    [Fact]
    public void Should_be_possible_store_list_in_memory()
    {
        //InMemoryDatabase.Instance
    }
}