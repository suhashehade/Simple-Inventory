using System.Collections;
Console.ResetColor();
Console.WriteLine("Welcome to this console-based inventory application 😎");
Inventory.DisplayInstructions();

while (true)
{
    Console.Write(@"inv cmd > ");
    string? input = Console.ReadLine()?.ToLower();
    Console.ResetColor();
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
        case "h":
            {
                Inventory.DisplayInstructions();
                break;
            }
        case "q":
            {
                return;
            }

        default:
            Console.Clear();
            Console.ResetColor();
            Console.WriteLine("Invalid command");
            break;

    }
}
