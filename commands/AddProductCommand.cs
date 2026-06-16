class AddProductCommand : ICommand
{
    enum MessageType
    {
        Error,
        Success,
        Warning,
        Info,
        Default
    }
    public void Execute()
    {
        string name = ReadValidString("Enter name: ");
        double price = ReadValidDouble("Enter price: ");
        int quantity = ReadValidInt("Enter quantity: ");

        string msg = Inventory.AddProduct(name, price, quantity);
        PrintMessage(msg, MessageType.Success);
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