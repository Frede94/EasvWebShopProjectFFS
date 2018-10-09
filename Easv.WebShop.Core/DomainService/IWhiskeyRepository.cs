using Easv.WebShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easv.WebShop.Core.DomainService
{
    public interface IWhiskeyRepository
    {
        Whiskey CreateWhiskey(Whiskey whiskey);
        IEnumerable<Whiskey> ReadAll();
        IEnumerable<Whiskey> ReadAllFiltered(Filter filter);
        Whiskey RetrieveById(int id);
        Whiskey Delete(int id);
        Whiskey Update(Whiskey whiskey);
    }
}
