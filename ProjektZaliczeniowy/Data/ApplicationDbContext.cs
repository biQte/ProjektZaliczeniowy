using Microsoft.EntityFrameworkCore;
using ProjektZaliczeniowy.Models.Entities;

namespace ProjektZaliczeniowy.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ExternalReceipt> ExternalReceipts { get; set; }
        public DbSet<ExternalReceiptDetail> ExternalReceiptDetails { get; set; }
        public DbSet<InternalReceipt> InternalReceipts { get; set; }
        public DbSet<InternalReceiptDetail> InternalReceiptDetails { get; set; }
        public DbSet<InternalIssue> InternalIssues { get; set; }
        public DbSet<InternalIssueDetail> InternalIssueDetails { get; set; }
        public DbSet<ExternalIssue> ExternalIssues { get; set; }
        public DbSet<ExternalIssueDetail> ExternalIssueDetails { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ExternalReceiptDetail relationships
            modelBuilder.Entity<ExternalReceiptDetail>()
                .HasOne(d => d.ExternalReceipt)
                .WithMany(r => r.Details)
                .HasForeignKey(d => d.ExternalReceiptId);

            modelBuilder.Entity<ExternalReceiptDetail>()
                .HasOne(d => d.Product)
                .WithMany(p => p.ExternalReceiptDetails)
                .HasForeignKey(d => d.ProductId);

            // InternalReceiptDetail relationships
            modelBuilder.Entity<InternalReceiptDetail>()
                .HasOne(d => d.InternalReceipt)
                .WithMany(r => r.Details)
                .HasForeignKey(d => d.InternalReceiptId);

            modelBuilder.Entity<InternalReceiptDetail>()
                .HasOne(d => d.Product)
                .WithMany(p => p.InternalReceiptDetails)
                .HasForeignKey(d => d.ProductId);

            // InternalIssueDetail relationships
            modelBuilder.Entity<InternalIssueDetail>()
                .HasOne(d => d.InternalIssue)
                .WithMany(r => r.Details)
                .HasForeignKey(d => d.InternalIssueId);

            modelBuilder.Entity<InternalIssueDetail>()
                .HasOne(d => d.Product)
                .WithMany(p => p.InternalIssueDetails)
                .HasForeignKey(d => d.ProductId);

            // ExternalIssueDetail relationships
            modelBuilder.Entity<ExternalIssueDetail>()
                .HasOne(d => d.ExternalIssue)
                .WithMany(r => r.Details)
                .HasForeignKey(d => d.ExternalIssueId);

            modelBuilder.Entity<ExternalIssueDetail>()
                .HasOne(d => d.Product)
                .WithMany(p => p.ExternalIssueDetails)
                .HasForeignKey(d => d.ProductId);

            modelBuilder.Entity<ExternalIssue>()
            .HasOne(e => e.User)
            .WithMany(u => u.ExternalIssues)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ExternalReceipt>()
                .HasOne(e => e.User)
                .WithMany(u => u.ExternalReceipts)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<InternalIssue>()
                .HasOne(e => e.User)
                .WithMany(u => u.InternalIssues)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<InternalReceipt>()
                .HasOne(e => e.User)
                .WithMany(u => u.InternalReceipts)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(u => u.Username).IsUnique();
                entity.Property(u => u.Role).IsRequired();
                entity.Property(u => u.PasswordHash).IsRequired();
                entity.Property(u => u.IsActive).HasDefaultValue(true);
                entity.Property(u => u.CreatedAt).HasDefaultValueSql("GETDATE()");
            });

            //modelBuilder.Entity<User>().HasData(new User
            //{
            //    Id = 1,
            //    Username = "admin",
            //    PasswordHash = BCrypt.Net.BCrypt.HashPassword("DefaultPassword123"),
            //    Role = "Admin",
            //    IsActive = true,
            //    CreatedAt = DateTime.Now
            //});
        }
    }
}
