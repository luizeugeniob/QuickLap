﻿namespace QuickLap.Data.Entities;

public class OrderItem
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
}