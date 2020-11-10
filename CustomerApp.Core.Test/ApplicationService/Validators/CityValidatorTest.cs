using System;
using CustomerApp.Core.ApplicationService;
using CustomerApp.Core.ApplicationService.Validators;
using CustomerApp.Core.Entity;
using FluentAssertions;
using Xunit;

namespace CustomerApp.Core.Test.ApplicationService.Validators
{
    public class CityValidatorTest
    {
        
        [Fact]
        public void CityValidator_IsOfTypeICityValidator()
        {
            new CityValidator().Should().BeAssignableTo<ICityValidator>();
        }

        [Fact]
        public void DefaultValidation_WithNullCity_ThrowsException()
        {
            Action action = () =>  new CityValidator().DefaultValidation(null as City);
            action.Should().Throw<NullReferenceException>().WithMessage("City Cannot be Null");
        }

        [Fact]
        public void CityValidator_WithCityWithNoName_ThrowsException()
        {
            Action action = () =>  new CityValidator().DefaultValidation(new City());
            action.Should().Throw<ArgumentException>().WithMessage("Name cannot be empty");
        }
        
        [Fact]
        public void CityValidator_WithCityWithShortName_ThrowsException()
        {
            Action action = () =>  new CityValidator().DefaultValidation(new City(){Name = "Øh"});
            action.Should().Throw<ArgumentException>().WithMessage("Name must be more then 2 chars");
        }
        
        [Fact]
        public void CityValidator_WithCityWithLongName_ThrowsException()
        {
            Action action = () =>  new CityValidator().DefaultValidation(new City(){Name = "TheLongNamedCityOf26Charsi"});
            action.Should().Throw<ArgumentException>().WithMessage("Name Cannot be more then 25 chars");
        }
    }
}