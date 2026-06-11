using System.Collections;

Console.WriteLine("""
        Insructions:
        Press A to add product
        Press R to display the products
        Press U to edit product
        Press D to delete product
        Press F to search product
        Press Q to Exit application
        ---------------------------------------
        """);
string? input = Console.ReadLine();
while (true)
{
    switch (input?.ToLower())
    {
        case "a":
            {
                Console.WriteLine("""
                I will ask you to enter the name, price, and quantitiy of the product.
                First of all, enter the name of the product ...
                """);
                string? nameInput = Console.ReadLine();
                string name = nameInput!;
                while (name == "")
                {
                    Console.WriteLine("Invalid Name 😞💔");
                    nameInput = Console.ReadLine();
                    name = nameInput!;
                }
                Console.WriteLine("Now, enter the price of the product:");
                string? priceInput = Console.ReadLine();
                double price;
                while (!double.TryParse(priceInput, out price))
                {
                    Console.WriteLine("Invalid Price 😞💔");
                    priceInput = Console.ReadLine();
                }

                Console.WriteLine("Finally, enter the quantity of the product:");
                string? quantitiyInput = Console.ReadLine();
                int quanitiy;
                while (!int.TryParse(quantitiyInput, out quanitiy))
                {
                    Console.WriteLine("Invalid quantitiy 😞💔");
                    quantitiyInput = Console.ReadLine();
                }

                Product product = new Product(name, price, quanitiy);
                Inventory.AddProduct(product);
                break;
            }
        case "r":
            {
                Console.WriteLine("""
                All products:
                """);
                Inventory.DisplayProducts();
                break;
            }
        case "u":
            {
                Console.Write("Enter product's name to edit: ");
                string? nameInput = Console.ReadLine();
                string name;
                if (nameInput != "")
                {
                    name = nameInput!;
                    Inventory.EditProduct(name);

                }
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

    }
    input = Console.ReadLine();
}
