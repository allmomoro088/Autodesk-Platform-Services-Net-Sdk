using APSAPITest.DM.Fixtures;
using Autodesk.PlatformServices.Auth;
using Autodesk.PlatformServices.DM;
using FluentAssertions;
using Moq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APSAPITest.DM.Systems.Apis.DM
{
    public class HubsApiTests
    {
        ClientCredentials _correctCC;
        public HubsApiTests()
        {
            _correctCC = new ClientCredentials(APSFixtures.RightClientId(), APSFixtures.RightClientSecret());
        }

        #region GetHubs

        [Fact]
        public void GetHubs_1_OnSuccess_ReturnsModelList()
        {
            //Arrange
            var request = RestSharpFixtures.GetRequest();
            var model = HubsFixtures.RightModelList();

            var mockAuthenticator = new Mock<Authenticator>(_correctCC, Scope.Account_Read, null, null);
            var mockDmClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDmClient
                .Setup(s => s.ExecuteDMApi<List<Hub>>(It.IsAny<RestRequest>(), It.IsAny<Func<string, DMApiResponseBase<List<Hub>>>>(), It.IsAny<Action<RestResponse>>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetHubs())
                .Returns(mockRequestBuilder.Object);

            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new HubsApi(mockDmClient.Object, mockRequestBuilder.Object);

            //Act
            var hubs = sut.GetHubs();

            //Assert
            hubs.Should().BeOfType<List<Hub>>();
        }

        [Fact]
        public void GetHubs_2_WhenCalled_InvokesRequestBuilderUseGetHubsExactlyOnce()
        {
            //Arrange
            var request = RestSharpFixtures.GetRequest();
            var model = HubsFixtures.RightModelList();

            var mockAuthenticator = new Mock<Authenticator>(_correctCC, Scope.Account_Read, null, null);
            var mockDmClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDmClient
                .Setup(s => s.ExecuteDMApi<List<Hub>>(It.IsAny<RestRequest>(), It.IsAny<Func<string, DMApiResponseBase<List<Hub>>>>(), It.IsAny<Action<RestResponse>>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetHubs())
                .Returns(mockRequestBuilder.Object);

            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new HubsApi(mockDmClient.Object, mockRequestBuilder.Object);

            //Act
            var hubs = sut.GetHubs();

            //Assert
            mockRequestBuilder.Verify(s => s.UseGetHubs());
        }

        [Fact]
        public void GetHubs_3_WhenCalled_InvokesRequestBuilderBuildExactlyOnce()
        {
            //Arrange
            var request = RestSharpFixtures.GetRequest();
            var model = HubsFixtures.RightModelList();

            var mockAuthenticator = new Mock<Authenticator>(_correctCC, Scope.Account_Read, null, null);
            var mockDmClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDmClient
                .Setup(s => s.ExecuteDMApi<List<Hub>>(It.IsAny<RestRequest>(), It.IsAny<Func<string, DMApiResponseBase<List<Hub>>>>(), It.IsAny<Action<RestResponse>>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetHubs())
                .Returns(mockRequestBuilder.Object);

            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new HubsApi(mockDmClient.Object, mockRequestBuilder.Object);

            //Act
            var hubs = sut.GetHubs();

            //Assert
            mockRequestBuilder.Verify(s => s.Build(), Times.Once());
        }

        [Fact]
        public void GetHubs_4_WhenCalled_InvokesDmClientExecuteExactlyOnce()
        {
            //Arrange
            var request = RestSharpFixtures.GetRequest();
            var model = HubsFixtures.RightModelList();

            var mockAuthenticator = new Mock<Authenticator>(_correctCC, Scope.Account_Read, null, null);
            var mockDmClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDmClient
                .Setup(s => s.ExecuteDMApi<List<Hub>>(It.IsAny<RestRequest>(), It.IsAny<Func<string, DMApiResponseBase<List<Hub>>>>(), It.IsAny<Action<RestResponse>>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetHubs())
                .Returns(mockRequestBuilder.Object);

            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new HubsApi(mockDmClient.Object, mockRequestBuilder.Object);

            //Act
            var hubs = sut.GetHubs();

            //Assert
            mockDmClient.Verify(s => s.ExecuteDMApi<List<Hub>>(It.IsAny<RestRequest>(), It.IsAny<Func<string, DMApiResponseBase<List<Hub>>>>(), It.IsAny<Action<RestResponse>>()), Times.Once());
        }

        [Fact]
        public void GetHubs_5_WhenCalled_InvokesDmClientExecuteWithRequestFromRequestBuilder()
        {
            //Arrange
            var request = RestSharpFixtures.GetRequest();
            var model = HubsFixtures.RightModelList();

            var mockAuthenticator = new Mock<Authenticator>(_correctCC, Scope.Account_Read, null, null);
            var mockDmClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDmClient
                .Setup(s => s.ExecuteDMApi<List<Hub>>(It.IsAny<RestRequest>(), It.IsAny<Func<string, DMApiResponseBase<List<Hub>>>>(), It.IsAny<Action<RestResponse>>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetHubs())
                .Returns(mockRequestBuilder.Object);

            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new HubsApi(mockDmClient.Object, mockRequestBuilder.Object);

            //Act
            var hubs = sut.GetHubs();

            //Assert
            mockDmClient.Verify(s => s.ExecuteDMApi<List<Hub>>(request, It.IsAny<Func<string, DMApiResponseBase<List<Hub>>>>(), It.IsAny<Action<RestResponse>>()), Times.Once());
        }

        [Fact]
        public void GetHubs_6_OnSuccess_RetursExecuteModel()
        {
            //Arrange
            var request = RestSharpFixtures.GetRequest();
            var model = HubsFixtures.RightModelList();

            var mockAuthenticator = new Mock<Authenticator>(_correctCC, Scope.Account_Read, null, null);
            var mockDmClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDmClient
                .Setup(s => s.ExecuteDMApi<List<Hub>>(It.IsAny<RestRequest>(), It.IsAny<Func<string, DMApiResponseBase<List<Hub>>>>(), It.IsAny<Action<RestResponse>>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetHubs())
                .Returns(mockRequestBuilder.Object);

            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new HubsApi(mockDmClient.Object, mockRequestBuilder.Object);

            //Act
            var hubs = sut.GetHubs();

            //Assert
            hubs.Should().BeSameAs(model);
        }

        #endregion

        #region GetHub

        [Fact]
        public void GetHub_1_OnSuccess_ReturnsModelList()
        {
            //Arrange
            var request = RestSharpFixtures.GetRequest();
            var model = HubsFixtures.RightModel();
            var id = HubsFixtures.RightId();

            var mockAuthenticator = new Mock<Authenticator>(_correctCC, Scope.Account_Read, null, null);
            var mockDmClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDmClient
                .Setup(s => s.ExecuteDMApi<Hub>(It.IsAny<RestRequest>(), It.IsAny<Func<string, DMApiResponseBase<Hub>>>(), It.IsAny<Action<RestResponse>>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetHub(It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);

            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new HubsApi(mockDmClient.Object, mockRequestBuilder.Object);

            //Act
            var hubs = sut.GetHub(id);

            //Assert
            hubs.Should().BeOfType<Hub>();
        }

        [Fact]
        public void GetHub_2_WhenCalled_InvokesRequestBuilderUseGetHubExactlyOnce()
        {
            //Arrange
            var request = RestSharpFixtures.GetRequest();
            var model = HubsFixtures.RightModel();
            var id = HubsFixtures.RightId();

            var mockAuthenticator = new Mock<Authenticator>(_correctCC, Scope.Account_Read, null, null);
            var mockDmClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDmClient
                .Setup(s => s.ExecuteDMApi<Hub>(It.IsAny<RestRequest>(), It.IsAny<Func<string, DMApiResponseBase<Hub>>>(), It.IsAny<Action<RestResponse>>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetHub(It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);

            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new HubsApi(mockDmClient.Object, mockRequestBuilder.Object);

            //Act
            var hubs = sut.GetHub(id);

            //Assert
            mockRequestBuilder.Verify(s => s.UseGetHub(It.IsAny<string>()));
        }

        [Fact]
        public void GetHub_3_WhenCalled_InvokesRequestBuilderBuildExactlyOnce()
        {
            //Arrange
            var request = RestSharpFixtures.GetRequest();
            var model = HubsFixtures.RightModel();
            var id = HubsFixtures.RightId();

            var mockAuthenticator = new Mock<Authenticator>(_correctCC, Scope.Account_Read, null, null);
            var mockDmClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDmClient
                .Setup(s => s.ExecuteDMApi<Hub>(It.IsAny<RestRequest>(), It.IsAny<Func<string, DMApiResponseBase<Hub>>>(), It.IsAny<Action<RestResponse>>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetHub(It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);

            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new HubsApi(mockDmClient.Object, mockRequestBuilder.Object);

            //Act
            var hubs = sut.GetHub(id);

            //Assert
            mockRequestBuilder.Verify(s => s.Build(), Times.Once());
        }

        [Fact]
        public void GetHub_4_WhenCalled_InvokesDmClientExecuteExactlyOnce()
        {
            //Arrange
            var request = RestSharpFixtures.GetRequest();
            var model = HubsFixtures.RightModel();
            var id = HubsFixtures.RightId();

            var mockAuthenticator = new Mock<Authenticator>(_correctCC, Scope.Account_Read, null, null);
            var mockDmClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDmClient
                .Setup(s => s.ExecuteDMApi<Hub>(It.IsAny<RestRequest>(), It.IsAny<Func<string, DMApiResponseBase<Hub>>>(), It.IsAny<Action<RestResponse>>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetHub(It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);

            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new HubsApi(mockDmClient.Object, mockRequestBuilder.Object);

            //Act
            var hubs = sut.GetHub(id);

            //Assert
            mockDmClient.Verify(s => s.ExecuteDMApi<Hub>(It.IsAny<RestRequest>(), It.IsAny<Func<string, DMApiResponseBase<Hub>>>(), It.IsAny<Action<RestResponse>>()), Times.Once());
        }

        [Fact]
        public void GetHub_5_WhenCalled_InvokesDmClientExecuteWithRequestFromRequestBuilder()
        {
            //Arrange
            var request = RestSharpFixtures.GetRequest();
            var model = HubsFixtures.RightModel();
            var id = HubsFixtures.RightId();

            var mockAuthenticator = new Mock<Authenticator>(_correctCC, Scope.Account_Read, null, null);
            var mockDmClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDmClient
                .Setup(s => s.ExecuteDMApi<Hub>(It.IsAny<RestRequest>(), It.IsAny<Func<string, DMApiResponseBase<Hub>>>(), It.IsAny<Action<RestResponse>>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetHub(It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);

            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new HubsApi(mockDmClient.Object, mockRequestBuilder.Object);

            //Act
            var hubs = sut.GetHub(id);

            //Assert
            mockDmClient.Verify(s => s.ExecuteDMApi<Hub>(request, It.IsAny<Func<string, DMApiResponseBase<Hub>>>(), It.IsAny<Action<RestResponse>>()), Times.Once());
        }

        [Fact]
        public void GetHub_6_OnSuccess_RetursExecuteModel()
        {
            //Arrange
            var request = RestSharpFixtures.GetRequest();
            var model = HubsFixtures.RightModel();
            var id = HubsFixtures.RightId();

            var mockAuthenticator = new Mock<Authenticator>(_correctCC, Scope.Account_Read, null, null);
            var mockDmClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDmClient
                .Setup(s => s.ExecuteDMApi<Hub>(It.IsAny<RestRequest>(), It.IsAny<Func<string, DMApiResponseBase<Hub>>>(), It.IsAny<Action<RestResponse>>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetHub(It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);

            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new HubsApi(mockDmClient.Object, mockRequestBuilder.Object);

            //Act
            var hubs = sut.GetHub(id);

            //Assert
            hubs.Should().BeSameAs(model);
        }

        #endregion
    }
}
