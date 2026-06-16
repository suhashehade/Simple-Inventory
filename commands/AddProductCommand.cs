class AddProductCommand : ICommand
{

    public void Execute()
    {
        string name = Validator.ReadValidString("Enter name: ");
        double price = Validator.ReadValidDouble("Enter price: ");
        int quantity = Validator.ReadValidInt("Enter quantity: ");

        string msg = Inventory.AddProduct(name, price, quantity);
        Logger.PrintMessage(msg, Logger.MessageType.Success);
    }

}