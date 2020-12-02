using System;
using CustomerApp.Core.ApplicationService;
using CustomerApp.Core.ApplicationService.Services;
using CustomerApp.Core.ApplicationService.Validators;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;
using FluentAssertions;
using Moq;
using Xunit;

namespace CustomerApp.Core.Test.ApplicationService.Services
{
    public class CityServiceTest
    {
        /*[Fact]
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


        [Fact]
        public void ReadAll_WithValidFilter_CallsRepositoryReadAll()
        {
            var cityRepositoryMock = new Mock<ICityRepository>();
            
            ICityService cityService = new CityService(new CityValidator(), cityRepositoryMock.Object);
            var filter = new Filter() {CurrentPage = 4, ItemsPrPage = 2};
            
            // [i1, i2, i3, i4, i5, i6, i7]
            cityService.ReadAll(filter);
            cityRepositoryMock.Verify(cr => cr.GetAll(filter));
            // Assert.True(fList.List.Count <= 2);
            //Assert.Equal(fList.FilterUsed, filter);
        }

        [Fact]
        public void ReadAll_WithNullFilter_CallsRepositoryGetAllWithDefaultFilter()
        {
            var defaultFilter = new Filter(){CurrentPage = 1, ItemsPrPage = 5};
            var cityRepositoryMock = new Mock<ICityRepository>();

            cityRepositoryMock
                .Setup(repository => repository.GetAll(It.IsAny<Filter>()))
                .Returns(new FilteredList<City> {FilterUsed = defaultFilter});
            
            ICityService cityService = new CityService(new CityValidator(), cityRepositoryMock.Object);
            // [i1, i2, i3, i4, i5, i6, i7]
            var fList = cityService.ReadAll(null);
            Assert.Equal(defaultFilter, fList.FilterUsed);
            //cityRepositoryMock.Verify(cr => cr.GetAll(fList.FilterUsed));
            // Assert.True(fList.List.Count <= 2);
            //Assert.Equal(fList.FilterUsed, filter);
        }*/
    }
}