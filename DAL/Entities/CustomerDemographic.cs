using DAL.Entities.Base;
using System;
using System.Collections.Generic;

namespace DAL.Entities;

public class CustomerDemographic : BaseEntity<string>
{
    public string? CustomerDesc { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = null!;
}
