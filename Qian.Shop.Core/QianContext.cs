using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Qian.Shop.Core.Models;

namespace Qian.Shop.Core
{
    public partial class QianContext : DbContext
    {
        public QianContext()
        {
        }

        public QianContext(DbContextOptions<QianContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Managers> Managers { get; set; }
        public virtual DbSet<OrderItems> OrderItems { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<ShopCars> ShopCars { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=BookStore;Integrated Security=True;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>(entity =>
            {
                entity.HasKey(e => e.BookId)
                    .HasName("PK__Books__3DE0C227904E0DD7");

                entity.Property(e => e.BookId).HasColumnName("BookID");

                entity.Property(e => e.AuthorsName).HasMaxLength(40);

                entity.Property(e => e.BookImg).HasMaxLength(40);

                entity.Property(e => e.BookName).HasMaxLength(50);

                entity.Property(e => e.BookType)
                    .HasMaxLength(16)
                    .IsUnicode(false);
                entity.Property(e => e.BookState)
                    .HasColumnType("bit")
                    .IsRequired()
                    .HasDefaultValueSql("(1)");
                entity.Property(e => e.GreatPrice).HasColumnType("money");

                entity.Property(e => e.MarketPrice).HasColumnType("money");

                entity.Property(e => e.PromotionPrice).HasColumnType("money");

                entity.Property(e => e.SeckillPrice).HasColumnType("money");

                entity.Property(e => e.Suit)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Managers>(entity =>
            {
                entity.HasKey(e => e.ManagerId)
                    .HasName("PK__Managers__3BA2AA812C552E4D");

                entity.Property(e => e.ManagerId).HasColumnName("ManagerID");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).HasMaxLength(25);

                entity.Property(e => e.ManagerName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.PhoneNumber).HasMaxLength(12);
            });

            modelBuilder.Entity<OrderItems>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("PK__OrderIte__727E83EB2AA7F3C6");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.BookId).HasColumnName("BookID");

                entity.Property(e => e.ItemName).HasMaxLength(50);

                entity.Property(e => e.ItemPrice).HasColumnType("money");

                entity.Property(e => e.OrderNumber)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__Orders__C3905BAF658FF3AF");

                entity.Property(e => e.OrderId)
                    .HasColumnName("OrderID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ConsigneeAddress)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.ConsigneeName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ConsigneePhone)
                    .IsRequired()
                    .HasMaxLength(26)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OrderNumber)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Osprice)
                    .HasColumnName("OSPrice")
                    .HasColumnType("money");

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.ReceivingDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Orders__UserID__412EB0B6");
            });

            modelBuilder.Entity<ShopCars>(entity =>
            {
                entity.HasKey(e => e.CarId)
                    .HasName("PK__ShopCars__68A0340E8338EA71");

                entity.Property(e => e.CarId).HasColumnName("CarID");

                entity.Property(e => e.BookId).HasColumnName("BookID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ShopCars)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__ShopCars__UserID__46E78A0C");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Users__1788CCAC1CA0FE21");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.Area).HasMaxLength(15);

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.City).HasMaxLength(10);

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).HasMaxLength(25);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.PhoneNumber).HasMaxLength(12);

                entity.Property(e => e.Provice).HasMaxLength(10);

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
