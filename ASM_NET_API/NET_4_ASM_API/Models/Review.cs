namespace NET_4_ASM_API.Models;

public partial class Review
{
    public int ReviewId { get; set; }

    public int ProductId { get; set; }

    public string ReviewerName { get; set; } = null!;

    public string? ReviewText { get; set; }

    public int Rating { get; set; }

    public virtual Product Product { get; set; } = null!;
}
