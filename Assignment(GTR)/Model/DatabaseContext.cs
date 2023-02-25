using Microsoft.EntityFrameworkCore;

namespace Assignment_GTR_.Model
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }
        public virtual DbSet<ProductInfo>? ProductInfos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductInfo>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("ProductInformation");
                entity.Property(e => e.Id);
                entity.Property(e => e.CategoryName);
                entity.Property(e => e.UnitName);
                entity.Property(e => e.Name);
                entity.Property(e => e.Code);
                entity.Property(e => e.ParentCode);
                entity.Property(e => e.ProductBarcode);
                entity.Property(e => e.Description);
                entity.Property(e => e.BrandName);
                entity.Property(e => e.SizeName);
                entity.Property(e => e.ColorName);
                entity.Property(e => e.ModelName);
                entity.Property(e => e.VariantName);
                entity.Property(e => e.OldPrice);
                entity.Property(e => e.Price);
                entity.Property(e => e.CostPrice);
                entity.Property(e => e.WarehouseList);
                entity.Property(e => e.stock);
                entity.Property(e => e.TotalPurchase);
                entity.Property(e => e.LastPurchaseDate);
                entity.Property(e => e.LastPurchaseSupplier);
                entity.Property(e => e.TotalSales);
                entity.Property(e => e.LastSalesDate);
                entity.Property(e => e.LastSalesCustomer);
                entity.Property(e => e.ImagePath);
                entity.Property(e => e.Type);
                entity.Property(e => e.simple);
            });
            //OnModelCreatingPartial(modelBuilder);
        }
        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}