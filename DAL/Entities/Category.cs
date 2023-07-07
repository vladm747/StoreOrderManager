using DAL.Entities.Base;
using System;
using System.Collections.Generic;

namespace DAL.Entities;

public class Category : BaseEntity<int>
{
    public string CategoryName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public byte[]? Picture { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>();
}
