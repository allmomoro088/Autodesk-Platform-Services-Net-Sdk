using APSAPITest.ACC.Fixtures;
using APSAPITest.DM.Fixtures;
using Autodesk.PlatformServices.ACC;
using Autodesk.PlatformServices.Auth;
using FluentAssertions;
using Moq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APSAPITest.ACC.Systems
{
    public class IssuesApiTests
    {
        #region GetIssues


        [Fact]
        public void GetIssues_0_HasProjectIdParameter()
        {
            var t = typeof(IssuesApi);
            var mInfo = t.GetMethod("GetIssues");
            var parameters = mInfo.GetParameters();
            parameters.Should().NotBeNull();
            parameters.Should().HaveCount(1);
            parameters.Should().Contain(x => x.Name == "projectId" && x.ParameterType == typeof(string));
        }

        [Fact]
        public void GetIssues_1_OnSuccess_ReturnsModel()
        {
            //Arrange
            var projectId = ProjectsFixtures.RightId();
            var request = RestSharpFixtures.GetRequest();
            var pagination = IssuesFixtures.RightIssuesPagination();

            var mockACCClient = new Mock<ACCClient>(It.IsAny<Authenticator>());
            mockACCClient
                .Setup(s => s.Execute<IssuesPagination>(It.IsAny<RestRequest>()))
                .Returns(pagination);

            var mockRequestBuilder = new Mock<ACCRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetIssues(It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);
            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new IssuesApi(mockACCClient.Object, mockRequestBuilder.Object);

            //Act
            var result = sut.GetIssues(projectId);

            //Assert
            result.Should().BeOfType<List<Issue>>();
        }

        [Fact]
        public void GetIssues_2_WhenCalled_InvokesRequestBuilderUseGetIssuesWithDataExactlyOnce()
        {
            //Arrange
            var projectId = ProjectsFixtures.RightId();
            var request = RestSharpFixtures.GetRequest();
            var pagination = IssuesFixtures.RightIssuesPagination();

            var mockACCClient = new Mock<ACCClient>(It.IsAny<Authenticator>());
            mockACCClient
                .Setup(s => s.Execute<IssuesPagination>(It.IsAny<RestRequest>()))
                .Returns(pagination);

            var mockRequestBuilder = new Mock<ACCRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetIssues(It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);
            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new IssuesApi(mockACCClient.Object, mockRequestBuilder.Object);

            //Act
            var result = sut.GetIssues(projectId);

            //Assert
            mockRequestBuilder.Verify(s => s.UseGetIssues(It.IsAny<string>()), Times.Once());
            mockRequestBuilder.Verify(s => s.UseGetIssues(projectId), Times.Once());
        }

        [Fact]
        public void GetIssues_3_WhenCalled_InvokesRequestBuilderUseGetIssuesThenBuildWithDataExactlyOnce()
        {
            //Arrange
            var projectId = ProjectsFixtures.RightId();
            var request = RestSharpFixtures.GetRequest();
            var pagination = IssuesFixtures.RightIssuesPagination();

            var mockACCClient = new Mock<ACCClient>(It.IsAny<Authenticator>());
            mockACCClient
                .Setup(s => s.Execute<IssuesPagination>(It.IsAny<RestRequest>()))
                .Returns(pagination);

            var mockRequestBuilder = new Mock<ACCRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetIssues(It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);
            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new IssuesApi(mockACCClient.Object, mockRequestBuilder.Object);

            //Act
            var result = sut.GetIssues(projectId);

            //Assert
            mockRequestBuilder.Verify(s => s.UseGetIssues(It.IsAny<string>()), Times.Once());
            mockRequestBuilder.Verify(s => s.Build(), Times.Once());
        }

        [Fact]
        public void GetIssues_4_WhenCalled_InvokesClientExecuteWithBuiltRequestExactlyOnce()
        {
            //Arrange
            var projectId = ProjectsFixtures.RightId();
            var request = RestSharpFixtures.GetRequest();
            var pagination = IssuesFixtures.RightIssuesPagination();

            var mockACCClient = new Mock<ACCClient>(It.IsAny<Authenticator>());
            mockACCClient
                .Setup(s => s.Execute<IssuesPagination>(It.IsAny<RestRequest>()))
                .Returns(pagination);

            var mockRequestBuilder = new Mock<ACCRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetIssues(It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);
            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new IssuesApi(mockACCClient.Object, mockRequestBuilder.Object);

            //Act
            var result = sut.GetIssues(projectId);

            //Assert
            mockACCClient.Verify(s => s.Execute<IssuesPagination>(It.IsAny<RestRequest>()), Times.Once());
        }

        [Fact]
        public void GetIssues_5_OnSuccess_ReturnsModelGetFromExecute()
        {
            //Arrange
            var projectId = ProjectsFixtures.RightId();
            var request = RestSharpFixtures.GetRequest();
            var pagination = IssuesFixtures.RightIssuesPagination();

            var mockACCClient = new Mock<ACCClient>(It.IsAny<Authenticator>());
            mockACCClient
                .Setup(s => s.Execute<IssuesPagination>(It.IsAny<RestRequest>()))
                .Returns(pagination);

            var mockRequestBuilder = new Mock<ACCRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetIssues(It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);
            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var sut = new IssuesApi(mockACCClient.Object, mockRequestBuilder.Object);

            //Act
            var result = sut.GetIssues(projectId);

            //Assert
            result.Should().BeSameAs(pagination.Results);
        }
        #endregion
    }
}
