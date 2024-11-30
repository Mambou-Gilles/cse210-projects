using System.Runtime.InteropServices;

public class Product
{


    private string _name;
    private string _productId;
    private decimal _price;
    private int _quantity;

    public Product(string name, string id, decimal price, int quantity){
        _name = name;
        _productId = id;
        _price = price;
        _quantity = quantity;
    }
    public string GetName() => _name;
    public string GetProductId() => _productId;

    public decimal GetPrice() => _price;

    public int GetQuantity() => _quantity;

    public decimal GetTotalCost(){
        return _price * _quantity;
    }

}