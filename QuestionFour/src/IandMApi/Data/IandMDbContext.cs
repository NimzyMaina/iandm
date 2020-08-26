using System.Reflection;
using IandMApi.Models;
using Microsoft.EntityFrameworkCore;

namespace IandMApi.Data
{
    public class IandMDbContext : DbContext
    {

        public IandMDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasMany(c => c.IoUs)
                .WithOne(e => e.Lender)
                .HasForeignKey(f => f.LenderId);

            builder.Entity<User>()
                .HasMany(c => c.UoMes)
                .WithOne(e => e.Borrower)
                .HasForeignKey(f => f.BorrowerId);
//            builder.Entity<IoU>()
//                .HasOne<User>(u => u.Lender)
//                .WithMany(i => i.UoMes)
//                .HasForeignKey(f => f.LenderId);
//
//            builder.Entity<IoU>()
//                .HasOne<User>(u => u.Borrower)
//                .WithMany(i => i.IoUs)
//                .HasForeignKey(f => f.BorrowerId);

//            builder.Entity<User>().HasMany(city => city.IoUs)
//                .WithOne(i => i.Borrower).HasForeignKey(con => con.BorrowerId);
//
//            builder.Entity<User>().HasMany(city => city.UoMes)
//                .WithOne(i => i.Lender).HasForeignKey(con => con.LenderId);

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<IoU> IoUs { get; set; }
        
    }
}