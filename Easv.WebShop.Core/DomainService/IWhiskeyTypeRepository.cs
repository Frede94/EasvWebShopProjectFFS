using Easv.WebShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easv.WebShop.Core.DomainService
{
    public interface IWhiskeyTypeRepository
    {
        WhiskeyType CreateWhiskeyType(WhiskeyType whiskeyType);
        IEnumerable<WhiskeyType> ReadAll();
        IEnumerable<WhiskeyType> ReadAllFiltered(Filter filter);
        WhiskeyType RetrieveById(int id);
        WhiskeyType Delete(int id);
        WhiskeyType Update(WhiskeyType whiskeyType);
    }
}
