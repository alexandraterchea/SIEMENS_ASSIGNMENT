namespace SieMarket;

public class OrderService
{
    private List<Order> _orders = new();
    public void AddOrder(Order order) => _orders.Add(order);

    public string? GetTopSpendingCustomer()
    {
        return _orders 
            .GroupBy(o => o.CustomerName)
            .Select(g => new { CustomerName = g.Key, TotalSpent = g.Sum(o => o.CalculateFinalPrice()) })
            .OrderByDescending(x => x.TotalSpent)
            .First()
            .CustomerName;
    }

    public Dictionary<string, int> GetPopularProducts()
    {
        var result = new Dictionary<string, int>();
        foreach(var order in _orders)
            foreach(var item in order.Items)
            {
                if(item.ProductName == null) continue;
                if (result.ContainsKey(item.ProductName))
                    result[item.ProductName] += item.Quantity;
                else
                    result[item.ProductName] = item.Quantity;
            }
        return result;
    }
}