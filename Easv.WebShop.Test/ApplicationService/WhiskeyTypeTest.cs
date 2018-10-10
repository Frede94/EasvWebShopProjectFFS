using Easv.WebShop.Core.ApplicationService.IServices;
using Easv.WebShop.Core.ApplicationService.Services;
using Easv.WebShop.Core.DomainService;
using Easv.WebShop.Core.Entity;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Easv.WebShop.Test.ApplicationService
{
    public class WhiskeyTypeTest
    {
        [Fact]
        public void CreateWhiskeyTypeWithTypeNameMissing()
        {
            var whiskeyTypeRepo = new Mock<IWhiskeyTypeRepository>();

            IWhiskeyTypeService service = new WhiskeyTypeService(whiskeyTypeRepo.Object);

            var whiskeyType = new WhiskeyType()
            {
                // No WhiskeyType name 
            };

            Exception ex = Assert.Throws<Exception>(() => service.CreateWhiskeyType(whiskeyType));
            Assert.Equal("The Whiskey type must be defined", ex.Message);


        }
    }
}
