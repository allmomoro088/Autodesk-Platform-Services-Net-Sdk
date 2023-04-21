using APSAPITest.DM.Fixtures;
using Autodesk.PlatformServices.Auth;
using Autodesk.PlatformServices.DM;
using FluentAssertions;
using Moq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Version = Autodesk.PlatformServices.DM.Version;

namespace APSAPITest.DM.Systems.Apis.DM
{
    public class FoldersApiTests
    {
        ClientCredentials _cc;

        public FoldersApiTests()
        {
            _cc = new ClientCredentials(APSFixtures.RightClientId(), APSFixtures.RightClientSecret());
        }

        #region GetFolder

        [Fact]
        public void GetFolder_1_OnSuccess_ReturnsModel()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projectId = ProjectsFixtures.RightId();
            var folderId = ProjectsFixtures.RightFolderId();
            var model = FoldersFixtures.RightFolder();
            var request = RestSharpFixtures.GetRequest();

            var mockAuthenticator = new Mock<Authenticator>(_cc, Scope.Data_Read | Scope.Data_Create | Scope.Data_Write, null, null);
            var mockDmClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDmClient
                .Setup(s => s.ExecuteDMApi<Folder>(It.IsAny<RestRequest>(), It.IsAny<Func<string, DMApiResponseBase<Folder>>>(), It.IsAny<Action<RestResponse>>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetFolder(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);

            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var mockDataBuilder = new Mock<DMDataBuilder>();

            var sut = new FoldersApi(mockDmClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            var result = sut.GetFolder(projectId, folderId);

            //Assert
            result.Should().BeOfType<Folder>();
        }

        [Fact]
        public void GetFolder_2_WhenCalled_InvokesRequestBuilderUseGetFolderExactlyOnce()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projectId = ProjectsFixtures.RightId();
            var folderId = ProjectsFixtures.RightFolderId();
            var model = FoldersFixtures.RightFolder();
            var request = RestSharpFixtures.GetRequest();

            var mockAuthenticator = new Mock<Authenticator>(_cc, Scope.Data_Read | Scope.Data_Create | Scope.Data_Write, null, null);
            var mockDmClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDmClient
                .Setup(s => s.ExecuteDMApi<Folder>(It.IsAny<RestRequest>(), It.IsAny<Func<string, DMApiResponseBase<Folder>>>(), It.IsAny<Action<RestResponse>>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetFolder(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);

            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var mockDataBuilder = new Mock<DMDataBuilder>();

            var sut = new FoldersApi(mockDmClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            var result = sut.GetFolder(projectId, folderId);

            //Assert
            mockRequestBuilder.Verify(s => s.UseGetFolder(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public void GetFolder_3_WhenCalled_InvokesRequestBuilderBuildExactlyOnce()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projectId = ProjectsFixtures.RightId();
            var folderId = ProjectsFixtures.RightFolderId();
            var model = FoldersFixtures.RightFolder();
            var request = RestSharpFixtures.GetRequest();

            var mockAuthenticator = new Mock<Authenticator>(_cc, Scope.Data_Read | Scope.Data_Create | Scope.Data_Write, null, null);
            var mockDmClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDmClient
                .Setup(s => s.ExecuteDMApi<Folder>(It.IsAny<RestRequest>(), It.IsAny<Func<string, DMApiResponseBase<Folder>>>(), It.IsAny<Action<RestResponse>>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetFolder(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);

            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var mockDataBuilder = new Mock<DMDataBuilder>();

            var sut = new FoldersApi(mockDmClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            var result = sut.GetFolder(projectId, folderId);

            //Assert
            mockRequestBuilder.Verify(s => s.Build(), Times.Once());
        }

        [Fact]
        public void GetFolder_4_WhenCalled_InvokesDmClientExecuteExactlyOnce()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projectId = ProjectsFixtures.RightId();
            var folderId = ProjectsFixtures.RightFolderId();
            var model = FoldersFixtures.RightFolder();
            var request = RestSharpFixtures.GetRequest();

            var mockAuthenticator = new Mock<Authenticator>(_cc, Scope.Data_Read | Scope.Data_Create | Scope.Data_Write, null, null);
            var mockDmClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDmClient
                .Setup(s => s.ExecuteDMApi<Folder>(It.IsAny<RestRequest>(), It.IsAny<Func<string, DMApiResponseBase<Folder>>>(), It.IsAny<Action<RestResponse>>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetFolder(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);

            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var mockDataBuilder = new Mock<DMDataBuilder>();

            var sut = new FoldersApi(mockDmClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            var result = sut.GetFolder(projectId, folderId);

            //Assert
            mockDmClient.Verify(s => s.ExecuteDMApi<Folder>(It.IsAny<RestRequest>(), It.IsAny<Func<string, DMApiResponseBase<Folder>>>(), It.IsAny<Action<RestResponse>>()), Times.Once());
        }

        [Fact]
        public void GetFolder_5_WhenCalled_InvokesDmClientExecuteWithBuiltRequest()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projectId = ProjectsFixtures.RightId();
            var folderId = ProjectsFixtures.RightFolderId();
            var model = FoldersFixtures.RightFolder();
            var request = RestSharpFixtures.GetRequest();

            var mockAuthenticator = new Mock<Authenticator>(_cc, Scope.Data_Read | Scope.Data_Create | Scope.Data_Write, null, null);
            var mockDmClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDmClient
                .Setup(s => s.ExecuteDMApi<Folder>(It.IsAny<RestRequest>(), It.IsAny<Func<string, DMApiResponseBase<Folder>>>(), It.IsAny<Action<RestResponse>>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetFolder(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);

            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var mockDataBuilder = new Mock<DMDataBuilder>();

            var sut = new FoldersApi(mockDmClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            var result = sut.GetFolder(projectId, folderId);

            //Assert
            mockDmClient.Verify(s => s.ExecuteDMApi<Folder>(request, It.IsAny<Func<string, DMApiResponseBase<Folder>>>(), It.IsAny<Action<RestResponse>>()), Times.Once());
        }

        [Fact]
        public void GetFolder_6_WhenCalled_InvokesRequestBuilderUseGetFolderWithParametersProvided()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projectId = ProjectsFixtures.RightId();
            var folderId = ProjectsFixtures.RightFolderId();
            var model = FoldersFixtures.RightFolder();
            var request = RestSharpFixtures.GetRequest();

            var mockAuthenticator = new Mock<Authenticator>(_cc, Scope.Data_Read | Scope.Data_Create | Scope.Data_Write, null, null);
            var mockDmClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDmClient
                .Setup(s => s.ExecuteDMApi<Folder>(It.IsAny<RestRequest>(), It.IsAny<Func<string, DMApiResponseBase<Folder>>>(), It.IsAny<Action<RestResponse>>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetFolder(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);

            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var mockDataBuilder = new Mock<DMDataBuilder>();

            var sut = new FoldersApi(mockDmClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            var result = sut.GetFolder(projectId, folderId);

            //Assert
            mockRequestBuilder.Verify(s => s.UseGetFolder(projectId, folderId), Times.Once());
        }
        [Fact]
        public void GetFolder_7_OnSuccess_ReturnsModelFromExecute()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projectId = ProjectsFixtures.RightId();
            var folderId = ProjectsFixtures.RightFolderId();
            var model = FoldersFixtures.RightFolder();
            var request = RestSharpFixtures.GetRequest();

            var mockAuthenticator = new Mock<Authenticator>(_cc, Scope.Data_Read | Scope.Data_Create | Scope.Data_Write, null, null);
            var mockDmClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDmClient
                .Setup(s => s.ExecuteDMApi<Folder>(It.IsAny<RestRequest>(), It.IsAny<Func<string, DMApiResponseBase<Folder>>>(), It.IsAny<Action<RestResponse>>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetFolder(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);

            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var mockDataBuilder = new Mock<DMDataBuilder>();

            var sut = new FoldersApi(mockDmClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            var result = sut.GetFolder(projectId, folderId);

            //Assert
            result.Should().Be(model);
        }

        #endregion

        #region GetContents

        [Fact]
        public void GetContents_1_OnSuccess_ReturnsModel()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projectId = ProjectsFixtures.RightId();
            var folderId = ProjectsFixtures.RightFolderId();
            var model = FoldersFixtures.RightContents();
            var request = RestSharpFixtures.GetRequest();

            var mockAuthenticator = new Mock<Authenticator>(_cc, Scope.Data_Read | Scope.Data_Create | Scope.Data_Write, null, null);
            var mockDmClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDmClient
                .Setup(s => s.Execute<Contents, Folder, Item, Version>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetContents(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);

            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var mockDataBuilder = new Mock<DMDataBuilder>();

            var sut = new FoldersApi(mockDmClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            var result = sut.GetContents(projectId, folderId);

            //Assert
            result.Should().BeOfType<Contents>();
        }

        [Fact]
        public void GetContents_2_WhenCalled_InvokesRequestBuilderUseGetContentsExactlyOnceWithProvidedParameter()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projectId = ProjectsFixtures.RightId();
            var folderId = ProjectsFixtures.RightFolderId();
            var model = FoldersFixtures.RightContents();
            var request = RestSharpFixtures.GetRequest();

            var mockAuthenticator = new Mock<Authenticator>(_cc, Scope.Data_Read | Scope.Data_Create | Scope.Data_Write, null, null);
            var mockDmClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDmClient
                .Setup(s => s.Execute<Contents, Folder, Item, Version>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetContents(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);

            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var mockDataBuilder = new Mock<DMDataBuilder>();

            var sut = new FoldersApi(mockDmClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            var result = sut.GetContents(projectId, folderId);

            //Assert
            mockRequestBuilder.Verify(s => s.UseGetContents(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
            mockRequestBuilder.Verify(s => s.UseGetContents(projectId, folderId), Times.Once());
        }

        [Fact]
        public void GetContents_3_WhenCalled_InvokesRequestBuilderBuildExactlyOnce()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projectId = ProjectsFixtures.RightId();
            var folderId = ProjectsFixtures.RightFolderId();
            var model = FoldersFixtures.RightContents();
            var request = RestSharpFixtures.GetRequest();

            var mockAuthenticator = new Mock<Authenticator>(_cc, Scope.Data_Read | Scope.Data_Create | Scope.Data_Write, null, null);
            var mockDmClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDmClient
                .Setup(s => s.Execute<Contents, Folder, Item, Version>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetContents(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);

            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var mockDataBuilder = new Mock<DMDataBuilder>();

            var sut = new FoldersApi(mockDmClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            var result = sut.GetContents(projectId, folderId);

            //Assert
            mockRequestBuilder.Verify(s => s.Build(), Times.Once());
        }

        [Fact]
        public void GetContents_4_WhenCalled_InvokesDmClientExecuteExactlyOnceWithBuiltRequest()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projectId = ProjectsFixtures.RightId();
            var folderId = ProjectsFixtures.RightFolderId();
            var model = FoldersFixtures.RightContents();
            var request = RestSharpFixtures.GetRequest();

            var mockAuthenticator = new Mock<Authenticator>(_cc, Scope.Data_Read | Scope.Data_Create | Scope.Data_Write, null, null);
            var mockDmClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDmClient
                .Setup(s => s.Execute<Contents, Folder, Item, Version>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetContents(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);

            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var mockDataBuilder = new Mock<DMDataBuilder>();

            var sut = new FoldersApi(mockDmClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            var result = sut.GetContents(projectId, folderId);

            //Assert
            mockDmClient.Verify(s => s.Execute<Contents, Folder, Item, Version>(It.IsAny<RestRequest>()), Times.Once());
            mockDmClient.Verify(s => s.Execute<Contents, Folder, Item, Version>(request), Times.Once());
        }

        [Fact]
        public void GetContents_5_OnSuccess_ReturnsModelFromExecute()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projectId = ProjectsFixtures.RightId();
            var folderId = ProjectsFixtures.RightFolderId();
            var model = FoldersFixtures.RightContents();
            var request = RestSharpFixtures.GetRequest();

            var mockAuthenticator = new Mock<Authenticator>(_cc, Scope.Data_Read | Scope.Data_Create | Scope.Data_Write, null, null);
            var mockDmClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDmClient
                .Setup(s => s.Execute<Contents, Folder, Item, Version>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetContents(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);

            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var mockDataBuilder = new Mock<DMDataBuilder>();

            var sut = new FoldersApi(mockDmClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            var result = sut.GetContents(projectId, folderId);

            //Assert
            result.Should().Be(model);
        }

        #endregion

        #region PostFolder

        [Fact]
        public void PostFolder_1_OnSuccess_ReturnsModel()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projectId = ProjectsFixtures.RightId();
            var folderId = ProjectsFixtures.RightFolderId();
            var model = FoldersFixtures.RightFolder();
            var request = RestSharpFixtures.GetRequest();
            var folderName = FoldersFixtures.RightFolderName();
            var data = "\"data\": \"this is some data\"";

            var mockAuthenticator = new Mock<Authenticator>(_cc, Scope.Data_Read | Scope.Data_Create | Scope.Data_Write, null, null);
            var mockDmClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDmClient
                .Setup(s => s.ExecuteDMApi<Folder>(It.IsAny<RestRequest>(), It.IsAny<Func<string, DMApiResponseBase<Folder>>>(), It.IsAny<Action<RestResponse>>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UsePostFolder(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);

            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var mockDataBuilder = new Mock<DMDataBuilder>();
            mockDataBuilder
                .Setup(s => s.UseFolder(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockDataBuilder.Object);

            mockDataBuilder
                .Setup(s => s.Build())
                .Returns(data);

            var sut = new FoldersApi(mockDmClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            var result = sut.PostFolder(projectId, folderName, folderId);

            //Assert
            result.Should().BeOfType<Folder>();
            result.Should().Be(model);
        }

        [Fact]
        public void PostFolder_2_WhenCalled_InvokesDataBuilderUseFolderExactlyOnceWithParametersProvided()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projectId = ProjectsFixtures.RightId();
            var folderId = ProjectsFixtures.RightFolderId();
            var model = FoldersFixtures.RightFolder();
            var request = RestSharpFixtures.GetRequest();
            var folderName = FoldersFixtures.RightFolderName();
            var data = "\"data\": \"this is some data\"";

            var mockAuthenticator = new Mock<Authenticator>(_cc, Scope.Data_Read | Scope.Data_Create | Scope.Data_Write, null, null);
            var mockDmClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDmClient
                .Setup(s => s.ExecuteDMApi<Folder>(It.IsAny<RestRequest>(), It.IsAny<Func<string, DMApiResponseBase<Folder>>>(), It.IsAny<Action<RestResponse>>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UsePostFolder(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);

            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var mockDataBuilder = new Mock<DMDataBuilder>();
            mockDataBuilder
                .Setup(s => s.UseFolder(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockDataBuilder.Object);

            mockDataBuilder
                .Setup(s => s.Build())
                .Returns(data);

            var sut = new FoldersApi(mockDmClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            var result = sut.PostFolder(projectId, folderName, folderId);

            //Assert
            mockDataBuilder.Verify(s => s.UseFolder(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
            mockDataBuilder.Verify(s => s.UseFolder(folderName, folderId), Times.Once());
        }

        [Fact]
        public void PostFolder_3_WhenCalled_InvokesDataBuilderBuildExactlyOnce()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projectId = ProjectsFixtures.RightId();
            var folderId = ProjectsFixtures.RightFolderId();
            var model = FoldersFixtures.RightFolder();
            var request = RestSharpFixtures.GetRequest();
            var folderName = FoldersFixtures.RightFolderName();
            var data = "\"data\": \"this is some data\"";

            var mockAuthenticator = new Mock<Authenticator>(_cc, Scope.Data_Read | Scope.Data_Create | Scope.Data_Write, null, null);
            var mockDmClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDmClient
                .Setup(s => s.ExecuteDMApi<Folder>(It.IsAny<RestRequest>(), It.IsAny<Func<string, DMApiResponseBase<Folder>>>(), It.IsAny<Action<RestResponse>>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UsePostFolder(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);

            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var mockDataBuilder = new Mock<DMDataBuilder>();
            mockDataBuilder
                .Setup(s => s.UseFolder(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockDataBuilder.Object);

            mockDataBuilder
                .Setup(s => s.Build())
                .Returns(data);

            var sut = new FoldersApi(mockDmClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            var result = sut.PostFolder(projectId, folderName, folderId);

            //Assert
            mockDataBuilder.Verify(s => s.Build(), Times.Once());
        }

        [Fact]
        public void PostFolder_4_WhenCalled_InvokesRequestBuilderUsePostFolderExactlyOnceWithProvidedParameterAndBuiltData()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projectId = ProjectsFixtures.RightId();
            var folderId = ProjectsFixtures.RightFolderId();
            var model = FoldersFixtures.RightFolder();
            var request = RestSharpFixtures.GetRequest();
            var folderName = FoldersFixtures.RightFolderName();
            var data = "\"data\": \"this is some data\"";

            var mockAuthenticator = new Mock<Authenticator>(_cc, Scope.Data_Read | Scope.Data_Create | Scope.Data_Write, null, null);
            var mockDmClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDmClient
                .Setup(s => s.ExecuteDMApi<Folder>(It.IsAny<RestRequest>(), It.IsAny<Func<string, DMApiResponseBase<Folder>>>(), It.IsAny<Action<RestResponse>>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UsePostFolder(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);

            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var mockDataBuilder = new Mock<DMDataBuilder>();
            mockDataBuilder
                .Setup(s => s.UseFolder(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockDataBuilder.Object);

            mockDataBuilder
                .Setup(s => s.Build())
                .Returns(data);

            var sut = new FoldersApi(mockDmClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            var result = sut.PostFolder(projectId, folderName, folderId);

            //Assert
            mockRequestBuilder.Verify(s => s.UsePostFolder(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
            mockRequestBuilder.Verify(s => s.UsePostFolder(projectId, data), Times.Once());
        }

        [Fact]
        public void PostFolder_5_WhenCalled_InvokesRequestBuilderBuildExactlyOnce()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projectId = ProjectsFixtures.RightId();
            var folderId = ProjectsFixtures.RightFolderId();
            var model = FoldersFixtures.RightFolder();
            var request = RestSharpFixtures.GetRequest();
            var folderName = FoldersFixtures.RightFolderName();
            var data = "\"data\": \"this is some data\"";

            var mockAuthenticator = new Mock<Authenticator>(_cc, Scope.Data_Read | Scope.Data_Create | Scope.Data_Write, null, null);
            var mockDmClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDmClient
                .Setup(s => s.ExecuteDMApi<Folder>(It.IsAny<RestRequest>(), It.IsAny<Func<string, DMApiResponseBase<Folder>>>(), It.IsAny<Action<RestResponse>>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UsePostFolder(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);

            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var mockDataBuilder = new Mock<DMDataBuilder>();
            mockDataBuilder
                .Setup(s => s.UseFolder(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockDataBuilder.Object);

            mockDataBuilder
                .Setup(s => s.Build())
                .Returns(data);

            var sut = new FoldersApi(mockDmClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            var result = sut.PostFolder(projectId, folderName, folderId);

            //Assert
            mockRequestBuilder.Verify(s => s.Build(), Times.Once());
        }

        [Fact]
        public void PostFolder_6_WhenCalled_InvokesDmClientExecuteExactlyOnceWithBuiltRequest()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projectId = ProjectsFixtures.RightId();
            var folderId = ProjectsFixtures.RightFolderId();
            var model = FoldersFixtures.RightFolder();
            var request = RestSharpFixtures.GetRequest();
            var folderName = FoldersFixtures.RightFolderName();
            var data = "\"data\": \"this is some data\"";

            var mockAuthenticator = new Mock<Authenticator>(_cc, Scope.Data_Read | Scope.Data_Create | Scope.Data_Write, null, null);
            var mockDmClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDmClient
                .Setup(s => s.ExecuteDMApi<Folder>(It.IsAny<RestRequest>(), It.IsAny<Func<string, DMApiResponseBase<Folder>>>(), It.IsAny<Action<RestResponse>>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UsePostFolder(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);

            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var mockDataBuilder = new Mock<DMDataBuilder>();
            mockDataBuilder
                .Setup(s => s.UseFolder(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockDataBuilder.Object);

            mockDataBuilder
                .Setup(s => s.Build())
                .Returns(data);

            var sut = new FoldersApi(mockDmClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            var result = sut.PostFolder(projectId, folderName, folderId);

            //Assert
            mockDmClient.Verify(s => s.ExecuteDMApi<Folder>(It.IsAny<RestRequest>(), It.IsAny<Func<string, DMApiResponseBase<Folder>>>(), It.IsAny<Action<RestResponse>>()), Times.Once());
            mockDmClient.Verify(s => s.ExecuteDMApi<Folder>(request, It.IsAny<Func<string, DMApiResponseBase<Folder>>>(), It.IsAny<Action<RestResponse>>()), Times.Once());
        }

        #endregion
    }
}
