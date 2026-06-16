using System.Collections;


class Program
{
    static void Main()
    {
        Console.ResetColor();
        Logger.PrintMessage("Welcome to this console-based inventory application 😎", Logger.MessageType.Default);
        new HelpCommand().Execute();
        var commands = new Dictionary<string, ICommand>
            {
                { "a", new AddProductCommand() },
                { "r", new DisplayProductsCommand() },
                { "u", new UpdateProductCommand() },
                { "d", new DeleteProductCommand() },
                { "f", new FindProductCommand() },
                { "h", new HelpCommand() },
                { "q", new ExitCommand() }
            };
        while (true)
        {
            Console.Write(@"inv cmd > ");
            string? input = Console.ReadLine()?.ToLower();
            Console.ResetColor();

            if (commands.TryGetValue(input!, out var command))
            {
                command.Execute();
            }
            else
            {
                Logger.PrintMessage("Invalid command ❌", Logger.MessageType.Error);
            }

        }
    }


}