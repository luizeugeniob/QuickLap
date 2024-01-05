namespace QuickLap.Data.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string? String1 { get; set; }
    public string? String2Changed { get; set; }

    public List<OrderItem> OrderItems { get; set; }
}
