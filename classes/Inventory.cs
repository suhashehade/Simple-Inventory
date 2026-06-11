using System.ComponentModel;

public class Inventory
{
    public static List<Product> Products = new List<Product>();
    private static Inventory? _instatnce;
    private Inventory(){}
    public static Inventory? Instance
    {
        get
        { 
            if(_instatnce == null)
            {
                _instatnce = new Inventory();
            }
            return _instatnce;
        }
    }
<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
>>>>>>> 0c04885 (feat: create inventory & product classes)
    
    public static void AddProduct(Product product) {
        Products.Add(product);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("The product added successfully ✔️✔️");
        Console.ResetColor();
    }

<<<<<<< HEAD
=======
>>>>>>> 926b64f (feat: create inventory & product classes)
=======
    public static void DisplayProducts() {
        if(Products.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No products to display");
            Console.ResetColor();
        }
        Console.WriteLine("{0,-10} {1,-10} {2,-10}", "Name", "Price", "Quantity");
        Console.WriteLine("------------------------------------");
        foreach (var p in Products)
            {
                Console.WriteLine($"{ p.Name,-10 } { p.Price,-10 } { p.Quantity,-10 }");
            }
    }
>>>>>>> 7269152 (feat: create inventory & product classes)
>>>>>>> 0c04885 (feat: create inventory & product classes)

}
