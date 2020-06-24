using SoftShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;


namespace SoftShopDatabaseImplement
{
    public class SoftShopDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=SoftShopHomeDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Soft> Softs { set; get; }
        public virtual DbSet<Pack> Packs { set; get; }
        public virtual DbSet<PackSoft> PackSofts { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
        public virtual DbSet<Warehouse> Warehouses { set; get; }
        public virtual DbSet<WarehouseSoft> WarehouseSofts { set; get; }
    }
}