using Autodesk.PlatformServices.Auth;
using Autodesk.PlatformServices.MD;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APSAPITest.DM.Systems.Apis.MD
{
    public class JobsApiTests
    {
        ClientCredentials _cc;

        public JobsApiTests()
        {
            _cc = new ClientCredentials(APSFixtures.RightClientId(), APSFixtures.RightClientSecret());
        }


        [Fact]
        public void PostJob_1_OnSuccess_ReturnsModel()
        {
            //Arrange
            var mockAuthenticator = new Mock<Authenticator>(_cc, Scope.Data_Read | Scope.Data_Write | Scope.Data_Create, null, null);
            var mockMDClient = new Mock<MDClient>(mockAuthenticator.Object);
            var mockRequestBuilder = new Mock<MDRequestBuilder>();
            var mockDataBuilder = new Mock<MDDataBuilder>();

            var sut = new JobsApi(mockMDClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            //var result = sut.PostJob();

            //Assert
            //result.Should().BeOfType<Job>();
        }
    }
}
