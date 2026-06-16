class FindProductCommand : ICommand
{

    public void Execute()
    {
        string name = Validator.ReadValidString("Enter name: ");

        var p = Inventory.SearchProduct(name);

        if (p == null)
            Logger.PrintMessage("Not found ❌", Logger.MessageType.Error);
        else
        {
            Console.WriteLine("{0,-10} {1,-10} {2,-10}", "Name", "Price", "Quantity");
            Logger.PrintMessage($"{p!.Name,-10} {p.Price,-10} {p.Quantity,-10}", Logger.MessageType.Info);
        }

    }

}