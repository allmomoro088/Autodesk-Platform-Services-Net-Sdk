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

using Version = Autodesk.PlatformServices.DM.Version;

namespace APSAPITest.DM.Systems.Apis.DM
{
    public class ItemsApiTests
    {
        ClientCredentials _cc;

        public ItemsApiTests()
        {
            _cc = new ClientCredentials(APSFixtures.RightClientId(), APSFixtures.RightClientSecret());
        }

        #region GetItem

        [Fact]
        public void GetItem_1_OnSuccess_ReturnsModel()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projectId = ProjectsFixtures.RightId();
            var itemId = ItemsFixtures.RightItemId();
            var model = ItemsFixtures.RightItem();
            var request = RestSharpFixtures.GetRequest();

            var mockAuthClient = new Mock<AuthClient>();
            var mockAuthenticator = new Mock<Authenticator>(_cc, mockAuthClient.Object, It.IsAny<IScope>(), It.IsAny<I2LOStorage>(), It.IsAny<I3LOStorage>());
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.ExecuteDMApi<Item>(It.IsAny<RestRequest>(), It.IsAny<Func<string, DMApiResponseBase<Item>>>(), It.IsAny<Action<RestResponse>>()))
                .Returns(model);

            var mockDataBuilder = new Mock<DMDataBuilder>();
            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetItem(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);
            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new ItemsApi(mockDMClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            var result = sut.GetItem(projectId, itemId);

            //Assert
            result.Should().BeOfType<Item>();
            result.Should().Be(model);
        }

        [Fact]
        public void GetItem_2_WhenCalled_InvokesRequestBuilderUseGetItemExactlyOnceWithParameters()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projectId = ProjectsFixtures.RightId();
            var itemId = ItemsFixtures.RightItemId();
            var model = ItemsFixtures.RightItem();
            var request = RestSharpFixtures.GetRequest();

