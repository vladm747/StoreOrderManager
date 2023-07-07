using DAL.Entities.Base;
using System;
using System.Collections.Generic;

namespace DAL.Entities;

public class Region : BaseEntity<int>
{
    public string RegionDescription { get; set; } = string.Empty;

    public ICollection<Territory> Territories { get; set; } = null!;
}
