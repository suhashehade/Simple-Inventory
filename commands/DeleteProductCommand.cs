class DeleteProductCommand : ICommand
{

    public void Execute()
    {
        string name = Validator.ReadValidString("Enter name: ");

        bool deleted = Inventory.DeleteProduct(name);

        if (deleted)
            Logger.PrintMessage("Deleted ✔️", Logger.MessageType.Success);
        else
            Logger.PrintMessage("Not found ❌", Logger.MessageType.Error);
    }


}