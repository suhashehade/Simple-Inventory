class FindProductCommand : ICommand
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

        var p = Inventory.SearchProduct(name);

        if (p == null)
            PrintMessage("Not found ❌", MessageType.Error);
        else
        {
            Console.WriteLine("{0,-10} {1,-10} {2,-10}", "Name", "Price", "Quantity");
            PrintMessage($"{p!.Name,-10} {p.Price,-10} {p.Quantity,-10}", MessageType.Info);
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