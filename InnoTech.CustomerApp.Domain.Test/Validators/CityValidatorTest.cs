using System;
using FluentAssertions;
using InnoTech.CustomerApp.Core.IValidators;
using InnoTech.CustomerApp.Core.Models;
using InnoTech.CustomerApp.Domain.Validators;
using Xunit;

namespace InnoTech.CustomerApp.Core.Test.ApplicationService.Validators
{
    public class CityValidatorTest
    {
        [Fact]
        public void CityValidator_ShouldBeOfTypeICityValidator()
        {
            new CityValidator().Should().BeAssignableTo<ICityValidator>();
        }

        [Fact]
        public void DefaultValidation_WithCityThatsNull_ShouldThrowException()
        {
            ICityValidator cityValidator = new CityValidator();
            Action action = () => cityValidator.DefaultValidation(null as City);
            action.Should().Throw<NullReferenceException>().WithMessage("City Cannot be null");
        }
        
        [Fact]
        public void DefaultValidation_WithCityHasNoName_ShouldThrowException()
        {
            ICityValidator cityValidator = new CityValidator();
            Action action = () => cityValidator.DefaultValidation(new City(){});
            action.Should().Throw<ArgumentException>().WithMessage("City Needs a Name");
        }
    }
}