namespace OnlineOrdering;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double CalculateTotalCost()
    {
        double subtotal = 0;
        
        foreach (Product product in _products)
        {
            subtotal += product.GetTotalCost();
        }

        // Add shipping cost based on customer location
        double shippingCost = _customer.IsInUSA() ? 5.0 : 35.0;
        
        return subtotal + shippingCost;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "Packing Label:\n";
        
        foreach (Product product in _products)
        {
            packingLabel += $"{product.GetName()} (ID: {product.GetProductId()})\n";
        }
        
        return packingLabel;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
    }
    
}