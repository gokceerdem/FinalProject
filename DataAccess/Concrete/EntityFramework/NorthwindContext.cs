using System.Linq;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class NorthwindContext : DbContext //db tabloları ile proje classlarını bağlamak
    {
        //internal IQueryable<ProductDetailDto> result;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=172.21.176.40"); normalde böyle IP yazılır

            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");
            optionsBuilder.UseMySQL(@"Server=localhost;Database=northwind;Uid=root;Pwd=123456789;");
        }
        //önce class sonra db tablosu
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
