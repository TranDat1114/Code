using Microsoft.EntityFrameworkCore;

namespace Lab_7_2_Net_4.Models;

public partial class ShopBanCamContext: DbContext
{
    public ShopBanCamContext()
    {
    }

    public ShopBanCamContext(DbContextOptions<ShopBanCamContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductImage> ProductImages { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

    //    => optionsBuilder.UseSqlServer("Server=HOANG-TRAN\\MOONSERVER; user=sa; password=iloveuzienoi1114; Database= ShopBanCam; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.Property(e => e.BrandName).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(500);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.CategoriesImg)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValueSql("('https://www.ephotozine.com/articles/best-cameras-for-wildlife-photography-2019-33961/images/highres-Canon-EOS-R-3_1536142276.jpg')");
            entity.Property(e => e.CategoryName).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(500);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Discount)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductName).HasMaxLength(100);

            entity.HasOne(d => d.Brand).WithMany(p => p.Products)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Brands");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Categories");
        });

        modelBuilder.Entity<ProductImage>(entity =>
        {
            entity.Property(e => e.Uri).HasMaxLength(500);

            entity.HasOne(d => d.Product).WithMany(p => p.ProductImages)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductImages_Products");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.Property(e => e.ReviewText).HasMaxLength(500);
            entity.Property(e => e.ReviewerName).HasMaxLength(100);

            entity.HasOne(d => d.Product).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reviews_Products");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
