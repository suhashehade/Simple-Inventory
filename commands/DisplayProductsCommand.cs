class DisplayProductsCommand : ICommand
{
    public void Execute()
    {
        var products = Inventory.DisplayProducts();

        if (products.Count == 0)
        {
            Logger.PrintMessage("No products ❌", Logger.MessageType.Error);
            return;
        }

        Console.WriteLine("{0,-10} {1,-10} {2,-10}", "Name", "Price", "Quantity");

        foreach (var p in products)
        {
            Logger.PrintMessage($"{p!.Name,-10} {p.Price,-10} {p.Quantity,-10}", Logger.MessageType.Info);
        }
    }


}