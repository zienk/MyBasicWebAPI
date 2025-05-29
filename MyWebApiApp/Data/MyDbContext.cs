using Microsoft.EntityFrameworkCore;

namespace MyWebApiApp.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        #region DbSets
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(e =>
            {
                e.ToTable("Orders");
                e.HasKey(order => order.OrderId);
                e.Property(order => order.OrderDay).HasDefaultValueSql("getutcdate()");
                e.Property(order => order.Receiver).IsRequired().HasMaxLength(100);
            });

            // Bảng OderDetail có 2 khóa ngoại là OrderId và ProductId để giải quyết mối quan hệ nhiều-nhiều giữa Order và Product
            modelBuilder.Entity<OrderDetail>(e =>
            {
                e.ToTable("OrderDetails");
                e.HasKey(od => new { od.OrderId, od.ProductId });

                e.HasOne(od => od.Order)
                    .WithMany(o => o.OrderDetails)
                    .HasForeignKey(od => od.OrderId)
                    .HasConstraintName("FK_OrderDetails_Orders");

                e.HasOne(od => od.Product)
                    .WithMany(o => o.OrderDetails)
                    .HasForeignKey(od => od.ProductId)
                    .HasConstraintName("FK_OrderDetails_Products ");

            });

        }

    }
}
