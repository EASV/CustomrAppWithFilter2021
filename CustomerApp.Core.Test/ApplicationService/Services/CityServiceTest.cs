using System;
using CustomerApp.Core.ApplicationService;
using CustomerApp.Core.ApplicationService.Services;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;
using FluentAssertions;
using Moq;
using Xunit;

namespace CustomerApp.Core.Test.ApplicationService.Services
{
    public class CityServiceTest
    {
        [Fact]
        public void CityService_IsOfTypeICityService()
        {
            var cityValidatorMock = new Mock<ICityValidator>();
            var cityRepositoryMock = new Mock<ICityRepository>();
            new CityService(null ,cityValidatorMock.Object, cityRepositoryMock.Object).Should().BeAssignableTo<ICityService>();
        }

        [Fact]
        public void NewCityService_WithNullValidator_ShouldThrowException()
        {
            var cityRepositoryMock = new Mock<ICityRepository>();
            Action action = () => new CityService(null ,null as ICityValidator, cityRepositoryMock.Object);
            action.Should().Throw<NullReferenceException>().WithMessage("Validator Cannot be null");
        }
        
        [Fact]
        public void NewCityService_WithNullRepository_ShouldThrowException()
        {
            var cityValidatorMock = new Mock<ICityValidator>();
            Action action = () => new CityService(null ,cityValidatorMock.Object, null as ICityRepository);
            action.Should().Throw<NullReferenceException>().WithMessage("CityRepository Cannot be Null");
        }

        [Fact]
        public void Update_ShouldCallCityValidatorWithTheCityInParam_Once()
        {
            var cityValidatorMock = new Mock<ICityValidator>();
            var cityRepositoryMock = new Mock<ICityRepository>();
            ICityService cityService = new CityService(null ,cityValidatorMock.Object, cityRepositoryMock.Object);
            var cityToUpdate = new City();
            City city = cityService.Update(cityToUpdate);
            cityValidatorMock.Verify(cv => cv.DefaultValidation(cityToUpdate), Times.Once);
        }
        
        [Fact]
        public void Update_ShouldCallCityRepositoryUpdateWithTheCityInParam_Once()
        {
            var cityValidatorMock = new Mock<ICityValidator>();
            var cityRepositoryMock = new Mock<ICityRepository>();
            ICityService cityService = new CityService(null ,cityValidatorMock.Object, cityRepositoryMock.Object);
            var cityToUpdate = new City();
            City city = cityService.Update(cityToUpdate);
            cityRepositoryMock.Verify(cr => cr.Update(cityToUpdate), Times.Once);
        }
        
        
    }
}