class UpdateProductCommand : ICommand
{

    public void Execute()
    {
        string name = Validator.ReadValidString("Enter name: ");
        var p = Inventory.SearchProduct(name);

        if (p == null)
        {
            Logger.PrintMessage("Not found ❌", Logger.MessageType.Error);
            return;
        }

        while (true)
        {
            Console.WriteLine("1 name | 2 price | 3 qty | 0 done");
            string? choice = Console.ReadLine();

            if (choice == "0") break;

            string field = choice switch
            {
                "1" => "name",
                "2" => "price",
                "3" => "quantity",
                _ => ""
            };

            if (field == "")
            {
                Logger.PrintMessage("Invalid ❌", Logger.MessageType.Error);
                continue;
            }

            Console.Write("New value: ");
            string? value = Console.ReadLine();

            if (Inventory.EditProduct(p, field, value!))
                Logger.PrintMessage("Updated ✔️", Logger.MessageType.Success);
            else
                Logger.PrintMessage("Invalid value ❌", Logger.MessageType.Error);
        }

    }

}