namespace ShoppingCart.Lib
{
    public interface IProduct
    {
        int ProductID { get; set; }
        string ProductName { get; set; }

        decimal Price { get; set; }

    }
}