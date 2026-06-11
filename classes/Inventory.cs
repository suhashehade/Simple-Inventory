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

}
