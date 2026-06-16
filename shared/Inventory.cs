using System.ComponentModel;

public static class Inventory
{


    private static readonly List<Product> Products = [];


    public static string AddProduct(string name, double price, int quantity)
    {
        Products.Add(new Product
        {
            Name = name,
            Price = price,
            Quantity = quantity
        });

        return "Product added ✔️✔️";
    }

    public static List<Product> DisplayProducts()
    {
        return Products;
    }

    public static bool EditProduct(Product p, string field, string value)
    {
        switch (field)
        {
            case "name":
                p.Name = value;
                return true;

            case "price":
                if (double.TryParse(value, out double price) && price > 0)
                {
                    p.Price = price;
                    return true;
                }
                return false;

            case "quantity":
                if (int.TryParse(value, out int qty) && qty > 0)
                {
                    p.Quantity = qty;
                    return true;
                }
                return false;

            default:
                return false;
        }
    }
    public static bool DeleteProduct(string name)
    {
        Product? p = SearchProduct(name!);

        if (p == null) return false;

        Products.Remove(p);
        return true;
    }

    public static Product? SearchProduct(string name)
    {
        return Products.FirstOrDefault(p => p.Name!.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

}
