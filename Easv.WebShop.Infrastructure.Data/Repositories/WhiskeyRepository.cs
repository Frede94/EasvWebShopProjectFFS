using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easv.WebShop.Core.DomainService;
using Easv.WebShop.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Easv.WebShop.Infrastructure.Data.Repositories
{
    public class WhiskeyRepository : IWhiskeyRepository
    {
        readonly WebShopContext _ctx;

        public WhiskeyRepository(WebShopContext ctx)
        {
            _ctx = ctx;
        }

        public Whiskey CreateWhiskey(Whiskey whiskey)
        {
            _ctx.Attach(whiskey).State = EntityState.Added;
            _ctx.SaveChanges();
            return whiskey;
        }

        public Whiskey Delete(int id)
        {
            var whiskeyRemove = _ctx.Remove(new Whiskey() { Id = id }).Entity;
            _ctx.SaveChanges();
            return whiskeyRemove;
        }

        public IEnumerable<Whiskey> ReadAll()
        {
            return _ctx.Whiskeys;
        }

        public IEnumerable<Whiskey> ReadAllFiltered(Filter filter)
        {
            return _ctx.Whiskeys.Skip((filter.CurrentPage - 1) * filter.ItemsPrPage).Take(filter.ItemsPrPage);

        }

        public Whiskey RetrieveById(int id)
        {
            return _ctx.Whiskeys
                .Include(w => w.WhiskeyType)
                .FirstOrDefault(c => c.Id == id);
        }

        public Whiskey Update(Whiskey whiskey)
        {
            _ctx.Attach(whiskey).State = EntityState.Modified;
            _ctx.SaveChanges();
            return whiskey;
        }
    }
}
