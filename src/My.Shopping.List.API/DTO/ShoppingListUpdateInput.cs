namespace My.Shopping.List.API.DTO
{
    public class ShoppingListUpdateInput : ShoppingListInsertInput
    {
        public int Order { get; set; }
        public bool IsArchived { get; set; }

    }
}
