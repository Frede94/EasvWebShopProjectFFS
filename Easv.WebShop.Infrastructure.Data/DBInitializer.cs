using Easv.WebShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easv.WebShop.Infrastructure.Data
{
    public class DBInitializer
    {
        public static void SeedDb(WebShopContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            var type1 = ctx.WhiskeyTypes.Add(new WhiskeyType()
            {
                TypeName = "Scotch"
            }).Entity;
            var type2 = ctx.WhiskeyTypes.Add(new WhiskeyType()
            {
                TypeName = "Bourbon"
            }).Entity;
            var type3 = ctx.WhiskeyTypes.Add(new WhiskeyType()
            {
                TypeName = "Irish"
            }).Entity;

            var type4 = ctx.WhiskeyTypes.Add(new WhiskeyType()
            {
                TypeName = "Blend"
            }).Entity;

            var type5 = ctx.WhiskeyTypes.Add(new WhiskeyType()
            {
                TypeName = "Rye"
            }).Entity;
            var whiskey1 = ctx.Whiskeys.Add(new Whiskey()
            {
                WhiskeyType = type1,
                Description = "Det Whiskey!",
                Year = 1579,
                Price = 123124.00,
                Stock  = 2
            }).Entity;
            var whiskey2 = ctx.Whiskeys.Add(new Whiskey()
            {
                WhiskeyType = type2,
                Description = "Det Whiskey!",
                Year = 1800,
                Price = 50000.00,
                Stock = 15
            }).Entity;
            var whiskey3 = ctx.Whiskeys.Add(new Whiskey()
            {
                WhiskeyType = type3,
                Description = "Det Whiskey!",
                Year = 2012,
                Price = 150.00,
                Stock = 100
            }).Entity;
            var whiskey4 = ctx.Whiskeys.Add(new Whiskey()
            {
                WhiskeyType = type4,
                Description = "Det Whiskey!",
                Year = 1200,
                Price = 500000.00,
                Stock = 1
            }).Entity;
            var whiskey5 = ctx.Whiskeys.Add(new Whiskey()
            {
                WhiskeyType = type5,
                Description = "Det Whiskey!",
                Year = 2017,
                Price = 50.00,
                Stock = 200
            }).Entity;
            var whiskey6 = ctx.Whiskeys.Add(new Whiskey()
            {
                WhiskeyType = type1,
                Description = "Det Whiskey!",
                Year = 1950,
                Price = 500.00,
                Stock = 5
            }).Entity;
            var whiskey7 = ctx.Whiskeys.Add(new Whiskey()
            {
                WhiskeyType = type2,
                Description = "Det Whiskey!",
                Year = 1887,
                Price = 5000.00,
                Stock = 3
            }).Entity;
            var whiskey8 = ctx.Whiskeys.Add(new Whiskey()
            {
                WhiskeyType = type3,
                Description = "Det Whiskey!",
                Year = 1995,
                Price = 4999.99,
                Stock = 10
            }).Entity;
            var whiskey9 = ctx.Whiskeys.Add(new Whiskey()
            {
                WhiskeyType = type4,
                Description = "Det Whiskey!",
                Year = 1765,
                Price = 5000.00,
                Stock = 1
            }).Entity;

            ctx.SaveChanges();
        }
    }
}
