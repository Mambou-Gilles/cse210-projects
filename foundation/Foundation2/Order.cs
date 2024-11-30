using System.Text;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer){
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product){
        _products.Add(product);
    }

    public decimal TotalCost(){
        decimal total = 0;
        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }
        
        if (_customer.LivesInUSA()) {
            total += 5;
        } else {
            total += 35;
        }
        return total;
    }

    public string GetPackingLabel(){
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Packing Label:");
        foreach (Product product in _products){
            sb.AppendLine($"{product.GetName()} (ID: {product.GetProductId()})");
        }
        return sb.ToString();
    }

    public string GetShippingLabel(){
        return $"Shipping Label: \n{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
    }
}