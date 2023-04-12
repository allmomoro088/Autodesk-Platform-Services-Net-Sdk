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
    public class ProjectsApiTests
    {
        ClientCredentials _correctCC;
        public ProjectsApiTests()
        {
            _correctCC = new ClientCredentials(APSFixtures.RightClientId(), APSFixtures.RightClientSecret());
        }

        #region GetProjects

        [Fact]
        public void GetProjects_1_OnSuccess_ReturnsModel()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var request = RestSharpFixtures.GetRequest();
            var model = ProjectsFixtures.RightModelList();

            var mockDMDataBuilder = new Mock<DMDataBuilder>();
            var mockAuthenticator = new Mock<Authenticator>(_correctCC, Scope.Account_Read, null, null);
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.ExecutePaginated<List<Project>, Project>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockDMRequestBuilder = new Mock<DMRequestBuilder>();
            mockDMRequestBuilder
                .Setup(s => s.UseGetProjects(It.IsAny<string>()))
                .Returns(mockDMRequestBuilder.Object);

            mockDMRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new ProjectsApi(_correctCC, mockDMClient.Object, mockDMRequestBuilder.Object, mockDMDataBuilder.Object, accountId);

            //Act
            var result = sut.GetProjects();

            //Assert
            result.Should().BeOfType<List<Project>>();
        }

        [Fact]
        public void GetProjects_2_WhenCalled_InvokesDMRequestBuilderUseGetProjectsExactlyOnce()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var request = RestSharpFixtures.GetRequest();
            var model = ProjectsFixtures.RightModelList();

            var mockDMDataBuilder = new Mock<DMDataBuilder>();
            var mockAuthenticator = new Mock<Authenticator>(_correctCC, Scope.Account_Read, null, null);
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.ExecutePaginated<List<Project>, Project>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockDMRequestBuilder = new Mock<DMRequestBuilder>();
            mockDMRequestBuilder
                .Setup(s => s.UseGetProjects(It.IsAny<string>()))
                .Returns(mockDMRequestBuilder.Object);

            mockDMRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new ProjectsApi(_correctCC, mockDMClient.Object, mockDMRequestBuilder.Object, mockDMDataBuilder.Object, accountId);

            //Act
            var result = sut.GetProjects();

            //Assert
            mockDMRequestBuilder.Verify(s => s.UseGetProjects(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public void GetProjects_3_WhenCalled_InvokesDMRequestBuilderBuildExactlyOnce()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var request = RestSharpFixtures.GetRequest();
            var model = ProjectsFixtures.RightModelList();

            var mockDMDataBuilder = new Mock<DMDataBuilder>();
            var mockAuthenticator = new Mock<Authenticator>(_correctCC, Scope.Account_Read, null, null);
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.ExecutePaginated<List<Project>, Project>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockDMRequestBuilder = new Mock<DMRequestBuilder>();
            mockDMRequestBuilder
                .Setup(s => s.UseGetProjects(It.IsAny<string>()))
                .Returns(mockDMRequestBuilder.Object);

            mockDMRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new ProjectsApi(_correctCC, mockDMClient.Object, mockDMRequestBuilder.Object, mockDMDataBuilder.Object, accountId);

            //Act
            var result = sut.GetProjects();

            //Assert
            mockDMRequestBuilder.Verify(s => s.Build(), Times.Once());
        }

        [Fact]
        public void GetProjects_4_WhenCalled_InvokesDMClientExecutePaginatedExactlyOnce()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var request = RestSharpFixtures.GetRequest();
            var model = ProjectsFixtures.RightModelList();

            var mockDMDataBuilder = new Mock<DMDataBuilder>();
            var mockAuthenticator = new Mock<Authenticator>(_correctCC, Scope.Account_Read, null, null);
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.ExecutePaginated<List<Project>, Project>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockDMRequestBuilder = new Mock<DMRequestBuilder>();
            mockDMRequestBuilder
                .Setup(s => s.UseGetProjects(It.IsAny<string>()))
                .Returns(mockDMRequestBuilder.Object);

            mockDMRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new ProjectsApi(_correctCC, mockDMClient.Object, mockDMRequestBuilder.Object, mockDMDataBuilder.Object, accountId);

            //Act
            var result = sut.GetProjects();

            //Assert
            mockDMClient.Verify(s => s.ExecutePaginated<List<Project>, Project>(It.IsAny<RestRequest>()), Times.Once());
        }

        [Fact]
        public void GetProjects_5_OnSuccess_ReturnsModelFromExecuted()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var request = RestSharpFixtures.GetRequest();
            var model = ProjectsFixtures.RightModelList();

            var mockDMDataBuilder = new Mock<DMDataBuilder>();
            var mockAuthenticator = new Mock<Authenticator>(_correctCC, Scope.Account_Read, null, null);
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.ExecutePaginated<List<Project>, Project>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockDMRequestBuilder = new Mock<DMRequestBuilder>();
            mockDMRequestBuilder
                .Setup(s => s.UseGetProjects(It.IsAny<string>()))
                .Returns(mockDMRequestBuilder.Object);

            mockDMRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new ProjectsApi(_correctCC, mockDMClient.Object, mockDMRequestBuilder.Object, mockDMDataBuilder.Object, accountId);

            //Act
            var result = sut.GetProjects();

            //Assert
            result.Should().BeSameAs(model);
        }

        [Fact]
        public void GetProjects_6_WhenCalled_InvokesExecutePaginatedWithBuiltRequest()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var request = RestSharpFixtures.GetRequest();
            var model = ProjectsFixtures.RightModelList();

            var mockDMDataBuilder = new Mock<DMDataBuilder>();
            var mockAuthenticator = new Mock<Authenticator>(_correctCC, Scope.Account_Read, null, null);
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.ExecutePaginated<List<Project>, Project>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockDMRequestBuilder = new Mock<DMRequestBuilder>();
            mockDMRequestBuilder
                .Setup(s => s.UseGetProjects(It.IsAny<string>()))
                .Returns(mockDMRequestBuilder.Object);

            mockDMRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new ProjectsApi(_correctCC, mockDMClient.Object, mockDMRequestBuilder.Object, mockDMDataBuilder.Object, accountId);

            //Act
            var result = sut.GetProjects();

            //Assert
            mockDMClient.Verify(s => s.ExecutePaginated<List<Project>, Project>(request), Times.Once());
        }

        #endregion

        #region GetProject

        [Fact]
        public void GetProject_1_OnSuccess_ReturnsModel()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var request = RestSharpFixtures.GetRequest();
            var model = ProjectsFixtures.RightModel();

            var mockAuthenticator = new Mock<Authenticator>(_correctCC, Scope.Account_Read, null, null);
            var mockDMDataBuilder = new Mock<DMDataBuilder>();
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.Execute<Project>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockDMRequestBuilder = new Mock<DMRequestBuilder>();
            mockDMRequestBuilder
                .Setup(s => s.UseGetProject(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockDMRequestBuilder.Object);

            mockDMRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new ProjectsApi(_correctCC, mockDMClient.Object, mockDMRequestBuilder.Object, mockDMDataBuilder.Object, accountId);

            //Act
            var result = sut.GetProject(It.IsAny<string>());

            //Assert
            result.Should().BeOfType<Project>();
        }

        [Fact]
        public void GetProject_2_WhenCalled_InvokesDMRequestBuilderUseGetProjectExactlyOnce()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var request = RestSharpFixtures.GetRequest();
            var model = ProjectsFixtures.RightModel();
            var id = ProjectsFixtures.RightId();

            var mockAuthenticator = new Mock<Authenticator>(_correctCC, Scope.Account_Read, null, null);
            var mockDMDataBuilder = new Mock<DMDataBuilder>();
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.Execute<Project>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockDMRequestBuilder = new Mock<DMRequestBuilder>();
            mockDMRequestBuilder
                .Setup(s => s.UseGetProject(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockDMRequestBuilder.Object);

            mockDMRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new ProjectsApi(_correctCC, mockDMClient.Object, mockDMRequestBuilder.Object, mockDMDataBuilder.Object, accountId);

            //Act
            var result = sut.GetProject(id);

            //Assert
            mockDMRequestBuilder.Verify(s => s.UseGetProject(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public void GetProject_3_WhenCalled_InvokesDMRequestBuilderBuildExactlyOnce()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var request = RestSharpFixtures.GetRequest();
            var model = ProjectsFixtures.RightModel();
            var id = ProjectsFixtures.RightId();

            var mockAuthenticator = new Mock<Authenticator>(_correctCC, Scope.Account_Read, null, null);
            var mockDMDataBuilder = new Mock<DMDataBuilder>();
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.Execute<Project>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockDMRequestBuilder = new Mock<DMRequestBuilder>();
            mockDMRequestBuilder
                .Setup(s => s.UseGetProject(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockDMRequestBuilder.Object);

            mockDMRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new ProjectsApi(_correctCC, mockDMClient.Object, mockDMRequestBuilder.Object, mockDMDataBuilder.Object, accountId);

            //Act
            var result = sut.GetProject(id);

            //Assert
            mockDMRequestBuilder.Verify(s => s.Build(), Times.Once());
        }

        [Fact]
        public void GetProject_4_WhenCalled_InvokesDMClientExecuteExactlyOnce()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var request = RestSharpFixtures.GetRequest();
            var model = ProjectsFixtures.RightModel();
            var id = ProjectsFixtures.RightId();

            var mockAuthenticator = new Mock<Authenticator>(_correctCC, Scope.Account_Read, null, null);
            var mockDMDataBuilder = new Mock<DMDataBuilder>();
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.Execute<Project>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockDMRequestBuilder = new Mock<DMRequestBuilder>();
            mockDMRequestBuilder
                .Setup(s => s.UseGetProject(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockDMRequestBuilder.Object);

            mockDMRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new ProjectsApi(_correctCC, mockDMClient.Object, mockDMRequestBuilder.Object, mockDMDataBuilder.Object, accountId);

            //Act
            var result = sut.GetProject(id);

            //Assert
            mockDMClient.Verify(s => s.Execute<Project>(It.IsAny<RestRequest>()), Times.Once());
        }

        [Fact]
        public void GetProject_5_OnSuccess_ReturnsModelFromExecuted()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var request = RestSharpFixtures.GetRequest();
            var model = ProjectsFixtures.RightModel();
            var id = ProjectsFixtures.RightId();

            var mockAuthenticator = new Mock<Authenticator>(_correctCC, Scope.Account_Read, null, null);
            var mockDMDataBuilder = new Mock<DMDataBuilder>();
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.Execute<Project>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockDMRequestBuilder = new Mock<DMRequestBuilder>();
            mockDMRequestBuilder
                .Setup(s => s.UseGetProject(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockDMRequestBuilder.Object);

            mockDMRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new ProjectsApi(_correctCC, mockDMClient.Object, mockDMRequestBuilder.Object, mockDMDataBuilder.Object, accountId);

            //Act
            var result = sut.GetProject(id);

            //Assert
            result.Should().BeSameAs(model);
        }

        [Fact]
        public void GetProject_6_WhenCalled_InvokesExecuteWithBuiltRequest()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var request = RestSharpFixtures.GetRequest();
            var model = ProjectsFixtures.RightModel();
            var id = ProjectsFixtures.RightId();

            var mockAuthenticator = new Mock<Authenticator>(_correctCC, Scope.Account_Read, null, null);
            var mockDMDataBuilder = new Mock<DMDataBuilder>();
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.Execute<Project>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockDMRequestBuilder = new Mock<DMRequestBuilder>();
            mockDMRequestBuilder
                .Setup(s => s.UseGetProject(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockDMRequestBuilder.Object);

            mockDMRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new ProjectsApi(_correctCC, mockDMClient.Object, mockDMRequestBuilder.Object, mockDMDataBuilder.Object, accountId);

            //Act
            var result = sut.GetProject(id);

            //Assert
            mockDMClient.Verify(s => s.Execute<Project>(request), Times.Once());
        }

        #endregion

        #region GetTopFolders

        [Fact]
        public void GetTopFolders_1_OnSuccess_ReturnsModel()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projId = ProjectsFixtures.RightId();
            var request = RestSharpFixtures.GetRequest();
            var model = ProjectsFixtures.RightFolderList();

            var mockAuthenticator = new Mock<Authenticator>(_correctCC, Scope.Account_Read, null, null);
            var mockDMDataBuilder = new Mock<DMDataBuilder>();
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.ExecuteDMApi<List<Folder>>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockDMRequestBuilder = new Mock<DMRequestBuilder>();
            mockDMRequestBuilder
                .Setup(s => s.UseGetTopFolders(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockDMRequestBuilder.Object);

            mockDMRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new ProjectsApi(_correctCC, mockDMClient.Object, mockDMRequestBuilder.Object, mockDMDataBuilder.Object, accountId);

            //Act
            var result = sut.GetTopFolders(accountId, projId);

            //Assert
            result.Should().BeOfType<List<Folder>>();
        }

        [Fact]
        public void GetTopFolders_2_WhenCalled_InvokesRequestBuilderUseGetTopFoldersExactlyOnce()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projId = ProjectsFixtures.RightId();
            var request = RestSharpFixtures.GetRequest();
            var model = ProjectsFixtures.RightFolderList();

            var mockAuthenticator = new Mock<Authenticator>(_correctCC, Scope.Account_Read, null, null);
            var mockDMDataBuilder = new Mock<DMDataBuilder>();
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.ExecuteDMApi<List<Folder>>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockDMRequestBuilder = new Mock<DMRequestBuilder>();
            mockDMRequestBuilder
                .Setup(s => s.UseGetTopFolders(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockDMRequestBuilder.Object);

            mockDMRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new ProjectsApi(_correctCC, mockDMClient.Object, mockDMRequestBuilder.Object, mockDMDataBuilder.Object, accountId);

            //Act
            var result = sut.GetTopFolders(accountId, projId);

            //Assert
            mockDMRequestBuilder.Verify(s => s.UseGetTopFolders(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public void GetTopFolders_3_WhenCalled_InvokesRequestBuilderBuildExactlyOnce()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projId = ProjectsFixtures.RightId();
            var request = RestSharpFixtures.GetRequest();
            var model = ProjectsFixtures.RightFolderList();

            var mockAuthenticator = new Mock<Authenticator>(_correctCC, Scope.Account_Read, null, null);
            var mockDMDataBuilder = new Mock<DMDataBuilder>();
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.ExecuteDMApi<List<Folder>>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockDMRequestBuilder = new Mock<DMRequestBuilder>();
            mockDMRequestBuilder
                .Setup(s => s.UseGetTopFolders(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockDMRequestBuilder.Object);

            mockDMRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new ProjectsApi(_correctCC, mockDMClient.Object, mockDMRequestBuilder.Object, mockDMDataBuilder.Object, accountId);

            //Act
            var result = sut.GetTopFolders(accountId, projId);

            //Assert
            mockDMRequestBuilder.Verify(s => s.Build(), Times.Once());
        }

        [Fact]
        public void GetTopFolders_4_WhenCalled_InvokesDmClientExecuteExactlyOnce()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projId = ProjectsFixtures.RightId();
            var request = RestSharpFixtures.GetRequest();
            var model = ProjectsFixtures.RightFolderList();

            var mockAuthenticator = new Mock<Authenticator>(_correctCC, Scope.Account_Read, null, null);
            var mockDMDataBuilder = new Mock<DMDataBuilder>();
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.ExecuteDMApi<List<Folder>>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockDMRequestBuilder = new Mock<DMRequestBuilder>();
            mockDMRequestBuilder
                .Setup(s => s.UseGetTopFolders(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockDMRequestBuilder.Object);

            mockDMRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new ProjectsApi(_correctCC, mockDMClient.Object, mockDMRequestBuilder.Object, mockDMDataBuilder.Object, accountId);

            //Act
            var result = sut.GetTopFolders(accountId, projId);

            //Assert
            mockDMClient.Verify(s => s.ExecuteDMApi<List<Folder>>(It.IsAny<RestRequest>()), Times.Once());
        }

        [Fact]
        public void GetTopFolders_5_WhenCalled_InvokesDmClientExecuteWithBuiltRequest()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projId = ProjectsFixtures.RightId();
            var request = RestSharpFixtures.GetRequest();
            var model = ProjectsFixtures.RightFolderList();

            var mockAuthenticator = new Mock<Authenticator>(_correctCC, Scope.Account_Read, null, null);
            var mockDMDataBuilder = new Mock<DMDataBuilder>();
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.ExecuteDMApi<List<Folder>>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockDMRequestBuilder = new Mock<DMRequestBuilder>();
            mockDMRequestBuilder
                .Setup(s => s.UseGetTopFolders(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockDMRequestBuilder.Object);

            mockDMRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new ProjectsApi(_correctCC, mockDMClient.Object, mockDMRequestBuilder.Object, mockDMDataBuilder.Object, accountId);

            //Act
            var result = sut.GetTopFolders(accountId, projId);

            //Assert
            mockDMClient.Verify(s => s.ExecuteDMApi<List<Folder>>(request), Times.Once());
        }

        [Fact]
        public void GetTopFolders_6_OnSuccess_ReturnsModelFromExecuted()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projId = ProjectsFixtures.RightId();
            var request = RestSharpFixtures.GetRequest();
            var model = ProjectsFixtures.RightFolderList();

            var mockAuthenticator = new Mock<Authenticator>(_correctCC, Scope.Account_Read, null, null);
            var mockDMDataBuilder = new Mock<DMDataBuilder>();
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.ExecuteDMApi<List<Folder>>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockDMRequestBuilder = new Mock<DMRequestBuilder>();
            mockDMRequestBuilder
                .Setup(s => s.UseGetTopFolders(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockDMRequestBuilder.Object);

            mockDMRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new ProjectsApi(_correctCC, mockDMClient.Object, mockDMRequestBuilder.Object, mockDMDataBuilder.Object, accountId);

            //Act
            var result = sut.GetTopFolders(accountId, projId);

            //Assert
            result.Should().BeSameAs(model);
        }

        [Fact]
        public void GetTopFolders_7_WhenCalled_InvokesRequestBuilderUseGetTopFoldersWithIdsProvided()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projId = ProjectsFixtures.RightId();
            var request = RestSharpFixtures.GetRequest();
            var model = ProjectsFixtures.RightFolderList();

            var mockAuthenticator = new Mock<Authenticator>(_correctCC, Scope.Account_Read, null, null);
            var mockDMDataBuilder = new Mock<DMDataBuilder>();
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.ExecuteDMApi<List<Folder>>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockDMRequestBuilder = new Mock<DMRequestBuilder>();
            mockDMRequestBuilder
                .Setup(s => s.UseGetTopFolders(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockDMRequestBuilder.Object);

            mockDMRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new ProjectsApi(_correctCC, mockDMClient.Object, mockDMRequestBuilder.Object, mockDMDataBuilder.Object, accountId);

            //Act
            var result = sut.GetTopFolders(accountId, projId);

            //Assert
            mockDMRequestBuilder.Verify(s => s.UseGetTopFolders(accountId, projId), Times.Once());
        }

        #endregion

        #region PostStorage


        [Fact]
        public void PostStorage_1_OnSuccess_ReturnsModel()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projId = ProjectsFixtures.RightId();
            var request = RestSharpFixtures.GetRequest();
            var model = ProjectsFixtures.RightStorageLocation();
            var fileName = ProjectsFixtures.RightFileName();
            var folderId = ProjectsFixtures.RightFolderId();
            var data = "\"data\": \"this is some data\"";

            var mockAuthenticator = new Mock<Authenticator>(_correctCC, Scope.Account_Read, null, null);
            var mockDMDataBuilder = new Mock<DMDataBuilder>();
            mockDMDataBuilder
                .Setup(s => s.UseStorageLocation(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockDMDataBuilder.Object);

            mockDMDataBuilder
                .Setup(s => s.Build())
                .Returns(data);

            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.ExecuteDMApi<StorageLocation>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockDMRequestBuilder = new Mock<DMRequestBuilder>();
            mockDMRequestBuilder
                .Setup(s => s.UsePostStorageLocation(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockDMRequestBuilder.Object);

            mockDMRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new ProjectsApi(_correctCC, mockDMClient.Object, mockDMRequestBuilder.Object, mockDMDataBuilder.Object, accountId);

            //Act
            var result = sut.PostStorage(projId, fileName, folderId);

            //Assert
            result.Should().BeOfType<StorageLocation>();
        }

        [Fact]
        public void PostStorage_2_WhenCalled_InvokesDataBuilderUseStorageLocationExactlyOnce()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projId = ProjectsFixtures.RightId();
            var request = RestSharpFixtures.GetRequest();
            var model = ProjectsFixtures.RightStorageLocation();
            var fileName = ProjectsFixtures.RightFileName();
            var folderId = ProjectsFixtures.RightFolderId();
            var data = "\"data\": \"this is some data\"";

            var mockAuthenticator = new Mock<Authenticator>(_correctCC, Scope.Account_Read, null, null);
            var mockDMDataBuilder = new Mock<DMDataBuilder>();
            mockDMDataBuilder
                .Setup(s => s.UseStorageLocation(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockDMDataBuilder.Object);

            mockDMDataBuilder
                .Setup(s => s.Build())
                .Returns(data);

            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.ExecuteDMApi<StorageLocation>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockDMRequestBuilder = new Mock<DMRequestBuilder>();
            mockDMRequestBuilder
                .Setup(s => s.UsePostStorageLocation(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockDMRequestBuilder.Object);

            mockDMRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new ProjectsApi(_correctCC, mockDMClient.Object, mockDMRequestBuilder.Object, mockDMDataBuilder.Object, accountId);

            //Act
            var result = sut.PostStorage(projId, fileName, folderId);

            //Assert
            mockDMDataBuilder.Verify(s => s.UseStorageLocation(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public void PostStorage_3_WhenCalled_InvokesDataBuilderBuildExactlyOnce()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projId = ProjectsFixtures.RightId();
            var request = RestSharpFixtures.GetRequest();
            var model = ProjectsFixtures.RightStorageLocation();
            var fileName = ProjectsFixtures.RightFileName();
            var folderId = ProjectsFixtures.RightFolderId();
            var data = "\"data\": \"this is some data\"";

            var mockAuthenticator = new Mock<Authenticator>(_correctCC, Scope.Account_Read, null, null);
            var mockDMDataBuilder = new Mock<DMDataBuilder>();
            mockDMDataBuilder
                .Setup(s => s.UseStorageLocation(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockDMDataBuilder.Object);

            mockDMDataBuilder
                .Setup(s => s.Build())
                .Returns(data);

            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.ExecuteDMApi<StorageLocation>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockDMRequestBuilder = new Mock<DMRequestBuilder>();
            mockDMRequestBuilder
                .Setup(s => s.UsePostStorageLocation(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockDMRequestBuilder.Object);

            mockDMRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new ProjectsApi(_correctCC, mockDMClient.Object, mockDMRequestBuilder.Object, mockDMDataBuilder.Object, accountId);

            //Act
            var result = sut.PostStorage(projId, fileName, folderId);

            //Assert
            mockDMDataBuilder.Verify(s => s.Build(), Times.Once());
        }

        [Fact]
        public void PostStorage_4_WhenCalled_InvokesRequestBuilderUsePostStorageLocationExactlyOnce()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projId = ProjectsFixtures.RightId();
            var request = RestSharpFixtures.PostRequest();
            var model = ProjectsFixtures.RightStorageLocation();
            var fileName = ProjectsFixtures.RightFileName();
            var folderId = ProjectsFixtures.RightFolderId();
            var data = "\"data\": \"this is some data\"";

            var mockAuthenticator = new Mock<Authenticator>(_correctCC, Scope.Account_Read, null, null);
            var mockDMDataBuilder = new Mock<DMDataBuilder>();
            mockDMDataBuilder
                .Setup(s => s.UseStorageLocation(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockDMDataBuilder.Object);

            mockDMDataBuilder
                .Setup(s => s.Build())
                .Returns(data);

            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.ExecuteDMApi<StorageLocation>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockDMRequestBuilder = new Mock<DMRequestBuilder>();
            mockDMRequestBuilder
                .Setup(s => s.UsePostStorageLocation(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockDMRequestBuilder.Object);

            mockDMRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new ProjectsApi(_correctCC, mockDMClient.Object, mockDMRequestBuilder.Object, mockDMDataBuilder.Object, accountId);

            //Act
            var result = sut.PostStorage(projId, fileName, folderId);

            //Assert
            mockDMRequestBuilder.Verify(s => s.UsePostStorageLocation(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public void PostStorage_5_WhenCalled_InvokesRequestBuilderBuildExactlyOnce()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projId = ProjectsFixtures.RightId();
            var request = RestSharpFixtures.PostRequest();
            var model = ProjectsFixtures.RightStorageLocation();
            var fileName = ProjectsFixtures.RightFileName();
            var folderId = ProjectsFixtures.RightFolderId();
            var data = "\"data\": \"this is some data\"";

            var mockAuthenticator = new Mock<Authenticator>(_correctCC, Scope.Account_Read, null, null);
            var mockDMDataBuilder = new Mock<DMDataBuilder>();
            mockDMDataBuilder
                .Setup(s => s.UseStorageLocation(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockDMDataBuilder.Object);

            mockDMDataBuilder
                .Setup(s => s.Build())
                .Returns(data);

            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.ExecuteDMApi<StorageLocation>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockDMRequestBuilder = new Mock<DMRequestBuilder>();
            mockDMRequestBuilder
                .Setup(s => s.UsePostStorageLocation(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockDMRequestBuilder.Object);

            mockDMRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new ProjectsApi(_correctCC, mockDMClient.Object, mockDMRequestBuilder.Object, mockDMDataBuilder.Object, accountId);

            //Act
            var result = sut.PostStorage(projId, fileName, folderId);

            //Assert
            mockDMRequestBuilder.Verify(s => s.Build(), Times.Once());
        }

        [Fact]
        public void PostStorage_6_WhenCalled_InvokesDMClientExecuteExactlyOnce()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projId = ProjectsFixtures.RightId();
            var request = RestSharpFixtures.PostRequest();
            var model = ProjectsFixtures.RightStorageLocation();
            var fileName = ProjectsFixtures.RightFileName();
            var folderId = ProjectsFixtures.RightFolderId();
            var data = "\"data\": \"this is some data\"";

            var mockAuthenticator = new Mock<Authenticator>(_correctCC, Scope.Account_Read, null, null);
            var mockDMDataBuilder = new Mock<DMDataBuilder>();
            mockDMDataBuilder
                .Setup(s => s.UseStorageLocation(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockDMDataBuilder.Object);

            mockDMDataBuilder
                .Setup(s => s.Build())
                .Returns(data);

            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.ExecuteDMApi<StorageLocation>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockDMRequestBuilder = new Mock<DMRequestBuilder>();
            mockDMRequestBuilder
                .Setup(s => s.UsePostStorageLocation(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockDMRequestBuilder.Object);

            mockDMRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new ProjectsApi(_correctCC, mockDMClient.Object, mockDMRequestBuilder.Object, mockDMDataBuilder.Object, accountId);

            //Act
            var result = sut.PostStorage(projId, fileName, folderId);

            //Assert
            mockDMClient.Verify(s => s.ExecuteDMApi<StorageLocation>(It.IsAny<RestRequest>()), Times.Once());
        }

        [Fact]
        public void PostStorage_7_WhenCalled_InvokesDataBuilderUseStorageLocationWithProvidedFileNamenAndParentId()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projId = ProjectsFixtures.RightId();
            var request = RestSharpFixtures.GetRequest();
            var model = ProjectsFixtures.RightStorageLocation();
            var fileName = ProjectsFixtures.RightFileName();
            var folderId = ProjectsFixtures.RightFolderId();
            var data = "\"data\": \"this is some data\"";

            var mockAuthenticator = new Mock<Authenticator>(_correctCC, Scope.Account_Read, null, null);
            var mockDMDataBuilder = new Mock<DMDataBuilder>();
            mockDMDataBuilder
                .Setup(s => s.UseStorageLocation(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockDMDataBuilder.Object);

            mockDMDataBuilder
                .Setup(s => s.Build())
                .Returns(data);

            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.ExecuteDMApi<StorageLocation>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockDMRequestBuilder = new Mock<DMRequestBuilder>();
            mockDMRequestBuilder
                .Setup(s => s.UsePostStorageLocation(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockDMRequestBuilder.Object);

            mockDMRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new ProjectsApi(_correctCC, mockDMClient.Object, mockDMRequestBuilder.Object, mockDMDataBuilder.Object, accountId);

            //Act
            var result = sut.PostStorage(projId, fileName, folderId);

            //Assert
            mockDMDataBuilder.Verify(s => s.UseStorageLocation(fileName, folderId), Times.Once());
        }

        [Fact]
        public void PostStorage_8_WhenCalled_InvokesRequestBuilderUsePostStorageLocationWithProjIdAndDataProvided()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projId = ProjectsFixtures.RightId();
            var request = RestSharpFixtures.PostRequest();
            var model = ProjectsFixtures.RightStorageLocation();
            var fileName = ProjectsFixtures.RightFileName();
            var folderId = ProjectsFixtures.RightFolderId();
            var data = "\"data\": \"this is some data\"";

            var mockAuthenticator = new Mock<Authenticator>(_correctCC, Scope.Account_Read, null, null);
            var mockDMDataBuilder = new Mock<DMDataBuilder>();
            mockDMDataBuilder
                .Setup(s => s.UseStorageLocation(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockDMDataBuilder.Object);

            mockDMDataBuilder
                .Setup(s => s.Build())
                .Returns(data);

            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.ExecuteDMApi<StorageLocation>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockDMRequestBuilder = new Mock<DMRequestBuilder>();
            mockDMRequestBuilder
                .Setup(s => s.UsePostStorageLocation(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockDMRequestBuilder.Object);

            mockDMRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new ProjectsApi(_correctCC, mockDMClient.Object, mockDMRequestBuilder.Object, mockDMDataBuilder.Object, accountId);

            //Act
            var result = sut.PostStorage(projId, fileName, folderId);

            //Assert
            mockDMRequestBuilder.Verify(s => s.UsePostStorageLocation(projId, data), Times.Once());
        }

        [Fact]
        public void PostStorage_9_WhenCalled_InvokesDMClientExecuteWithRequestBuilt()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var projId = ProjectsFixtures.RightId();
            var request = RestSharpFixtures.PostRequest();
            var model = ProjectsFixtures.RightStorageLocation();
            var fileName = ProjectsFixtures.RightFileName();
            var folderId = ProjectsFixtures.RightFolderId();
            var data = "\"data\": \"this is some data\"";

            var mockAuthenticator = new Mock<Authenticator>(_correctCC, Scope.Account_Read, null, null);
            var mockDMDataBuilder = new Mock<DMDataBuilder>();
            mockDMDataBuilder
                .Setup(s => s.UseStorageLocation(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockDMDataBuilder.Object);

            mockDMDataBuilder
                .Setup(s => s.Build())
                .Returns(data);

            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.ExecuteDMApi<StorageLocation>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockDMRequestBuilder = new Mock<DMRequestBuilder>();
            mockDMRequestBuilder
                .Setup(s => s.UsePostStorageLocation(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockDMRequestBuilder.Object);

            mockDMRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new ProjectsApi(_correctCC, mockDMClient.Object, mockDMRequestBuilder.Object, mockDMDataBuilder.Object, accountId);

            //Act
            var result = sut.PostStorage(projId, fileName, folderId);

            //Assert
            mockDMClient.Verify(s => s.ExecuteDMApi<StorageLocation>(request), Times.Once());
        }

        #endregion
    }
}
