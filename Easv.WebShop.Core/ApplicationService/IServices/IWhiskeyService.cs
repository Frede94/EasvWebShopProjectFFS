using Easv.WebShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easv.WebShop.Core.ApplicationService.IServices
{
    public interface IWhiskeyService
    {
        Whiskey CreateWhiskey(Whiskey whiskey);
        List<Whiskey> ReadAll();
        List<Whiskey> ReadAllFiltered(Filter filter);
        Whiskey RetrieveById(int id);
        Whiskey Delete(int id);
        Whiskey Update(Whiskey whiskey); 
        
    }
}
