namespace SieMarket;

public class Order
{
    public int Id { get; set; }
    public string? CustomerName { get; set; }
    public List<OrderItem> Items { get; set; } = new();

    public decimal CalculateFinalPrice()
    {
        decimal total=Items.Sum(i => i.Price * i.Quantity);
        if(total>500)
            total=total*(decimal)0.9;
        return total;
    }
        
}