namespace NET_4_ASM_API.Models;

public partial class Cart
{
    public int CartId { get; set; }

    public int AccountId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<CartItem> CartItems { get; } = new List<CartItem>();
}