            var mockAuthClient = new Mock<AuthClient>();
            var mockAuthenticator = new Mock<Authenticator>(_cc, mockAuthClient.Object, It.IsAny<IScope>(), It.IsAny<I2LOStorage>(), It.IsAny<I3LOStorage>());
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.ExecuteDMApi<Item>(It.IsAny<RestRequest>(), It.IsAny<Func<string, DMApiResponseBase<Item>>>(), It.IsAny<Action<RestResponse>>()))
                .Returns(model);

            var mockDataBuilder = new Mock<DMDataBuilder>();
            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetItem(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);
            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new ItemsApi(mockDMClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            var result = sut.GetItem(projectId, itemId);

            //Assert
            mockRequestBuilder.Verify(s => s.UseGetItem(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
            mockRequestBuilder.Verify(s => s.UseGetItem(projectId, itemId), Times.Once());
        }

        [Fact]
        public void GetItem_3_WhenCalled_InvokesRequestBuilderBuildExactlyOnce()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projectId = ProjectsFixtures.RightId();
            var itemId = ItemsFixtures.RightItemId();
            var model = ItemsFixtures.RightItem();
            var request = RestSharpFixtures.GetRequest();

            var mockAuthClient = new Mock<AuthClient>();
            var mockAuthenticator = new Mock<Authenticator>(_cc, mockAuthClient.Object, It.IsAny<IScope>(), It.IsAny<I2LOStorage>(), It.IsAny<I3LOStorage>());
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.ExecuteDMApi<Item>(It.IsAny<RestRequest>(), It.IsAny<Func<string, DMApiResponseBase<Item>>>(), It.IsAny<Action<RestResponse>>()))
                .Returns(model);

            var mockDataBuilder = new Mock<DMDataBuilder>();
            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetItem(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);
            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new ItemsApi(mockDMClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            var result = sut.GetItem(projectId, itemId);

            //Assert
            mockRequestBuilder.Verify(s => s.Build(), Times.Once());
        }

        [Fact]
        public void GetItem_4_WhenCalled_InvokesDMClientExecuteExactlyOnceWithBuiltRequest()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projectId = ProjectsFixtures.RightId();
            var itemId = ItemsFixtures.RightItemId();
            var model = ItemsFixtures.RightItem();
            var request = RestSharpFixtures.GetRequest();

            var mockAuthClient = new Mock<AuthClient>();
            var mockAuthenticator = new Mock<Authenticator>(_cc, mockAuthClient.Object, It.IsAny<IScope>(), It.IsAny<I2LOStorage>(), It.IsAny<I3LOStorage>());
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.ExecuteDMApi<Item>(It.IsAny<RestRequest>(), It.IsAny<Func<string, DMApiResponseBase<Item>>>(), It.IsAny<Action<RestResponse>>()))
                .Returns(model);

            var mockDataBuilder = new Mock<DMDataBuilder>();
            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetItem(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);
            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new ItemsApi(mockDMClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            var result = sut.GetItem(projectId, itemId);

            //Assert
            mockDMClient.Verify(s => s.ExecuteDMApi<Item>(It.IsAny<RestRequest>(), It.IsAny<Func<string, DMApiResponseBase<Item>>>(), It.IsAny<Action<RestResponse>>()), Times.Once());
            mockDMClient.Verify(s => s.ExecuteDMApi<Item>(request, It.IsAny<Func<string, DMApiResponseBase<Item>>>(), It.IsAny<Action<RestResponse>>()), Times.Once());
        }

        #endregion

        #region GetItemTip

        [Fact]
        public void GetItemTip_1_OnSuccess_ReturnsModel()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projectId = ProjectsFixtures.RightId();
            var itemId = ItemsFixtures.RightItemId();
            var model = VersionsFixtures.RightVersion();
            var request = RestSharpFixtures.GetRequest();

            var mockAuthClient = new Mock<AuthClient>();
            var mockAuthenticator = new Mock<Authenticator>(_cc, mockAuthClient.Object, It.IsAny<IScope>(), It.IsAny<I2LOStorage>(), It.IsAny<I3LOStorage>());
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.ExecuteDMApi<Version>(It.IsAny<RestRequest>(), It.IsAny<Func<string, DMApiResponseBase<Version>>>(), It.IsAny<Action<RestResponse>>()))
                .Returns(model);

            var mockDataBuilder = new Mock<DMDataBuilder>();
            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetItemTip(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);
            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new ItemsApi(mockDMClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            var result = sut.GetItemTip(projectId, itemId);

            //Assert
            result.Should().BeOfType<Version>();
            result.Should().Be(model);
        }

        [Fact]
        public void GetItemTip_2_WhenCalled_InvokesRequestBuilderUseGetItemTipExactlyOnceWithParameters()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projectId = ProjectsFixtures.RightId();
            var itemId = ItemsFixtures.RightItemId();
            var model = VersionsFixtures.RightVersion();
            var request = RestSharpFixtures.GetRequest();

            var mockAuthClient = new Mock<AuthClient>();
            var mockAuthenticator = new Mock<Authenticator>(_cc, mockAuthClient.Object, It.IsAny<IScope>(), It.IsAny<I2LOStorage>(), It.IsAny<I3LOStorage>());
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.ExecuteDMApi<Version>(It.IsAny<RestRequest>(), It.IsAny<Func<string, DMApiResponseBase<Version>>>(), It.IsAny<Action<RestResponse>>()))
                .Returns(model);

            var mockDataBuilder = new Mock<DMDataBuilder>();
            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetItemTip(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);
            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new ItemsApi(mockDMClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            var result = sut.GetItemTip(projectId, itemId);

            //Assert
            mockRequestBuilder.Verify(s => s.UseGetItemTip(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
            mockRequestBuilder.Verify(s => s.UseGetItemTip(projectId, itemId), Times.Once());
        }

        [Fact]
        public void GetItemTip_3_WhenCalled_InvokesRequestBuilderBuildExactlyOnce()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projectId = ProjectsFixtures.RightId();
            var itemId = ItemsFixtures.RightItemId();
            var model = VersionsFixtures.RightVersion();
            var request = RestSharpFixtures.GetRequest();

            var mockAuthClient = new Mock<AuthClient>();
            var mockAuthenticator = new Mock<Authenticator>(_cc, mockAuthClient.Object, It.IsAny<IScope>(), It.IsAny<I2LOStorage>(), It.IsAny<I3LOStorage>());
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.ExecuteDMApi<Version>(It.IsAny<RestRequest>(), It.IsAny<Func<string, DMApiResponseBase<Version>>>(), It.IsAny<Action<RestResponse>>()))
                .Returns(model);

            var mockDataBuilder = new Mock<DMDataBuilder>();
            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetItemTip(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);
            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new ItemsApi(mockDMClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            var result = sut.GetItemTip(projectId, itemId);

            //Assert
            mockRequestBuilder.Verify(s => s.Build(), Times.Once());
        }

        [Fact]
        public void GetItemTip_4_WhenCalled_InvokesDMClientExecuteExactlyOnceWithBuiltRequest()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projectId = ProjectsFixtures.RightId();
            var itemId = ItemsFixtures.RightItemId();
            var model = VersionsFixtures.RightVersion();
            var request = RestSharpFixtures.GetRequest();

            var mockAuthClient = new Mock<AuthClient>();
            var mockAuthenticator = new Mock<Authenticator>(_cc, mockAuthClient.Object, It.IsAny<IScope>(), It.IsAny<I2LOStorage>(), It.IsAny<I3LOStorage>());
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.ExecuteDMApi<Version>(It.IsAny<RestRequest>(), It.IsAny<Func<string, DMApiResponseBase<Version>>>(), It.IsAny<Action<RestResponse>>()))
                .Returns(model);

            var mockDataBuilder = new Mock<DMDataBuilder>();
            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetItemTip(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);
            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new ItemsApi(mockDMClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            var result = sut.GetItemTip(projectId, itemId);

            //Assert
            mockDMClient.Verify(s => s.ExecuteDMApi<Version>(It.IsAny<RestRequest>(), It.IsAny<Func<string, DMApiResponseBase<Version>>>(), It.IsAny<Action<RestResponse>>()), Times.Once());
            mockDMClient.Verify(s => s.ExecuteDMApi<Version>(request, It.IsAny<Func<string, DMApiResponseBase<Version>>>(), It.IsAny<Action<RestResponse>>()), Times.Once());
        }

        #endregion

        #region PostItem

        [Fact]
        public void PostItem_1_OnSuccess_ReturnsModel()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projectId = ProjectsFixtures.RightId();
            var storageId = ProjectsFixtures.RightStorageLocation().Id;
            var folderId = FoldersFixtures.RightFolder().Id;
            var fileName = ItemsFixtures.RightFileName();
            var itemId = ItemsFixtures.RightItemId();
            var model = ItemsFixtures.RightItem();
            var request = RestSharpFixtures.PostRequest();
            var data = "\"data\": \"this is some data\"";

            var mockAuthClient = new Mock<AuthClient>();
            var mockAuthenticator = new Mock<Authenticator>(_cc, mockAuthClient.Object, It.IsAny<IScope>(), It.IsAny<I2LOStorage>(), It.IsAny<I3LOStorage>());
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.ExecuteDMApi<Item>(It.IsAny<RestRequest>(), It.IsAny<Func<string, DMApiResponseBase<Item>>>(), It.IsAny<Action<RestResponse>>()))
                .Returns(model);

            var mockDataBuilder = new Mock<DMDataBuilder>();
            mockDataBuilder
                .Setup(s => s.UseItem(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockDataBuilder.Object);
            mockDataBuilder
                .Setup(s => s.Build())
                .Returns(data);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UsePostItem(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);
            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new ItemsApi(mockDMClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            var result = sut.PostItem(projectId, fileName, folderId, storageId);

            //Assert
            result.Should().BeOfType<Item>();
            result.Should().Be(model);
        }

        [Fact]
        public void PostItem_2_WhenCalled_InvokesDataBuilderUseItemExactlyOnceWithParametersProvided()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projectId = ProjectsFixtures.RightId();
            var storageId = ProjectsFixtures.RightStorageLocation().Id;
            var folderId = FoldersFixtures.RightFolder().Id;
            var fileName = ItemsFixtures.RightFileName();
            var itemId = ItemsFixtures.RightItemId();
            var model = ItemsFixtures.RightItem();
            var request = RestSharpFixtures.PostRequest();
            var data = "\"data\": \"this is some data\"";

            var mockAuthClient = new Mock<AuthClient>();
            var mockAuthenticator = new Mock<Authenticator>(_cc, mockAuthClient.Object, It.IsAny<IScope>(), It.IsAny<I2LOStorage>(), It.IsAny<I3LOStorage>());
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.ExecuteDMApi<Item>(It.IsAny<RestRequest>(), It.IsAny<Func<string, DMApiResponseBase<Item>>>(), It.IsAny<Action<RestResponse>>()))
                .Returns(model);

            var mockDataBuilder = new Mock<DMDataBuilder>();
            mockDataBuilder
                .Setup(s => s.UseItem(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockDataBuilder.Object);
            mockDataBuilder
                .Setup(s => s.Build())
                .Returns(data);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UsePostItem(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);
            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new ItemsApi(mockDMClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            var result = sut.PostItem(projectId, fileName, folderId, storageId);

            //Assert
            mockDataBuilder.Verify(s => s.UseItem(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once());
            mockDataBuilder.Verify(s => s.UseItem(fileName, folderId, storageId), Times.Once());
        }

        [Fact]
        public void PostItem_3_WhenCalled_InvokesDataBuilderBuildExactlyOnce()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projectId = ProjectsFixtures.RightId();
            var storageId = ProjectsFixtures.RightStorageLocation().Id;
            var folderId = FoldersFixtures.RightFolder().Id;
            var fileName = ItemsFixtures.RightFileName();
            var itemId = ItemsFixtures.RightItemId();
            var model = ItemsFixtures.RightItem();
            var request = RestSharpFixtures.PostRequest();
            var data = "\"data\": \"this is some data\"";

            var mockAuthClient = new Mock<AuthClient>();
            var mockAuthenticator = new Mock<Authenticator>(_cc, mockAuthClient.Object, It.IsAny<IScope>(), It.IsAny<I2LOStorage>(), It.IsAny<I3LOStorage>());
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.ExecuteDMApi<Item>(It.IsAny<RestRequest>(), It.IsAny<Func<string, DMApiResponseBase<Item>>>(), It.IsAny<Action<RestResponse>>()))
                .Returns(model);

            var mockDataBuilder = new Mock<DMDataBuilder>();
            mockDataBuilder
                .Setup(s => s.UseItem(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockDataBuilder.Object);
            mockDataBuilder
                .Setup(s => s.Build())
                .Returns(data);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UsePostItem(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);
            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new ItemsApi(mockDMClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            var result = sut.PostItem(projectId, fileName, folderId, storageId);

            //Assert
            mockDataBuilder.Verify(s => s.Build(), Times.Once());
        }

        [Fact]
        public void PostItem_4_WhenCalled_InvokesRequestBuilderUsePostItemExactlyOnceWithParametersAndBuiltData()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projectId = ProjectsFixtures.RightId();
            var storageId = ProjectsFixtures.RightStorageLocation().Id;
            var folderId = FoldersFixtures.RightFolder().Id;
            var fileName = ItemsFixtures.RightFileName();
            var itemId = ItemsFixtures.RightItemId();
            var model = ItemsFixtures.RightItem();
            var request = RestSharpFixtures.PostRequest();
            var data = "\"data\": \"this is some data\"";

            var mockAuthClient = new Mock<AuthClient>();
            var mockAuthenticator = new Mock<Authenticator>(_cc, mockAuthClient.Object, It.IsAny<IScope>(), It.IsAny<I2LOStorage>(), It.IsAny<I3LOStorage>());
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.ExecuteDMApi<Item>(It.IsAny<RestRequest>(), It.IsAny<Func<string, DMApiResponseBase<Item>>>(), It.IsAny<Action<RestResponse>>()))
                .Returns(model);

            var mockDataBuilder = new Mock<DMDataBuilder>();
            mockDataBuilder
                .Setup(s => s.UseItem(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockDataBuilder.Object);
            mockDataBuilder
                .Setup(s => s.Build())
                .Returns(data);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UsePostItem(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);
            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new ItemsApi(mockDMClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            var result = sut.PostItem(projectId, fileName, folderId, storageId);

            //Assert
            mockRequestBuilder.Verify(s => s.UsePostItem(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
            mockRequestBuilder.Verify(s => s.UsePostItem(projectId, data), Times.Once());
        }

        [Fact]
        public void PostItem_5_WhenCalled_InvokesRequestBuilderBuildExactlyOnce()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projectId = ProjectsFixtures.RightId();
            var storageId = ProjectsFixtures.RightStorageLocation().Id;
            var folderId = FoldersFixtures.RightFolder().Id;
            var fileName = ItemsFixtures.RightFileName();
            var itemId = ItemsFixtures.RightItemId();
            var model = ItemsFixtures.RightItem();
            var request = RestSharpFixtures.PostRequest();
            var data = "\"data\": \"this is some data\"";

            var mockAuthClient = new Mock<AuthClient>();
            var mockAuthenticator = new Mock<Authenticator>(_cc, mockAuthClient.Object, It.IsAny<IScope>(), It.IsAny<I2LOStorage>(), It.IsAny<I3LOStorage>());
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.ExecuteDMApi<Item>(It.IsAny<RestRequest>(), It.IsAny<Func<string, DMApiResponseBase<Item>>>(), It.IsAny<Action<RestResponse>>()))
                .Returns(model);

            var mockDataBuilder = new Mock<DMDataBuilder>();
            mockDataBuilder
                .Setup(s => s.UseItem(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockDataBuilder.Object);
            mockDataBuilder
                .Setup(s => s.Build())
                .Returns(data);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UsePostItem(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);
            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new ItemsApi(mockDMClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            var result = sut.PostItem(projectId, fileName, folderId, storageId);

            //Assert
            mockRequestBuilder.Verify(s => s.Build(), Times.Once());
        }

        [Fact]
        public void PostItem_6_WhenCalled_InvokesDMClientExecuteExactlyOnceWithBuiltRequest()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projectId = ProjectsFixtures.RightId();
            var storageId = ProjectsFixtures.RightStorageLocation().Id;
            var folderId = FoldersFixtures.RightFolder().Id;
            var fileName = ItemsFixtures.RightFileName();
            var itemId = ItemsFixtures.RightItemId();
            var model = ItemsFixtures.RightItem();
            var request = RestSharpFixtures.PostRequest();
            var data = "\"data\": \"this is some data\"";

            var mockAuthClient = new Mock<AuthClient>();
            var mockAuthenticator = new Mock<Authenticator>(_cc, mockAuthClient.Object, It.IsAny<IScope>(), It.IsAny<I2LOStorage>(), It.IsAny<I3LOStorage>());
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.ExecuteDMApi<Item>(It.IsAny<RestRequest>(), It.IsAny<Func<string, DMApiResponseBase<Item>>>(), It.IsAny<Action<RestResponse>>()))
                .Returns(model);

            var mockDataBuilder = new Mock<DMDataBuilder>();
            mockDataBuilder
                .Setup(s => s.UseItem(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockDataBuilder.Object);
            mockDataBuilder
                .Setup(s => s.Build())
                .Returns(data);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UsePostItem(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);
            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new ItemsApi(mockDMClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            var result = sut.PostItem(projectId, fileName, folderId, storageId);

            //Assert
            mockDMClient.Verify(s => s.ExecuteDMApi<Item>(It.IsAny<RestRequest>(), It.IsAny<Func<string, DMApiResponseBase<Item>>>(), It.IsAny<Action<RestResponse>>()), Times.Once());
            mockDMClient.Verify(s => s.ExecuteDMApi<Item>(request, It.IsAny<Func<string, DMApiResponseBase<Item>>>(), It.IsAny<Action<RestResponse>>()), Times.Once());
        }

        #endregion
    }
}
