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
    public class AddressServiceTest
    {
        [Fact]
        public void NewService_WithNullValidator_ShouldThrowException()
        {
            Action action = () =>  new AddressService(null as IAddressValidator, null as IAddressRepository);
            action.Should().Throw<NullReferenceException>("Validator cannot be null");
        }
        
        [Fact]
        public void NewService_WithNullRepository_ShouldThrowException()
        {
            var validatorMock = new Mock<IAddressValidator>();
            Action action = () =>  new AddressService(validatorMock.Object, null as IAddressRepository);
            action.Should().Throw<NullReferenceException>("Repository cannot be null");
        }
        
        [Fact]
        public void AddressService_ShouldBeOfTypeIAddressService()
        {
            var validatorMock = new Mock<IAddressValidator>();
            var repositoryMock = new Mock<IAddressRepository>();
            new AddressService(validatorMock.Object, repositoryMock.Object).Should().BeAssignableTo<IAddressService>();
        }

        [Fact]
        public void Update_WithNullAddress_ShouldThrowException()
        {   
            var validatorMock = new Mock<IAddressValidator>();
            var repositoryMock = new Mock<IAddressRepository>();
            IAddressService service = new AddressService(validatorMock.Object, repositoryMock.Object);
            Action action = () =>  service.Update(null as Address);
            action.Should().Throw<NullReferenceException>().WithMessage("Address Cannot be Null");
        }
    }
}