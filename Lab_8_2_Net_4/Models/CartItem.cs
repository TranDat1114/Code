using System;
using System.Collections.Generic;

namespace Lab_8_2_Net_4.Models;

public partial class CartItem
{
    public int Itemid { get; set; }

    public int CartId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public virtual Cart Cart { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
