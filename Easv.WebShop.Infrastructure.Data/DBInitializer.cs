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




            ctx.SaveChanges();
        }
    }
}
