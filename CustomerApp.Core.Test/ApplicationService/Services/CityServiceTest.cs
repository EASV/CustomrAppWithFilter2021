using System;
using CustomerApp.Core.Domain;
using CustomerApp.Core.Domain.Services;
using CustomerApp.Core.IServices;
using CustomerApp.Core.IValidators;
using CustomerApp.Core.Models;
using CustomerApp.Core.Persistance.Interfaces;
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
            new CityService(cityValidatorMock.Object, cityRepositoryMock.Object).Should().BeAssignableTo<ICityService>();
        }

        [Fact]
        public void NewCityService_WithNullValidator_ShouldThrowException()
        {
            var cityRepositoryMock = new Mock<ICityRepository>();
            Action action = () => new CityService(null as ICityValidator, cityRepositoryMock.Object);
            action.Should().Throw<NullReferenceException>().WithMessage("Validator Cannot be null");
        }
        
        [Fact]
        public void NewCityService_WithNullRepository_ShouldThrowException()
        {
            var cityValidatorMock = new Mock<ICityValidator>();
            Action action = () => new CityService(cityValidatorMock.Object, null as ICityRepository);
            action.Should().Throw<NullReferenceException>().WithMessage("CityRepository Cannot be Null");
        }

        [Fact]
        public void Update_ShouldCallCityValidatorWithTheCityInParam_Once()
        {
            var cityValidatorMock = new Mock<ICityValidator>();
            var cityRepositoryMock = new Mock<ICityRepository>();
            ICityService cityService = new CityService(cityValidatorMock.Object, cityRepositoryMock.Object);
            var cityToUpdate = new City();
            City city = cityService.Update(cityToUpdate);
            cityValidatorMock.Verify(cv => cv.DefaultValidation(cityToUpdate), Times.Once);
        }
        
        [Fact]
        public void Update_ShouldCallCityRepositoryUpdateWithTheCityInParam_Once()
        {
            var cityValidatorMock = new Mock<ICityValidator>();
            var cityRepositoryMock = new Mock<ICityRepository>();
            ICityService cityService = new CityService(cityValidatorMock.Object, cityRepositoryMock.Object);
            var cityToUpdate = new City();
            City city = cityService.Update(cityToUpdate);
            cityRepositoryMock.Verify(cr => cr.Update(cityToUpdate), Times.Once);
        }
        
        
    }
}