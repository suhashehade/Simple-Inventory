using System.ComponentModel;

public static class Inventory
{
    public static List<Product> Products = new List<Product>();

    private static Product? FindProduct(string name)
    {
        return Products.FirstOrDefault(p => p.Name!.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
    public static void AddProduct()
    {
        Console.WriteLine("""
                I will ask you to enter the name, price, and quantitiy of the product.
                First of all, enter the name of the product ...
                """);
        string? name = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(name))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid name ❌");
            Console.ResetColor();
            name = Console.ReadLine();
        }
        Console.WriteLine("Now, enter the price of the product:");
        string? priceInput = Console.ReadLine();
        double price;
        while (!double.TryParse(priceInput, out price))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid price ❌");
            Console.ResetColor();
            priceInput = Console.ReadLine();
        }

        Console.WriteLine("Finally, enter the quantity of the product:");
        string? quantitiyInput = Console.ReadLine();
        int quanitiy;
        while (!int.TryParse(quantitiyInput, out quanitiy))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid quanitiy ❌");
            Console.ResetColor();
            quantitiyInput = Console.ReadLine();
        }

        Product product = new Product(name!, price, quanitiy);
        Products.Add(product);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("The product added successfully ✔️✔️");
        Console.ResetColor();
    }

    public static void DisplayProducts()
    {
        Console.WriteLine("""
                All products:
                """);
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

    public static void EditProduct()
    {
        Console.Write("Enter product's name to edit: ");
        string? name = Console.ReadLine();
        Product? p = FindProduct(name!);

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
                    if (double.TryParse(Console.ReadLine(), out double price))
                    {
                        p.Price = price;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid price ❌");
                        Console.ResetColor();
                    }
                    break;

                case "3":
                    if (int.TryParse(Console.ReadLine(), out int qty))
                    {
                        p.Quantity = qty;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid quantity ❌");
                        Console.ResetColor();
                    }
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }

    }
    public static void DeleteProduct()
    {
        Console.Write("Enter product's name to delete: ");
        string? name = Console.ReadLine();
        Product? p = FindProduct(name!);
        if (p == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Product not found");
            Console.ResetColor();
        }
        else
        {
            Products.Remove(p);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Product deleted sucessfully");
            Console.ResetColor();
        }

    }

    public static void SearchProduct()
    {
        Console.Write("Enter product's name to search: ");
        string? name = Console.ReadLine();
        Product? p = FindProduct(name!);
        if (p == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Product not found");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine($"Product name is: {p.Name}, price: {p.Price}, and quantity: {p.Quantity}");

        }

    }
    public static void DisplayInstructions()
    {
        Console.WriteLine("""
        Insructions:
        Press H to display instructions
        Press A to add product
        Press R to display the products
        Press U to edit product
        Press D to delete product
        Press F to search product
        Press Q to Exit application
        ---------------------------------------
        """);

    }

}
