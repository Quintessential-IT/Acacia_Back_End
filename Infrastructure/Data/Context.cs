﻿using Microsoft.EntityFrameworkCore;
using Acacia_Back_End.Core.Models;
using System.Reflection;
using Acacia_Back_End.Core.Models.CustomerOrders;
using Acacia_Back_End.Core.Models.SupplierOrders;
using Acacia_Back_End.Core.Models.CustomerReturns;
using Acacia_Back_End.Core.Models.SupplierReturns;

namespace Acacia_Back_End.Infrastructure.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<Media> MediaItems { get; set; }
        public DbSet<SupplierReturnItem> SupplierReturnItems { get; set; }
        public DbSet<SupplierReturn> SupplierReturns { get; set; }
        public DbSet<SupplierOrder> SupplierOrders { get; set; }
        public DbSet<SupplierOrderItem> SupplierOrderItems { get; set; }
        public DbSet<ReturnItem> ReturnItems { get; set; }
        public DbSet<CustomerReturn> CustomerReturns { get; set; }
        public DbSet<WriteOff> WriteOffs { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        public DbSet<OrderType> OrderTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }
        public DbSet<GiftBox> GiftBoxes { get; set; }
        public DbSet<GiftBoxPrice> GiftBoxPrices { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductPrice> ProductPrices{ get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<Vat> Vats { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Promotion> Promotions { get; set; }    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
            {
                foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                {
                    var properties = entityType.ClrType.GetProperties().Where(p => p.PropertyType == typeof(decimal));  
                    foreach (var property in properties)
                    {
                        modelBuilder.Entity(entityType.Name).Property(property.Name).HasConversion<double>();  
                    }
                }
            }
        }
    }
}
