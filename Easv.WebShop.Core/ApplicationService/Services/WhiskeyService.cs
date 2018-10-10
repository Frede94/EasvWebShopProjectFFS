using System;
using System.Collections.Generic;
using System.IO;
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
            if (string.IsNullOrEmpty(whiskey.WhiskeyName))                
                throw new Exception("There must be a Whiskey name assigned to the whiskey for creation");
            if (whiskey.WhiskeyType == null || whiskey.WhiskeyType.Id <= 0)
                throw new Exception("There must be a Whiskey type assigned to the whiskey for creation");
            if (string.IsNullOrEmpty(whiskey.Description))
                throw new Exception("There must be a Whiskey description assigned to the whiskey for creation");
            if (whiskey.Price <= 0)
                throw new Exception("There must be a valid Whiskey price assigned to the whiskey for creation");
            if (whiskey.Year == 0)
                throw new Exception("There must be a Whiskey year assigned to the whiskey for creation");           
           
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
            return _whiskeyRepo.RetrieveById(id);
        }

        public Whiskey Update(Whiskey whiskey)
        {
            return _whiskeyRepo.Update(whiskey);

        }
    }
}
