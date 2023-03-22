using System;
using System.Collections.Generic;

namespace Lab_8_2_Net_4.Models;

public partial class Account
{
    public int AccountId { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public virtual ICollection<Cart> Carts { get; } = new List<Cart>();
}
