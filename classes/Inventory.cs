using System.ComponentModel;

public class Inventory
{
    public static List<Product> Products = new List<Product>();
    private static Inventory? _instatnce;
    private Inventory() { }
    public static Inventory? Instance
    {
        get
        {
            if (_instatnce == null)
            {
                _instatnce = new Inventory();
            }
            return _instatnce;
        }
    }

    public static void AddProduct(Product product)
    {
        Products.Add(product);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("The product added successfully ✔️✔️");
        Console.ResetColor();
    }

    public static void DisplayProducts()
    {
        if (Products.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No products to display");
            Console.ResetColor();
        }
        Console.WriteLine("{0,-10} {1,-10} {2,-10}", "Name", "Price", "Quantity");
        Console.WriteLine("------------------------------------");
        foreach (var p in Products)
        {
            Console.WriteLine($"{p.Name,-10} {p.Price,-10} {p.Quantity,-10}");
        }
    }



}
