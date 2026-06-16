class DisplayProductsCommand : ICommand
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
        var products = Inventory.DisplayProducts();

        if (products.Count == 0)
        {
            PrintMessage("No products ❌", MessageType.Error);
            return;
        }

        Console.WriteLine("{0,-10} {1,-10} {2,-10}", "Name", "Price", "Quantity");

        foreach (var p in products)
        {
            PrintMessage($"{p!.Name,-10} {p.Price,-10} {p.Quantity,-10}", MessageType.Info);
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