using System;
using CustomerApp.Core.ApplicationService;
using CustomerApp.Core.ApplicationService.Services;
using CustomerApp.Core.DomainService;
using FluentAssertions;
using Moq;
using Xunit;

namespace CustomerApp.Core.Test.ApplicationService.Services
{
    public class CityServiceTest
    {
        [Fact]
        public void CityService_ValidatorParamAsNull_ThrowsException()
        {
            Action action = () => new CityService(null as ICityValidator, null as ICityRepository);
            action.Should().Throw<NullReferenceException>("Validator Cannot be Null");
        }
        
        [Fact]
        public void CityService_CityRepositoryParamAsNull_ThrowsException()
        {
            var validatorMock = new Mock<ICityValidator>();
            Action action = () => new CityService(validatorMock.Object, null as ICityRepository);
            action.Should().Throw<NullReferenceException>("CityRepository Cannot be Null");
        }
    }
}