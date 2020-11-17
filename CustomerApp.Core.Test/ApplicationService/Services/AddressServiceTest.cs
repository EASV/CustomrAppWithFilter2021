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
        public void Update_ShouldCallAddressValidatorDefaultValidationWithAddressParam_Once()
        {   
            var validatorMock = new Mock<IAddressValidator>();
            var repositoryMock = new Mock<IAddressRepository>();
            IAddressService service = new AddressService(validatorMock.Object, repositoryMock.Object);
            var address = new Address(){Id = 1, Additional = "Ost", CityId = 1, StreetName = "Osteby", StreetNr = 2};
            service.Update(address);
            validatorMock.Verify(validator => validator.DefaultValidation(address), Times.Once);
        }
        
        [Fact]
        public void Update_ShouldCallAddressRepositoryUpdateWithAddressParam_Once()
        {   
            var validatorMock = new Mock<IAddressValidator>();
            var repositoryMock = new Mock<IAddressRepository>();
            IAddressService service = new AddressService(validatorMock.Object, repositoryMock.Object);
            var address = new Address(){Id = 1, Additional = "Ost", CityId = 1, StreetName = "Osteby", StreetNr = 2};
            service.Update(address);
            repositoryMock.Verify(repository => repository.Update(address), Times.Once);
        }
        
        [Fact]
        public void Update_ShouldReturn_UpdatedAddressWithCorrectId()
        {   
            var validatorMock = new Mock<IAddressValidator>();
            var repositoryMock = new Mock<IAddressRepository>();
            var address = new Address(){Id = 0, Additional = "Ost", CityId = 1, StreetName = "Osteby", StreetNr = 2};
            var addressCreated = new Address(){Id = 1, Additional = "Ost", CityId = 1, StreetName = "Osteby", StreetNr = 2};
            repositoryMock.Setup(r => r.Update(address)).Returns(address);
            IAddressService service = new AddressService(validatorMock.Object, repositoryMock.Object);
            var updatedAddress = service.Update(address);
            updatedAddress.Should().Be(address);
        }
    }
}