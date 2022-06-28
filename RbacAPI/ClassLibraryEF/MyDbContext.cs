using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEF
{
    public class MyDbContext:DbContext
    {
        public class DbContextDesignTimeFactory : IDesignTimeDbContextFactory<MyDbContext>
        {
            public MyDbContext CreateDbContext(string[] args)
            {
                DbContextOptionsBuilder<MyDbContext> builder = new DbContextOptionsBuilder<MyDbContext>();
                builder.UseSqlServer("server=127.0.0.1;Database=www666; user id=sa; Password=123456");
                return new MyDbContext(builder.Options);
            }
        }
        public MyDbContext(DbContextOptions<MyDbContext> options):base(options)
        {

        }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<RoleAdmin> RoleAdmin { get; set; }
        public DbSet<RoleMenu> RoleMenu { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(t =>
            {
                t.Property(t => t.UserName).HasMaxLength(50).IsRequired();
                t.Property(t => t.Password).HasMaxLength(50).IsRequired();
                t.Property(t => t.Email).HasMaxLength(50).IsRequired();
                t.Property(t => t.LastLoginIP).HasMaxLength(50);
            });
            modelBuilder.Entity<Menu>(t =>
            {
                t.Property(t => t.MenuName).HasMaxLength(50).IsRequired();
                t.Property(t => t.PId).IsRequired();
                t.Property(t => t.MenuLink).HasMaxLength(500).IsRequired();
            });
            modelBuilder.Entity<Role>(t =>
            {
                t.Property(t => t.RoleName).HasMaxLength(50).IsRequired();
            });
            modelBuilder.Entity<RoleAdmin>(t =>
            {
                t.HasOne<Role>().WithMany().HasForeignKey(k => k.AdmimId);
                t.HasOne<Admin>().WithMany().HasForeignKey(k => k.RoleId);
            });
            modelBuilder.Entity<RoleMenu>(t =>
            {
                t.HasOne<Role>().WithMany().HasForeignKey(k => k.RoleId);
                t.HasOne<Menu>().WithMany().HasForeignKey(k => k.MenuId);
            });
        }
    }
}
