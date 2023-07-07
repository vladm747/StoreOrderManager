using DAL.Entities.Base;
using System;
using System.Collections.Generic;

namespace DAL.Entities;

public class CustomerDemographic : BaseEntity<string>
{
    public string? CustomerDesc { get; set; }

    public ICollection<Customer> Customers { get; set; } = null!;
}
