class Logger
{
    public enum MessageType
    {
        Error,
        Success,
        Warning,
        Info,
        Default
    }

    public static void PrintMessage(string message, MessageType type)
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