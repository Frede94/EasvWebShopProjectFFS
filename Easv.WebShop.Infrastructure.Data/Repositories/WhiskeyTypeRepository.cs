using Easv.WebShop.Core.DomainService;
using Easv.WebShop.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easv.WebShop.Infrastructure.Data.Repositories
{
    public class WhiskeyTypeRepository : IWhiskeyTypeRepository
    {
        readonly WebShopContext _WSctx;

        public WhiskeyTypeRepository(WebShopContext WSctx)
        {
            _WSctx = WSctx;
        }

        public WhiskeyType CreateWhiskeyType(WhiskeyType whiskeyType)
        {
            var wt = _WSctx.WhiskeyTypes.Add(whiskeyType).Entity;
            _WSctx.SaveChanges();
            return wt;
        }

        public IEnumerable<WhiskeyType> ReadAll()
        {
            return _WSctx.WhiskeyTypes;
        }

        public IEnumerable<WhiskeyType> ReadAllFiltered(Filter filter)
        {
            return _WSctx.WhiskeyTypes
                .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                .Take(filter.ItemsPrPage);
        }

        public WhiskeyType RetrieveById(int id)
        {
            return _WSctx.WhiskeyTypes
                .Include(wt => wt.ListOfWhiskeys)
                .FirstOrDefault(wt => wt.Id == id);
        }

        public WhiskeyType Update(WhiskeyType whiskeyType)
        {
            _WSctx.Attach(whiskeyType).State = EntityState.Modified;
            _WSctx.SaveChanges();
            return whiskeyType;
        }

        public WhiskeyType Delete(int id)
        {
            var wtRemoved = _WSctx
                .Remove(new WhiskeyType { Id = id })
                .Entity;
            _WSctx.SaveChanges();
            return wtRemoved;
        }    
    }
}
