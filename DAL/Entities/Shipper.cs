using DAL.Entities.Base;
using System;
using System.Collections.Generic;

namespace DAL.Entities;

public class Shipper : BaseEntity<int>
{
    public string CompanyName { get; set; } = null!;
    public string? Phone { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = null!;
}
