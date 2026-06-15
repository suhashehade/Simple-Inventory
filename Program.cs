using System.Collections;


class Program
{
    enum MessageType
    {
        Error,
        Success,
        Warning,
        Info,
        Default
    }
    static void Main()
    {
        Console.ResetColor();
        Console.WriteLine("Welcome to this console-based inventory application 😎");
        DisplayInstructions();

        while (true)
        {
            Console.Write(@"inv cmd > ");
            string? input = Console.ReadLine()?.ToLower();
            Console.ResetColor();
            switch (input)
            {
                case "a":
                    {
                        string name = ReadValidString("Enter name: ");
                        double price = ReadValidDouble("Enter price: ");
                        int quantity = ReadValidInt("Enter quantity: ");

                        string msg = Inventory.AddProduct(name, price, quantity);
                        PrintMessage(msg, MessageType.Success);
                        break;
                    }
                case "r":
                    {
                        var products = Inventory.DisplayProducts();

                        if (products.Count == 0)
                        {
                            PrintMessage("No products ❌", MessageType.Error);
                            break;
                        }

                        Console.WriteLine("{0,-10} {1,-10} {2,-10}", "Name", "Price", "Quantity");

                        foreach (var p in products)
                        {
                            PrintMessage($"{p!.Name,-10} {p.Price,-10} {p.Quantity,-10}", MessageType.Info);
                        }
                        break;
                    }
                case "u":
                    {
                        string name = ReadValidString("Enter name: ");
                        var p = Inventory.SearchProduct(name);

                        if (p == null)
                        {
                            PrintMessage("Not found ❌", MessageType.Error);
                            break;
                        }

                        while (true)
                        {
                            Console.WriteLine("1 name | 2 price | 3 qty | 0 done");
                            string? choice = Console.ReadLine();

                            if (choice == "0") break;

                            string field = choice switch
                            {
                                "1" => "name",
                                "2" => "price",
                                "3" => "quantity",
                                _ => ""
                            };

                            if (field == "")
                            {
                                PrintMessage("Invalid ❌", MessageType.Error);
                                continue;
                            }

                            Console.Write("New value: ");
                            string? value = Console.ReadLine();

                            if (Inventory.EditProduct(p, field, value!))
                                PrintMessage("Updated ✔️", MessageType.Success);
                            else
                                PrintMessage("Invalid value ❌", MessageType.Error);
                        }

                        break;
                    }
                case "d":
                    {
                        string name = ReadValidString("Enter name: ");

                        bool deleted = Inventory.DeleteProduct(name);

                        if (deleted)
                            PrintMessage("Deleted ✔️", MessageType.Success);
                        else
                            PrintMessage("Not found ❌", MessageType.Error);

                        break;
                    }
                case "f":
                    {
                        string name = ReadValidString("Enter name: ");

                        var p = Inventory.SearchProduct(name);

                        if (p == null)
                            PrintMessage("Not found ❌", MessageType.Error);
                        else
                        {
                            Console.WriteLine("{0,-10} {1,-10} {2,-10}", "Name", "Price", "Quantity");
                            PrintMessage($"{p!.Name,-10} {p.Price,-10} {p.Quantity,-10}", MessageType.Info);
                        }

                        break;
                    }
                case "h":
                    {
                        DisplayInstructions();
                        break;
                    }
                case "q":
                    {
                        return;
                    }

                default:
                    Console.Clear();
                    Console.ResetColor();
                    Console.WriteLine("Invalid command");
                    break;

            }
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
        Console.ForegroundColor = type switch
        {
            MessageType.Error => ConsoleColor.Red,
            MessageType.Success => ConsoleColor.Green,
            MessageType.Warning => ConsoleColor.Yellow,
            MessageType.Info => ConsoleColor.Cyan,
            _ => ConsoleColor.White
        };

        Console.WriteLine(message);
        Console.ResetColor();
    }


}








