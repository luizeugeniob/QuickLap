namespace QuickLap.Data.Entities;

public class Order
{
    public int Id { get; set; }
    public DateTime CreationDate { get; set; }
    public int CustomerId { get; set; }

    public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
