class DeleteProductCommand : ICommand
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

        bool deleted = Inventory.DeleteProduct(name);

        if (deleted)
            PrintMessage("Deleted ✔️", MessageType.Success);
        else
            PrintMessage("Not found ❌", MessageType.Error);
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