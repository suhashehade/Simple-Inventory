using System.Diagnostics;

class ExitCommand : ICommand
{

    public void Execute()
    {
        Environment.Exit(0);
    }

}