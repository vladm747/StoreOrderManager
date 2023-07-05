using DAL.Entities.Base;
using System;
using System.Collections.Generic;

namespace DAL.Entities;

public class Order : BaseEntity<int>
{
    public string? CustomerId { get; set; }
    public int? EmployeeId { get; set; }
    public int? ShipperId { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? RequiredDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public decimal? Freight { get; set; }
    public string? ShipName { get; set; }
    public string? ShipAddress { get; set; }
    public string? ShipCity { get; set; }
    public string? ShipRegion { get; set; }
    public string? ShipPostalCode { get; set; }
    public string? ShipCountry { get; set; }

    public virtual Customer? Customer { get; set; }
    public virtual Employee? Employee { get; set; }
    public virtual Shipper? ShipperNavigation { get; set; }
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = null!;
}
