using System.ComponentModel;

public static class Inventory
{
    enum MessageType
    {
        Error,
        Success,
        Warning,
        Info,
        Default
    }

    private static readonly List<Product> Products = [];

    private static Product? FindProduct(string name)
    {
        return Products.FirstOrDefault(p => p.Name!.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public static void AddProduct()
    {
        string name = ReadValidString("Enter product name: ");
        double price = ReadValidDouble("Enter price: ");
        int quantity = ReadValidInt("Enter quantity: ");

        Products.Add(new Product
        {
            Name = name,
            Price = price,
            Quantity = quantity
        });

        PrintMessage("Product added ✔️✔️", MessageType.Success);
    }

    public static void DisplayProducts()
    {
        PrintMessage("""
                All products:
                """, MessageType.Info);
        if (Products.Count == 0)
        {
            PrintMessage("No products to display", MessageType.Error);
        }
        Console.WriteLine("{0,-10} {1,-10} {2,-10}", "Name", "Price", "Quantity");
        Console.WriteLine("------------------------------------");
        foreach (var product in Products)
        {
            PrintMessage($"{product.Name,-10} {product.Price,-10} {product.Quantity,-10}", MessageType.Default);
        }
    }

    public static void EditProduct()
    {
        Console.Write("Enter product's name to edit: ");
        string? name = Console.ReadLine();

        Product? p = FindProduct(name!);

        if (p == null)
        {
            PrintMessage("Product not found ❌", MessageType.Error);
            return;
        }

        while (true)
        {
            PrintMessage($"""
                    Editing: {p.Name} | Price: {p.Price} | Quantity: {p.Quantity}
                    What do you want to edit?
                    1 => Name
                    2 => Price
                    3 => Quantity
                    0 => Done
                    """, MessageType.Info);

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    p.Name = ReadValidString("New name: ");
                    break;

                case "2":
                    p.Price = ReadValidDouble("New price: ");
                    break;

                case "3":
                    p.Quantity = ReadValidInt("New quantity: ");
                    break;

                case "0":
                    PrintMessage("Finished editing ✔️✔️", MessageType.Success);
                    return;

                default:
                    PrintMessage("Invalid choice ❌", MessageType.Error);
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
            PrintMessage("Product not found ❌", MessageType.Error);
        }
        else
        {
            Products.Remove(p);
            PrintMessage("Product deleted sucessfully", MessageType.Success);
        }

    }

    public static void SearchProduct()
    {
        Console.Write("Enter product's name to search: ");
        string? name = Console.ReadLine();
        Product? p = FindProduct(name!);
        if (p == null)
        {
            PrintMessage("Product not found ❌", MessageType.Error);
        }
        else
        {
            PrintMessage($"Product name is: {p.Name}, price: {p.Price}, and quantity: {p.Quantity}", MessageType.Info);
        }

    }

    public static void DisplayInstructions()
    {
        PrintMessage("""
        Insructions:
        Press H to display instructions
        Press A to add product
        Press R to display the products
        Press U to edit product
        Press D to delete product
        Press F to search product
        Press Q to Exit application
        ---------------------------------------
        """, MessageType.Info);

    }

    private static string ReadValidString(string message)
    {
        Console.Write(message);
        string? input = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(input))
        {
            PrintMessage("Invalid input ❌", MessageType.Error);
            input = Console.ReadLine();
        }

        return input;
    }

    private static double ReadValidDouble(string message)
    {
        Console.Write(message);

        while (true)
        {
            string? input = Console.ReadLine();

            if (!double.TryParse(input, out double value))
            {
                PrintMessage("Invalid number ❌", MessageType.Error);
                continue;
            }

            if (value <= 0)
            {
                PrintMessage("Must be > 0 ❌", MessageType.Error);
                continue;
            }

            return value;
        }
    }

    private static int ReadValidInt(string message)
    {
        Console.Write(message);

        while (true)
        {
            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int value))
            {
                PrintMessage("Invalid number ❌", MessageType.Error);
                continue;
            }

            if (value <= 0)
            {
                PrintMessage("Must be > 0 ❌", MessageType.Error);
                continue;
            }

            return value;
        }
    }

    private static void PrintMessage(string message, MessageType type)
    {
        switch (type)
        {
            case MessageType.Error:
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                }
            case MessageType.Success:
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                }
            case MessageType.Warning:
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                }
            case MessageType.Info:
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                }
            default:
                Console.ForegroundColor = ConsoleColor.White;
                break;
        }

        Console.WriteLine(message);
        Console.ResetColor();
    }


}
