namespace QuickLap.Data.Entities;

public class OrderItem
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int? Int1 { get; set; }
    public bool? Bool1 { get; set; }
    public DateTime? DateTime1 { get; set; }
    public DateTime? DateTime2Changed { get; set; }
}
