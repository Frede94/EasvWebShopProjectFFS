using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easv.WebShop.Core.ApplicationService.IServices;
using Easv.WebShop.Core.DomainService;
using Easv.WebShop.Core.Entity;

namespace Easv.WebShop.Core.ApplicationService.Services
{
    public class WhiskeyService : IWhiskeyService
    {
        readonly IWhiskeyRepository _whiskeyRepo;
            
        public WhiskeyService (IWhiskeyRepository whiskeyRepo)
        {
            _whiskeyRepo = whiskeyRepo;
        }

        public Whiskey CreateWhiskey(Whiskey whiskey)
        {
            return _whiskeyRepo.CreateWhiskey(whiskey);
        }

        public Whiskey Delete(int id)
        {
            return _whiskeyRepo.Delete(id);
        }

        public List<Whiskey> ReadAll()
        {
            return _whiskeyRepo.ReadAll().ToList();
        }

        public List<Whiskey> ReadAllFiltered(Filter filter)
        {
            return _whiskeyRepo.ReadAllFiltered(filter).ToList();
        }

        public Whiskey RetrieveById(int id)
        {
            return _whiskeyRepo.Delete(id);
        }

        public Whiskey Update(Whiskey whiskey)
        {
            return _whiskeyRepo.Update(whiskey);

        }
    }
}
