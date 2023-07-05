using DAL.Entities.Base;
using System;
using System.Collections.Generic;

namespace DAL.Entities;

public class Territory : BaseEntity<string>
{
    public string TerritoryDescription { get; set; } = string.Empty;
    public int RegionId { get; set; }

    public virtual Region Region { get; set; } = null!;
    public virtual ICollection<Employee> Employees { get; set; } = null!;
}
