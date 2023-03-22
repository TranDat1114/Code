using System;
using System.Collections.Generic;

namespace Lab_8_2_Net_4.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int BrandId { get; set; }

    public int CategoryId { get; set; }

    public decimal? Discount { get; set; }

    public virtual Brand Brand { get; set; } = null!;

    public virtual ICollection<CartItem> CartItems { get; } = new List<CartItem>();

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<ProductImage> ProductImages { get; } = new List<ProductImage>();

    public virtual ICollection<Review> Reviews { get; } = new List<Review>();
}
