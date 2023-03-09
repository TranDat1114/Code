using System;
using System.Collections.Generic;

namespace Lab_7_2_Net_4.Models;

public partial class ProductImage
{
    public int ProductImageId { get; set; }

    public int ProductId { get; set; }

    public string Uri { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
