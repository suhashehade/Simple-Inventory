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

    public static void EditProduct(string name)
    {
        Product? p = Products.FirstOrDefault(product => product.Name == name);
        if (p == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Product not found");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine("What do you want to edit?");
            Console.WriteLine("1 => Name");
            Console.WriteLine("2 => Price");
            Console.WriteLine("3 => Quantity");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("New name: ");
                    p.Name = Console.ReadLine();
                    break;

                case "2":
                    Console.Write("New price: ");
                    p.Price = double.Parse(Console.ReadLine()!);
                    break;

                case "3":
                    Console.Write("New quantity: ");
                    p.Quantity = int.Parse(Console.ReadLine()!);
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }

    }

}
