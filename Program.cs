using System.Collections;
Console.WriteLine("Welcome to this console-based inventory application 😎");
Inventory.DisplayInstructions();
while (true)
{
    Console.Write(@"inv cmd > ");
    string? input = Console.ReadLine()?.ToLower();
    switch (input)
    {
        case "a":
            {
                Inventory.AddProduct();
                break;
            }
        case "r":
            {
                Inventory.DisplayProducts();
                break;
            }
        case "u":
            {
                Inventory.EditProduct();
                break;
            }
        case "d":
            {
                Inventory.DeleteProduct();
                break;
            }
        case "f":
            {
                Inventory.SearchProduct();
                break;
            }
        case "i":
            {
                Inventory.DisplayInstructions();
                break;
            }

        default:
            Console.Clear();
            Console.WriteLine("Invalid command");
            break;

    }
}
