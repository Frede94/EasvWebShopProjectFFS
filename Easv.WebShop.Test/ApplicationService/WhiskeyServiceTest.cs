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
    public class WhiskeyServiceTest
    {
        [Fact]
        public void CreateWhiskeyWithWhiskeyTypeMissing()
        {
            var whiskeyRepo = new Mock<IWhiskeyRepository>();

            IWhiskeyService service = new WhiskeyService(whiskeyRepo.Object);

            var whiskey = new Whiskey()
            {
                WhiskeyName = "Test Whiskey Name",
                Description = "Test Description",
                Price = 2500,
                Stock = 10,
                Year = 1997
            };

            Exception ex = Assert.Throws<Exception>(() => service.CreateWhiskey(whiskey));
            Assert.Equal("There must be a Whiskey type assigned to the whiskey for creation", ex.Message);
        }

        [Fact]
        public void CreateWhiskeyWithWhiskeyNameMissing()
        {
            var whiskeyRepo = new Mock<IWhiskeyRepository>();

            IWhiskeyService service = new WhiskeyService(whiskeyRepo.Object);

            var whiskey = new Whiskey()
            {
                WhiskeyType = new WhiskeyType() { Id = 1, TypeName = "Test Type" },
                Description = "Test Description",
                Price = 2500,
                Stock = 10,
                Year = 1997
            };

            Exception ex = Assert.Throws<Exception>(() => service.CreateWhiskey(whiskey));
            Assert.Equal("There must be a Whiskey name assigned to the whiskey for creation", ex.Message);
        }

        [Fact]
        public void CreateWhiskeyWithDescriptionMissing()
        {
            var whiskeyRepo = new Mock<IWhiskeyRepository>();

            IWhiskeyService service = new WhiskeyService(whiskeyRepo.Object);

            var whiskey = new Whiskey()
            {
                WhiskeyName = "Test Whiskey Name",
                WhiskeyType = new WhiskeyType() { Id = 1, TypeName = "Test Type" },
                Price = 2500,
                Stock = 10,
                Year = 1997
            };

            Exception ex = Assert.Throws<Exception>(() => service.CreateWhiskey(whiskey));
            Assert.Equal("There must be a Whiskey description assigned to the whiskey for creation", ex.Message);
        }

        [Fact]
        public void CreateWhiskeyWithPriceMissing()
        {
            var whiskeyRepo = new Mock<IWhiskeyRepository>();

            IWhiskeyService service = new WhiskeyService(whiskeyRepo.Object);

            var whiskey = new Whiskey()
            {
                WhiskeyName = "Test Whiskey Name",
                WhiskeyType = new WhiskeyType() { Id = 1, TypeName = "Test Type" },
                Description = "Test Description",
                Stock = 10,
                Year = 1997
            };

            Exception ex = Assert.Throws<Exception>(() => service.CreateWhiskey(whiskey));
            Assert.Equal("There must be a valid Whiskey price assigned to the whiskey for creation", ex.Message);
        }

        [Fact]
        public void CreateWhiskeyWithYearMissing()
        {
            var whiskeyRepo = new Mock<IWhiskeyRepository>();

            IWhiskeyService service = new WhiskeyService(whiskeyRepo.Object);

            var whiskey = new Whiskey()
            {
                WhiskeyName = "Test Whiskey Name",
                WhiskeyType = new WhiskeyType() { Id = 1, TypeName = "Test Type" },
                Description = "Test Description",
                Price = 2500,
                Stock = 10,
            };

            Exception ex = Assert.Throws<Exception>(() => service.CreateWhiskey(whiskey));
            Assert.Equal("There must be a Whiskey year assigned to the whiskey for creation", ex.Message);
        }



    }
}
