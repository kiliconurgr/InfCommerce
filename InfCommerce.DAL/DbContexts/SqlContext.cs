using InfCommerce.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfCommerce.DAL.DbContexts
{
    public class SqlContext:DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> opt):base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasOne(ho=>ho.Brand).WithMany(wm=>wm.Products).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Distinct>().HasOne(ho=>ho.City).WithMany(wm=>wm.Distincts).OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Order>().HasIndex(hi => hi.OrderNumber).IsUnique(true);

            modelBuilder.Entity<Admin>().HasData(new Admin { ID=1,NameSurname="Onur KILIÇ",MailAddress="admin@infcommerce",Password= "202cb962ac59075b964b07152d234b70",LastDate=DateTime.Now,LastIPNo="1" });
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductPicture> ProductPicture { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Distinct> Distinct { get; set; }
    }
}
