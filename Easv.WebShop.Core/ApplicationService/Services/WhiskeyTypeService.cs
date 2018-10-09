using Easv.WebShop.Core.ApplicationService.IServices;
using Easv.WebShop.Core.DomainService;
using Easv.WebShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easv.WebShop.Core.ApplicationService.Services
{
    public class WhiskeyTypeService : IWhiskeyTypeService
    {
        readonly IWhiskeyTypeRepository _wTypeRepo;

        public WhiskeyTypeService(IWhiskeyTypeRepository whiskeyTypeRepository)
        {
            _wTypeRepo = whiskeyTypeRepository;
        }

        public WhiskeyType CreateWhiskeyType(WhiskeyType whiskeyType)
        {
            return _wTypeRepo.CreateWhiskeyType(whiskeyType);
        }

        public List<WhiskeyType> ReadAll()
        {
            return _wTypeRepo.ReadAll().ToList();
        }

        public List<WhiskeyType> ReadAllFiltered(Filter filter)
        {
            return _wTypeRepo.ReadAllFiltered(filter).ToList();
        }

        public WhiskeyType RetrieveById(int id)
        {
            return _wTypeRepo.RetrieveById(id);
        }

        public WhiskeyType Update(WhiskeyType whiskeyType)
        {
            return _wTypeRepo.Update(whiskeyType);
        }

        public WhiskeyType Delete(int id)
        {
            return _wTypeRepo.Delete(id);
        }
    }
}
