using Easv.WebShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easv.WebShop.Core.ApplicationService.IServices
{
    public interface IWhiskeyTypeService
    {
        WhiskeyType CreateWhiskeyType(WhiskeyType whiskeyType);
        List<WhiskeyType> ReadAll();
        List<WhiskeyType> ReadAllFiltered(Filter filter);
        WhiskeyType RetrieveById(int id);
        WhiskeyType Delete(int id);
        WhiskeyType Update(WhiskeyType whiskeyType);
    }
}
