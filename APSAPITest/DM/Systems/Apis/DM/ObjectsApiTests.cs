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
    public class ObjectsApiTests
    {
        ClientCredentials _cc;
        public ObjectsApiTests()
        {
            _cc = new ClientCredentials(APSFixtures.RightClientId(), APSFixtures.RightClientSecret());
        }

        #region GetS3SignedDownloadUrls

        [Fact]
        public void GetS3SignedDownloadUrls_1_OnSuccess_ReturnsModel()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var bucketKey = BucketsFixtures.RightBucketKey();
            var objectKey = BucketsFixtures.RightObjectKey();
            var model = ObjectsFixtures.RightDownloadUrls();
            var request = RestSharpFixtures.GetRequest();

            var mockAuthentication = new Mock<Authenticator>(_cc, Scope.Data_Read | Scope.Data_Write | Scope.Data_Create, null, null);
            var mockDMClient = new Mock<DMClient>(mockAuthentication.Object);
            mockDMClient
                .Setup(s => s.Execute<S3SignedDownloadUrls>(It.IsAny<RestRequest>(), It.IsAny<Func<string, S3SignedDownloadUrls>>(), null))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetS3SignedDownloadUrls(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);
            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var mockDataBuilder = new Mock<DMDataBuilder>();

            var sut = new ObjectsApi(mockDMClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object, accountId);

            //Act
            var result = sut.GetS3SignedDownloadUrls(bucketKey, objectKey);

            //Assert
            result.Should().BeOfType<S3SignedDownloadUrls>();
        }

        [Fact]
        public void GetS3SignedDownloadUrls_2_WhenCalled_InvokesUseGetS3DownloadUrlsExactlyOnceWithParameters()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var bucketKey = BucketsFixtures.RightBucketKey();
            var objectKey = BucketsFixtures.RightObjectKey();
            var model = ObjectsFixtures.RightDownloadUrls();
            var request = RestSharpFixtures.GetRequest();

            var mockAuthentication = new Mock<Authenticator>(_cc, Scope.Data_Read | Scope.Data_Write | Scope.Data_Create, null, null);
            var mockDMClient = new Mock<DMClient>(mockAuthentication.Object);
            mockDMClient
                .Setup(s => s.Execute<S3SignedDownloadUrls>(It.IsAny<RestRequest>(), It.IsAny<Func<string, S3SignedDownloadUrls>>(), null))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetS3SignedDownloadUrls(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);
            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var mockDataBuilder = new Mock<DMDataBuilder>();

            var sut = new ObjectsApi(mockDMClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object, accountId);

            //Act
            var result = sut.GetS3SignedDownloadUrls(bucketKey, objectKey);

            //Assert
            mockRequestBuilder.Verify(s => s.UseGetS3SignedDownloadUrls(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
            mockRequestBuilder.Verify(s => s.UseGetS3SignedDownloadUrls(bucketKey, objectKey), Times.Once());
        }

        [Fact]
        public void GetS3SignedDownloadUrls_3_WhenCalled_InvokesDmClientExecuteExactlyOnceBuiltRequestAndCustomParsing()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var bucketKey = BucketsFixtures.RightBucketKey();
            var objectKey = BucketsFixtures.RightObjectKey();
            var model = ObjectsFixtures.RightDownloadUrls();
            var request = RestSharpFixtures.GetRequest();

            var mockAuthentication = new Mock<Authenticator>(_cc, Scope.Data_Read | Scope.Data_Write | Scope.Data_Create, null, null);
            var mockDMClient = new Mock<DMClient>(mockAuthentication.Object);
            mockDMClient
                .Setup(s => s.Execute<S3SignedDownloadUrls>(It.IsAny<RestRequest>(), It.IsAny<Func<string, S3SignedDownloadUrls>>(), null))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetS3SignedDownloadUrls(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);
            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var mockDataBuilder = new Mock<DMDataBuilder>();

            var sut = new ObjectsApi(mockDMClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object, accountId);

            //Act
            var result = sut.GetS3SignedDownloadUrls(bucketKey, objectKey);

            //Assert
            mockDMClient.Verify(s => s.Execute<S3SignedDownloadUrls>(It.IsAny<RestRequest>(), It.IsAny<Func<string, S3SignedDownloadUrls>>(), null), Times.Once());
        }

        #endregion

        #region GetS3SignedUploadUrls

        [Fact]
        public void GetS3SignedUploadUrls_1_OnSuccess_ReturnsModel()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var bucketKey = BucketsFixtures.RightBucketKey();
            var objectKey = BucketsFixtures.RightObjectKey();
            var model = ObjectsFixtures.RightUploadUrls();
            var request = RestSharpFixtures.GetRequest();
            var bytes = ObjectsFixtures.MB2();

            var mockAuthentication = new Mock<Authenticator>(_cc, Scope.Data_Read | Scope.Data_Write | Scope.Data_Create, null, null);
            var mockDMClient = new Mock<DMClient>(mockAuthentication.Object);
            mockDMClient
                .Setup(s => s.Execute<S3SignedUploadUrls>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetS3SignedUploadUrls(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(mockRequestBuilder.Object);
            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var mockDataBuilder = new Mock<DMDataBuilder>();

            var sut = new ObjectsApi(mockDMClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object, accountId);

            //Act
            var result = sut.GetS3SignedUploadUrls(bucketKey, objectKey, bytes);

            //Assert
            result.Should().BeOfType<S3SignedUploadUrls>();
        }

        [Fact]
        public void GetS3SignedUploadUrls_2_WhenCalled_InvokesRequestBuilderUseGetS3SignedUploadUrlsExactlyOnceWithParameters()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var bucketKey = BucketsFixtures.RightBucketKey();
            var objectKey = BucketsFixtures.RightObjectKey();
            var model = ObjectsFixtures.RightUploadUrls();
            var request = RestSharpFixtures.GetRequest();
            var bytes = ObjectsFixtures.MB2();

            var mockAuthentication = new Mock<Authenticator>(_cc, Scope.Data_Read | Scope.Data_Write | Scope.Data_Create, null, null);
            var mockDMClient = new Mock<DMClient>(mockAuthentication.Object);
            mockDMClient
                .Setup(s => s.Execute<S3SignedUploadUrls>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetS3SignedUploadUrls(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(mockRequestBuilder.Object);
            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var mockDataBuilder = new Mock<DMDataBuilder>();

            var sut = new ObjectsApi(mockDMClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object, accountId);

            //Act
            var result = sut.GetS3SignedUploadUrls(bucketKey, objectKey, bytes);

            //Assert
            mockRequestBuilder.Verify(s => s.UseGetS3SignedUploadUrls(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()), Times.Once());
        }

        [Fact]
        public void GetS3SignedUploadUrls_3_WhenCalled_InvokesExecuteExactlyOnceRequestBuilt()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var bucketKey = BucketsFixtures.RightBucketKey();
            var objectKey = BucketsFixtures.RightObjectKey();
            var model = ObjectsFixtures.RightUploadUrls();
            var request = RestSharpFixtures.GetRequest();
            var bytes = ObjectsFixtures.MB2();

            var mockAuthentication = new Mock<Authenticator>(_cc, Scope.Data_Read | Scope.Data_Write | Scope.Data_Create, null, null);
            var mockDMClient = new Mock<DMClient>(mockAuthentication.Object);
            mockDMClient
                .Setup(s => s.Execute<S3SignedUploadUrls>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetS3SignedUploadUrls(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(mockRequestBuilder.Object);
            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var mockDataBuilder = new Mock<DMDataBuilder>();

            var sut = new ObjectsApi(mockDMClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object, accountId);

            //Act
            var result = sut.GetS3SignedUploadUrls(bucketKey, objectKey, bytes);

            //Assert
            mockDMClient.Verify(s => s.Execute<S3SignedUploadUrls>(It.IsAny<RestRequest>()),Times.Once());
        }

        [Fact]
        public void GetS3SignedUploadUrls_4_WhenCalled_For50MB_InvokesExecuteExactlyOnce()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var bucketKey = BucketsFixtures.RightBucketKey();
            var objectKey = BucketsFixtures.RightObjectKey();
            var model = ObjectsFixtures.RightUploadUrls();
            var request = RestSharpFixtures.GetRequest();
            var mb50 = ObjectsFixtures.MB50();

            var mockAuthentication = new Mock<Authenticator>(_cc, Scope.Data_Read | Scope.Data_Write | Scope.Data_Create, null, null);
            var mockDMClient = new Mock<DMClient>(mockAuthentication.Object);
            mockDMClient
                .Setup(s => s.Execute<S3SignedUploadUrls>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetS3SignedUploadUrls(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(mockRequestBuilder.Object);
            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var mockDataBuilder = new Mock<DMDataBuilder>();

            var sut = new ObjectsApi(mockDMClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object, accountId);

            //Act
            var result = sut.GetS3SignedUploadUrls(bucketKey, objectKey, mb50);

            //Assert
            mockDMClient.Verify(s => s.Execute<S3SignedUploadUrls>(It.IsAny<RestRequest>()), Times.Once());
        }

        [Fact]
        public void GetS3SignedUploadUrls_5_WhenCalled_For500MB_InvokesExecuteExactly4Times()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var bucketKey = BucketsFixtures.RightBucketKey();
            var objectKey = BucketsFixtures.RightObjectKey();
            var model = ObjectsFixtures.RightUploadUrls();
            var request = RestSharpFixtures.GetRequest();
            var mb500 = ObjectsFixtures.MB500();
            var gb1 = ObjectsFixtures.GB1();
            var gb10 = ObjectsFixtures.GB10();

            var mockAuthentication = new Mock<Authenticator>(_cc, Scope.Data_Read | Scope.Data_Write | Scope.Data_Create, null, null);
            var mockDMClient = new Mock<DMClient>(mockAuthentication.Object);
            mockDMClient
                .Setup(s => s.Execute<S3SignedUploadUrls>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetS3SignedUploadUrls(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(mockRequestBuilder.Object);
            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var mockDataBuilder = new Mock<DMDataBuilder>();

            var sut = new ObjectsApi(mockDMClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object, accountId);

            //Act
            var result = sut.GetS3SignedUploadUrls(bucketKey, objectKey, mb500);

            //Assert
            mockDMClient.Verify(s => s.Execute<S3SignedUploadUrls>(It.IsAny<RestRequest>()), Times.Exactly(4));
        }

        [Fact]
        public void GetS3SignedUploadUrls_6_WhenCalled_For1GB_InvokesExecuteExactly9Times()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var bucketKey = BucketsFixtures.RightBucketKey();
            var objectKey = BucketsFixtures.RightObjectKey();
            var model = ObjectsFixtures.RightUploadUrls();
            var request = RestSharpFixtures.GetRequest();
            var gb1 = ObjectsFixtures.GB1();

            var mockAuthentication = new Mock<Authenticator>(_cc, Scope.Data_Read | Scope.Data_Write | Scope.Data_Create, null, null);
            var mockDMClient = new Mock<DMClient>(mockAuthentication.Object);
            mockDMClient
                .Setup(s => s.Execute<S3SignedUploadUrls>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetS3SignedUploadUrls(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(mockRequestBuilder.Object);
            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var mockDataBuilder = new Mock<DMDataBuilder>();

            var sut = new ObjectsApi(mockDMClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object, accountId);

            //Act
            var result = sut.GetS3SignedUploadUrls(bucketKey, objectKey, gb1);

            //Assert
            mockDMClient.Verify(s => s.Execute<S3SignedUploadUrls>(It.IsAny<RestRequest>()), Times.Exactly(9));
        }

        [Fact]
        public void GetS3SignedUploadUrls_7_WhenCalled_For10GB_InvokesExecuteExactly82Times()
        {
            //Arrange
            var accountId = HubsFixtures.RightId();
            var bucketKey = BucketsFixtures.RightBucketKey();
            var objectKey = BucketsFixtures.RightObjectKey();
            var model = ObjectsFixtures.RightUploadUrls();
            var request = RestSharpFixtures.GetRequest();
            var gb10 = ObjectsFixtures.GB10();

            var mockAuthentication = new Mock<Authenticator>(_cc, Scope.Data_Read | Scope.Data_Write | Scope.Data_Create, null, null);
            var mockDMClient = new Mock<DMClient>(mockAuthentication.Object);
            mockDMClient
                .Setup(s => s.Execute<S3SignedUploadUrls>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetS3SignedUploadUrls(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(mockRequestBuilder.Object);
            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var mockDataBuilder = new Mock<DMDataBuilder>();

            var sut = new ObjectsApi(mockDMClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object, accountId);

            //Act
            var result = sut.GetS3SignedUploadUrls(bucketKey, objectKey, gb10);

            //Assert
            mockDMClient.Verify(s => s.Execute<S3SignedUploadUrls>(It.IsAny<RestRequest>()), Times.Exactly(82));
        }

        #endregion
    }
}
