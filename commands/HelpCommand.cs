class HelpCommand : ICommand
{

    public void Execute()
    {
        Logger.PrintMessage("""
        Insructions:
        Press H to display instructions
        Press A to add product
        Press R to display the products
        Press U to edit product
        Press D to delete product
        Press F to search product
        Press Q to Exit application
        ---------------------------------------
        """, Logger.MessageType.Info);
    }


}