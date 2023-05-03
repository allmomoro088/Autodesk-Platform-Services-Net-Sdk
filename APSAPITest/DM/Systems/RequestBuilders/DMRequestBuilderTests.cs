using APSAPITest.DM.Fixtures;
using Autodesk.PlatformServices.DM;
using FluentAssertions;
using Moq;
using Moq.Protected;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace APSAPITest.DM.Systems.RequestBuilders
{
    public class DMRequestBuilderTests
    {
        #region UseGetHubs

        [Fact]
        public void UseGetHubs_1_ReturnsBuilder()
        {
            //Arrange
            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UseGetHubs();

            //Assert
            result.Should().BeOfType<DMRequestBuilder>();
        }

        [Fact]
        public void UseGetHubs_2_WhenCalled_SetsResource()
        {
            //Arrange
            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UseGetHubs();

            //Assert
            sut.Resource.Should().Be("project/v1/hubs");
        }

        [Fact]
        public void UseGetHubs_3_WhenCalled_SetsMethod()
        {
            //Arrange
            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UseGetHubs();

            //Assert
            sut.Method.Should().Be(Method.Get);
        }

        #endregion

        #region UseGetHub

        [Fact]
        public void UseGetHub_1_ReturnsBuilder()
        {
            //Arrange
            var id = HubsFixtures.RightId();
            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UseGetHub(id);

            //Assert
            result.Should().BeOfType<DMRequestBuilder>();
        }

        [Fact]
        public void UseGetHub_2_WhenCalled_SetsResource()
        {
            //Arrange
            var id = HubsFixtures.RightId();
            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UseGetHub(id);

            //Assert
            sut.Resource.Should().Be($"project/v1/hubs/b.{id}");
        }

        [Fact]
        public void UseGetHub_3_WhenCalled_SetsMethod()
        {
            //Arrange
            var id = HubsFixtures.RightId();
            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UseGetHub(id);

            //Assert
            sut.Method.Should().Be(Method.Get);
        }

        #endregion

        #region UseGetProjects

        [Fact]
        public void UseGetProjects_1_ReturnsBuilder()
        {
            //Arrange
            var accountid = HubsFixtures.RightId();

            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UseGetProjects(accountid);

            //Assert
            result.Should().BeOfType<DMRequestBuilder>();
        }

        [Fact]
        public void UseGetProjects_2_WhenCalled_SetsResource()
        {
            //Arrange
            var accountid = HubsFixtures.RightId();

            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UseGetProjects(accountid);

            //Assert
            sut.Resource.Should().Be($"project/v1/hubs/b.{accountid}/projects");
        }

        [Fact]
        public void UseGetProjects_3_WhenCalled_SetsMethod()
        {
            //Arrange
            var accountid = HubsFixtures.RightId();

            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UseGetProjects(accountid);

            //Assert
            sut.Method.Should().Be(Method.Get);
        }

        #endregion

        #region UseGetProject

        [Fact]
        public void UseGetProject_1_ReturnsBuilder()
        {
            //Arrange
            var accountid = HubsFixtures.RightId();
            var id = ProjectsFixtures.RightId();

            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UseGetProject(accountid, id);

            //Assert
            result.Should().BeOfType<DMRequestBuilder>();
        }

        [Fact]
        public void UseGetProject_2_WhenCalled_SetsResource()
        {
            //Arrange
            var accountid = HubsFixtures.RightId();
            var id = ProjectsFixtures.RightId();

            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UseGetProject(accountid, id);

            //Assert
            sut.Resource.Should().Be($"project/v1/hubs/b.{accountid}/projects/b.{id}");
        }

        [Fact]
        public void UseGetProject_3_WhenCalled_SetsMethod()
        {
            //Arrange
            var accountid = HubsFixtures.RightId();
            var id = ProjectsFixtures.RightId();

            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UseGetProject(accountid, id);

            //Assert
            sut.Method.Should().Be(Method.Get);
        }

        #endregion

        #region GetTopFolders

        [Fact]
        public void GetTopFolders_1_OnSuccess_ReturnsRequestBuilder()
        {
            //Arrange
            var projId = ProjectsFixtures.RightId();
            var accountId = HubsFixtures.RightId();

            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UseGetTopFolders(accountId, projId);

            //Assert
            result.Should().BeOfType<DMRequestBuilder>();
        }

        [Fact]
        public void GetTopFolders_2_WhenCalled_SetsResource()
        {
            //Arrange
            var projId = ProjectsFixtures.RightId();
            var accountId = HubsFixtures.RightId();

            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UseGetTopFolders(accountId, projId);

            //Assert
            result.Resource.Should().Be($"project/v1/hubs/b.{accountId}/projects/b.{projId}/topFolders");
        }

        [Fact]
        public void GetTopFolders_3_WhenCalled_SetsMethod()
        {
            //Arrange
            var projId = ProjectsFixtures.RightId();
            var accountId = HubsFixtures.RightId();

            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UseGetTopFolders(accountId, projId);

            //Assert
            result.Method.Should().Be(Method.Get);
        }

        #endregion

        #region UsePostStorageLocation


        [Fact]
        public void UsePostStorageLocation_1_OnSuccess_RequestBuilder()
        {
            //Arrange
            var projectId = ProjectsFixtures.RightId();
            var data = "\"data\": \"this is some data\"";

            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UsePostStorageLocation(projectId, data);

            //Assert
            result.Should().BeOfType<DMRequestBuilder>();
        }

        [Fact]
        public void UsePostStorageLocation_2_WhenCalled_SetsResource()
        {
            //Arrange
            var projectId = ProjectsFixtures.RightId();
            var data = "\"data\": \"this is some data\"";

            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UsePostStorageLocation(projectId, data);

            //Assert
            result.Resource.Should().Be($"data/v1/projects/b.{projectId}/storage");
        }

        [Fact]
        public void UsePostStorageLocation_3_WhenCalled_SetsMethod()
        {
            //Arrange
            var projectId = ProjectsFixtures.RightId();
            var data = "\"data\": \"this is some data\"";

            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UsePostStorageLocation(projectId, data);

            //Assert
            result.Method.Should().Be(Method.Post);
        }

        [Fact]
        public void UsePostStorageLocation_4_WhenCalled_AddsContentTypeHeader()
        {
            //Arrange
            var projectId = ProjectsFixtures.RightId();
            var data = "\"data\": \"this is some data\"";

            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UsePostStorageLocation(projectId, data);

            //Assert
            result.Headers.Should().Contain(x => x.Key == "content-type");
        }

        [Fact]
        public void UsePostStorageLocation_5_WhenCalled_AddsData()
        {
            //Arrange
            var projectId = ProjectsFixtures.RightId();
            var data = "\"data\": \"this is some data\"";

            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UsePostStorageLocation(projectId, data);

            //Assert
            result.Parameters.Should().Contain(x => x.Item1 == "application/json" && x.Item2 == data && x.Item3 == ParameterType.RequestBody);
        }

        #endregion

        #region UseGetFolder

        [Fact]
        public void UseGetFolder_1_OnSuccess_ReturnsRequestBuilder()
        {
            //Arrange
            var projectId = ProjectsFixtures.RightId();
            var folderId = ProjectsFixtures.RightFolderId();
            
            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UseGetFolder(projectId, folderId);

            //Assert
            result.Should().BeOfType<DMRequestBuilder>();
        }

        [Fact]
        public void UseGetFolder_2_WhenCalled_SetsResource()
        {
            //Arrange
            var projectId = ProjectsFixtures.RightId();
            var folderId = ProjectsFixtures.RightFolderId();

            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UseGetFolder(projectId, folderId);

            //Assert
            result.Resource.Should().Be($"data/v1/projects/b.{projectId}/folders/{folderId}");
        }

        [Fact]
        public void UseGetFolder_3_WhenCalled_SetsMethods()
        {
            //Arrange
            var projectId = ProjectsFixtures.RightId();
            var folderId = ProjectsFixtures.RightFolderId();

            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UseGetFolder(projectId, folderId);

            //Assert
            result.Method.Should().Be(Method.Get);
        }

        #endregion

        #region UseGetContents

        [Fact]
        public void UseGetContents_1_OnSuccess_ReturnsRequestBuilder()
        {
            //Arrange
            var projectId = ProjectsFixtures.RightId();
            var folderId = ProjectsFixtures.RightFolderId();

            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UseGetContents(projectId, folderId);

            //Assert
            result.Should().BeOfType<DMRequestBuilder>();
        }

        [Fact]
        public void UseGetContents_2_WhenCalled_SetsResource()
        {
            //Arrange
            var projectId = ProjectsFixtures.RightId();
            var folderId = ProjectsFixtures.RightFolderId();

            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UseGetContents(projectId, folderId);

            //Assert
            result.Resource.Should().Be($"data/v1/projects/b.{projectId}/folders/{folderId}/contents");
        }

        [Fact]
        public void UseGetContents_3_WhenCalled_SetsMethods()
        {
            //Arrange
            var projectId = ProjectsFixtures.RightId();
            var folderId = ProjectsFixtures.RightFolderId();

            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UseGetFolder(projectId, folderId);

            //Assert
            result.Method.Should().Be(Method.Get);
        }

        #endregion

        #region UsePostFolder

        [Fact]
        public void UsePostFolder_1_OnSuccess_RequestBuilder()
        {
            //Arrange
            var projectId = ProjectsFixtures.RightId();
            var data = "\"data\": \"this is some data\"";

            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UsePostFolder(projectId, data);

            //Assert
            result.Should().BeOfType<DMRequestBuilder>();
        }

        [Fact]
        public void UsePostFolder_2_WhenCalled_SetsResource()
        {
            //Arrange
            var projectId = ProjectsFixtures.RightId();
            var data = "\"data\": \"this is some data\"";

            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UsePostFolder(projectId, data);

            //Assert
            result.Resource.Should().Be($"data/v1/projects/b.{projectId}/folders");
        }

        [Fact]
        public void UsePostFolder_3_WhenCalled_SetsMethod()
        {
            //Arrange
            var projectId = ProjectsFixtures.RightId();
            var data = "\"data\": \"this is some data\"";

            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UsePostFolder(projectId, data);

            //Assert
            result.Method.Should().Be(Method.Post);
        }

        [Fact]
        public void UsePostFolder_4_WhenCalled_AddsContentTypeHeader()
        {
            //Arrange
            var projectId = ProjectsFixtures.RightId();
            var data = "\"data\": \"this is some data\"";

            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UsePostFolder(projectId, data);

            //Assert
            result.Headers.Should().Contain(x => x.Key == "content-type");
        }

        [Fact]
        public void UsePostFolder_5_WhenCalled_AddsData()
        {
            //Arrange
            var projectId = ProjectsFixtures.RightId();
            var data = "\"data\": \"this is some data\"";

            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UsePostFolder(projectId, data);

            //Assert
            result.Parameters.Should().Contain(x => x.Item1 == "application/json" && x.Item2 == data && x.Item3 == ParameterType.RequestBody);
        }

        #endregion

        #region UseGetItem

        [Fact]
        public void UseGetItem_1_OnSuccess_ReturnsRequestBuilder()
        {
            //Arrange
            var itemId = ItemsFixtures.RightItemId();
            var projId = ProjectsFixtures.RightId();

            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UseGetItem(projId, itemId);

            //Assert
            result.Should().BeOfType<DMRequestBuilder>();
        }

        [Fact]
        public void UseGetItem_2_WhenCalled_SetsResource()
        {
            //Arrange
            var itemId = ItemsFixtures.RightItemId();
            var projId = ProjectsFixtures.RightId();

            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UseGetItem(projId, itemId);

            //Assert
            result.Resource.Should().Be($"data/v1/projects/b.{projId}/items/{itemId}");
        }

        [Fact]
        public void UseGetItem_3_WhenCalled_SetsMethod()
        {
            //Arrange
            var itemId = ItemsFixtures.RightItemId();
            var projId = ProjectsFixtures.RightId();

            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UseGetItem(projId, itemId);

            //Assert
            result.Method.Should().Be(Method.Get);
        }

        #endregion

        #region UseGetItemTip

        [Fact]
        public void UseGetItemTip_1_OnSuccess_ReturnsRequestBuilder()
        {
            //Arrange
            var itemId = ItemsFixtures.RightItemId();
            var projId = ProjectsFixtures.RightId();

            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UseGetItemTip(projId, itemId);

            //Assert
            result.Should().BeOfType<DMRequestBuilder>();
        }

        [Fact]
        public void UseGetItemTip_2_WhenCalled_SetsResource()
        {
            //Arrange
            var itemId = ItemsFixtures.RightItemId();
            var projId = ProjectsFixtures.RightId();

            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UseGetItemTip(projId, itemId);

            //Assert
            result.Resource.Should().Be($"data/v1/projects/b.{projId}/items/{itemId}/tip");
        }

        [Fact]
        public void UseGetItemTip_3_WhenCalled_SetsMethod()
        {
            //Arrange
            var itemId = ItemsFixtures.RightItemId();
            var projId = ProjectsFixtures.RightId();

            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UseGetItemTip(projId, itemId);

            //Assert
            result.Method.Should().Be(Method.Get);
        }

        #endregion

        #region UsePostItem

        [Fact]
        public void UsePostItem_1_OnSuccess_ReturnsRequestBuilder()
        {
            //Arrange
            var projId = ProjectsFixtures.RightId();
            var data = "\"data\": \"this is some data\"";

            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UsePostItem(projId, data);

            //Assert
            result.Should().BeOfType<DMRequestBuilder>();
        }

        [Fact]
        public void UsePostItem_2_WhenCalled_SetsResource()
        {
            //Arrange
            var projId = ProjectsFixtures.RightId();
            var data = "\"data\": \"this is some data\"";

            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UsePostItem(projId, data);

            //Assert
            result.Resource.Should().Be($"data/v1/projects/b.{projId}/items");
        }

        [Fact]
        public void UsePostItem_3_WhenCalled_SetsMethod()
        {
            //Arrange
            var projId = ProjectsFixtures.RightId();
            var data = "\"data\": \"this is some data\"";

            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UsePostItem(projId, data);

            //Assert
            result.Method.Should().Be(Method.Post);
        }

        [Fact]
        public void UsePostItem_4_WhenCalled_AddsContentTypeHeader()
        {
            //Arrange
            var projId = ProjectsFixtures.RightId();
            var data = "\"data\": \"this is some data\"";

            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UsePostItem(projId, data);

            //Assert
            result.Headers.Should().Contain(x => x.Key == "content-type" && x.Value == "application/json");
        }

        [Fact]
        public void UsePostItem_5_WhenCalled_AddsData()
        {
            //Arrange
            var projId = ProjectsFixtures.RightId();
            var data = "\"data\": \"this is some data\"";

            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UsePostItem(projId, data);

            //Assert
            result.Parameters.Should().Contain(x => x.Item1 == "application/json" && x.Item2 == data && x.Item3 == ParameterType.RequestBody);
        }

        #endregion

        #region UsePostBucket

        [Fact]
        public void UsePostBucket_1_OnSuccess_ReturnsRequestBuilder()
        {
            //Arrange
            var data = "data";

            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UsePostBucket(data);

            //Assert
            result.Should().BeOfType<DMRequestBuilder>();
            result.Should().Be(sut);
        }

        [Fact]
        public void UsePostBucket_2_WhenCalled_SetsResource()
        {
            //Arrange
            var data = "data";

            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UsePostBucket(data);

            //Assert
            result.Resource.Should().Be("oss/v2/buckets");
        }

        [Fact]
        public void UsePostBucket_3_WhenCalled_SetsMethod()
        {
            //Arrange
            var data = "data";

            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UsePostBucket(data);

            //Assert
            result.Method.Should().Be(Method.Post);
        }

        [Fact]
        public void UsePostBucket_4_WhenCalled_AddsContentTypeHeader()
        {
            //Arrange
            var data = "data";

            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UsePostBucket(data);

            //Assert
            result.Headers.Should().Contain(x => x.Key == "content-type", "application/json");
        }

        [Fact]
        public void UsePostBucket_5_WhenCalled_AddsDataParameter()
        {
            //Arrange
            var data = "data";

            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UsePostBucket(data);

            //Assert
            result.Parameters.Should().Contain(x => x.Item1 == "application/json" && x.Item2.ToString() == data && x.Item3 == ParameterType.RequestBody);
        }

        [Fact]
        public void UsePostBucket_6_WhenCalled_AddsRegionHeader()
        {
            //Arrange
            var data = "data";

            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UsePostBucket(data);

            //Assert
            result.Headers.Should().Contain(x => x.Key == "x-ads-region" && x.Value == "US");
        }

        #endregion

        #region UseGetBuckets

        [Fact]
        public void UseGetBuckets_1_OnSuccess_ReturnsRequestBuilder()
        {
            //Arrange
            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UseGetBuckets();

            //Assert
            result.Should().BeOfType<DMRequestBuilder>();
            result.Should().Be(sut);
        }

        [Fact]
        public void UseGetBuckets_2_WhenCalled_SetsResource()
        {
            //Arrange
            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UseGetBuckets();

            //Assert
            result.Resource.Should().Be("oss/v2/buckets");
        }

        [Fact]
        public void UseGetBuckets_3_WhenCalled_SetsMethod()
        {
            //Arrange
            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UseGetBuckets();

            //Assert
            result.Method.Should().Be(Method.Get);
        }

        #endregion

        #region UseDeleteBucket

        [Fact]
        public void UseDeleteBucket_1_OnSuccess_ReturnsRequestBuilder()
        {
            //Arrange
            var bucketKey = BucketsFixtures.RightBucketKey();

            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UseDeleteBucket(bucketKey);

            //Assert
            result.Should().BeOfType<DMRequestBuilder>();
            result.Should().Be(sut);
        }

        [Fact]
        public void UseDeleteBucket_2_WhenCalled_SetsResource()
        {
            //Arrange
            var bucketKey = BucketsFixtures.RightBucketKey();

            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UseDeleteBucket(bucketKey);

            //Assert
            result.Resource.Should().Be($"oss/v2/buckets/{bucketKey}");
        }

        [Fact]
        public void UseDeleteBucket_3_WhenCalled_SetsMethod()
        {
            //Arrange
            var bucketKey = BucketsFixtures.RightBucketKey();

            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UseDeleteBucket(bucketKey);

            //Assert
            result.Method.Should().Be(Method.Delete);
        }

        #endregion

        #region Build

        [Fact]
        public void Build_1_OnSuccess_ReturnsRestRequest()
        {
            //Arrange
            var sut = new DMRequestBuilder();

            //Act
            var result = sut.Build();

            //Assert
            result.Should().BeOfType<RestRequest>();
        }

        [Fact]
        public void Build_2_OnSuccess_ReturnResourceBeSutResource()
        {
            //Arrange
            var sut = new DMRequestBuilder();

            //Act
            sut = sut.UseGetHubs();

            var resource = sut.Resource.Clone().ToString();

            var result = sut.Build();

            //Assert
            result.Resource.Should().Be(resource);
        }

        [Fact]
        public void Build_3_OnSuccess_ReturnMethodBeSutMethod()
        {
            //Arrange
            var sut = new DMRequestBuilder();

            //Act
            var result = sut.UseGetHubs().Build();

            //Assert
            result.Method.Should().Be(sut.Method);
        }

        [Fact]
        public void Build_4_OnSuccess_ReturnParametersContainsSutParameters()
        {
            //Arrange
            var sut = new DMRequestBuilder();
            var data = "{\"data\": \"fakedata\"}";

            //Act
            var result = sut.UsePostStorageLocation("id1", data).Build();

            //Assert
            result.Parameters.Count.Should().NotBe(0);
            result.Parameters.Should().Contain(x => x.ContentType == "application/json" && x.Value.ToString() == data && x.Type == ParameterType.RequestBody);
        }

        [Fact]
        public void Build_5_OnSuccess_ReturnHeadersContainsSutHeaders()
        {
            //Arrange
            var sut = new DMRequestBuilder();
            var data = "{\"data\": \"fakedata\"}";

            //Act
            var result = sut.UsePostStorageLocation("id1", data).Build();

            //Assert
            result.Parameters.Count.Should().NotBe(0);
            result.Parameters.Should().Contain(x => x.Name == "content-type" && x.Value.ToString() == "application/vnd.api+json" && x.Type == ParameterType.HttpHeader);
        }

        [Fact]
        public void Build_6_OnSuccess_CleansDataForNextCalls()
        {
            //Arrange
            var sut = new DMRequestBuilder();
            var data = "{\"data\": \"fakedata\"}";

            //Act
            var result = sut.UsePostStorageLocation("id1", data).Build();

            //Assert
            sut.Parameters.Count.Should().Be(0);
            sut.Headers.Count.Should().Be(0);
            sut.Resource.Should().Be(null);
            sut.Method.Should().Be(default);
        }

        #endregion
    }
}
