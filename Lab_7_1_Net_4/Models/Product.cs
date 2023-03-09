using System;
using System.Collections.Generic;

namespace Lab_7_1_Net_4.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public string? Category { get; set; }

    public string? Color { get; set; }

    public decimal UnitPrice { get; set; }

    public int AvailableQuantity { get; set; }

    public DateTime CreatedDate { get; set; }
}
