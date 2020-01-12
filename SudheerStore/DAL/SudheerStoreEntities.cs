using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Data.Entity.Infrastructure;
using SudheerStore.Models;

namespace SudheerStore.DAL
{
    public class SudheerStoreEntities:DbContext
    {
        public SudheerStoreEntities()
           : base("name=SudheerStoreEntities")
        {
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    throw new UnintentionalCodeFirstException();
        //}
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CustomerOrder> CustomerOrders { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<OrderedProduct> OrderedProducts { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Brands> Brands { get; set; }
        public  virtual DbSet<UserModel> UserData { get; set; }
    }
}