﻿namespace QuickLap.Data.Entities;

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime? DateTime1 { get; set; }

    public List<Order> Orders { get; set; }
    public List<EntityOne> EntityOnes { get; set; }
}
