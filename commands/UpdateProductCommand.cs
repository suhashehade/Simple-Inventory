class UpdateProductCommand : ICommand
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
        {
            PrintMessage("Not found ❌", MessageType.Error);
            return;
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