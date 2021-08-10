using System;
using CustomerApp.Core.Domain;
using CustomerApp.Core.Domain.Validators;
using CustomerApp.Core.IValidators;
using CustomerApp.Core.Models;
using FluentAssertions;
using Xunit;

namespace CustomerApp.Core.Test.ApplicationService.Validators
{
    public class AddressValidatorTest
    {
        [Fact]
        public void AddressValidator_IsOfTypeIAddressValidator()
        {
            new AddressValidator().Should().BeAssignableTo<IAddressValidator>();
        }

        [Fact]
        public void DefaultValidation_WithNullAddress_ShouldThrowException()
        {
            IAddressValidator validator = new AddressValidator();
            Action action = () => validator.DefaultValidation(null as Address);
            action.Should().Throw<NullReferenceException>().WithMessage("Address Cannot Be Null");
        }
        
        [Fact]
        public void DefaultValidation_WithAddressWithIdLessThen1_ShouldThrowException()
        {
            IAddressValidator validator = new AddressValidator();
            Action action = () => validator.DefaultValidation(new Address(){Id = 0} as Address);
            action.Should().Throw<NullReferenceException>().WithMessage("Address Id Cannot be less then 1");
        }
    }
}