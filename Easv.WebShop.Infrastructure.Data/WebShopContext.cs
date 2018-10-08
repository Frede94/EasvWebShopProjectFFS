using System;
using System.Collections.Generic;
using System.Text;
using Easv.WebShop.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Easv.WebShop.Infrastructure.Data
{
    public class WebShopContext : DbContext
    {
        public WebShopContext(DbContextOptions<WebShopContext> opt)
            : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Whiskey>().HasOne(w => w.WhiskeyType).WithMany(t => t.ListOfWhiskeys)
                .OnDelete(DeleteBehavior.SetNull);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Whiskey> Whiskeys { get; set;}
        public DbSet<WhiskeyType> WhiskeyTypes { get; set; }
    }
}
