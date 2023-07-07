using System;
using System.Collections.Generic;

namespace DAL.Entities;

public class OrderDetail
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public decimal UnitPrice { get; set; }
    public short Quantity { get; set; }
    public float Discount { get; set; }

    public Order Order { get; set; } = null!;
    public Product Product { get; set; } = null!;
}
