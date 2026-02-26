using SieMarket;

var service = new OrderService();

var order1 = new Order { Id = 1,CustomerName="Alexandra" };
order1.Items.Add(new OrderItem { ProductName = "Phone", Quantity = 2, Price = 999 });

var order2 = new Order { Id = 2, CustomerName = "Lacramioara" };
order2.Items.Add(new OrderItem { ProductName = "Watch", Quantity = 1, Price = 100 });

var order3 = new Order { Id = 3, CustomerName = "Bob" };
order3.Items.Add(new OrderItem { ProductName = "Headphones", Quantity = 3, Price = 50 });

var order4 = new Order { Id = 4, CustomerName = "Lacramioara" };
order4.Items.Add(new OrderItem { ProductName = "Phone", Quantity = 2, Price = 999});

service.AddOrder(order1);
service.AddOrder(order2);
service.AddOrder(order3);
service.AddOrder(order4);

Console.WriteLine("Order 1 final price: " + order1.CalculateFinalPrice());
Console.WriteLine("Order 2 final price: " + order2.CalculateFinalPrice());
Console.WriteLine("Order 3 final price: " + order3.CalculateFinalPrice());
Console.WriteLine("Top spending customer: " + service.GetTopSpendingCustomer());
Console.WriteLine("Popular products:");
foreach(var product in service.GetPopularProducts())
    Console.WriteLine(product.Key + ": " + product.Value);