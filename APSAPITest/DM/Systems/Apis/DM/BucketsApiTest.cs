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
    public class BucketsApiTest
    {
        ClientCredentials _cc;

        public BucketsApiTest()
        {
            _cc = new ClientCredentials(APSFixtures.RightClientId(), APSFixtures.RightClientSecret());
        }

        #region GetBuckets

        [Fact]
        public void GetBuckets_1_OnSuccess_ReturnsModel()
        {
            //Arrange
            var bucketKey = BucketsFixtures.RightBucketKey();
            var policyKey = BucketPolicyKey.Transient;
            var request = RestSharpFixtures.PostRequest();
            var model = BucketsFixtures.RightBucketList();
            var data = "data";

            var mockAuthClient = new Mock<AuthClient>();
            var mockAuthenticator = new Mock<Authenticator>(_cc, mockAuthClient.Object, It.IsAny<IScope>(), It.IsAny<I2LOStorage>(), It.IsAny<I3LOStorage>());
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.Execute<BucketList>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetBuckets())
                .Returns(mockRequestBuilder.Object);

            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var mockDataBuilder = new Mock<DMDataBuilder>();

            var sut = new BucketsApi(mockDMClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            var result = sut.GetBuckets();

            //Assert
            result.Should().BeOfType<BucketList>();
        }

        [Fact]
        public void GetBuckets_2_WhenCalled_InvokesRequestBuilderUseGetBucketsExactlyOnce()
        {
            //Arrange
            var bucketKey = BucketsFixtures.RightBucketKey();
            var policyKey = BucketPolicyKey.Transient;
            var request = RestSharpFixtures.PostRequest();
            var model = BucketsFixtures.RightBucketList();
            var data = "data";

            var mockAuthClient = new Mock<AuthClient>();
            var mockAuthenticator = new Mock<Authenticator>(_cc, mockAuthClient.Object, It.IsAny<IScope>(), It.IsAny<I2LOStorage>(), It.IsAny<I3LOStorage>());
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.Execute<BucketList>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetBuckets())
                .Returns(mockRequestBuilder.Object);

            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var mockDataBuilder = new Mock<DMDataBuilder>();

            var sut = new BucketsApi(mockDMClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            var result = sut.GetBuckets();

            //Assert
            mockRequestBuilder.Verify(s => s.UseGetBuckets(), Times.Once());
        }

        [Fact]
        public void GetBuckets_3_WhenCalled_InvokesRequestBuilderBuildExactlyOnce()
        {
            //Arrange
            var bucketKey = BucketsFixtures.RightBucketKey();
            var policyKey = BucketPolicyKey.Transient;
            var request = RestSharpFixtures.PostRequest();
            var model = BucketsFixtures.RightBucketList();
            var data = "data";

            var mockAuthClient = new Mock<AuthClient>();
            var mockAuthenticator = new Mock<Authenticator>(_cc, mockAuthClient.Object, It.IsAny<IScope>(), It.IsAny<I2LOStorage>(), It.IsAny<I3LOStorage>());
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.Execute<BucketList>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetBuckets())
                .Returns(mockRequestBuilder.Object);

            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var mockDataBuilder = new Mock<DMDataBuilder>();

            var sut = new BucketsApi(mockDMClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            var result = sut.GetBuckets();

            //Assert
            mockRequestBuilder.Verify(s => s.Build(), Times.Once());
        }

        [Fact]
        public void GetBuckets_4_WhenCalled_InvokesDMClientExecuteExactlyOnceWithBuiltRequest()
        {
            //Arrange
            var bucketKey = BucketsFixtures.RightBucketKey();
            var policyKey = BucketPolicyKey.Transient;
            var request = RestSharpFixtures.PostRequest();
            var model = BucketsFixtures.RightBucketList();
            var data = "data";

            var mockAuthClient = new Mock<AuthClient>();
            var mockAuthenticator = new Mock<Authenticator>(_cc, mockAuthClient.Object, It.IsAny<IScope>(), It.IsAny<I2LOStorage>(), It.IsAny<I3LOStorage>());
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.Execute<BucketList>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetBuckets())
                .Returns(mockRequestBuilder.Object);

            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var mockDataBuilder = new Mock<DMDataBuilder>();

            var sut = new BucketsApi(mockDMClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            var result = sut.GetBuckets();

            //Assert
            mockDMClient.Verify(s => s.Execute<BucketList>(It.IsAny<RestRequest>()), Times.Once());
            mockDMClient.Verify(s => s.Execute<BucketList>(request), Times.Once());
        }

        [Fact]
        public void GetBuckets_5_OnSuccess_ReturnsExecuteModel()
        {
            //Arrange
            var bucketKey = BucketsFixtures.RightBucketKey();
            var policyKey = BucketPolicyKey.Transient;
            var request = RestSharpFixtures.PostRequest();
            var model = BucketsFixtures.RightBucketList();
            var data = "data";

            var mockAuthClient = new Mock<AuthClient>();
            var mockAuthenticator = new Mock<Authenticator>(_cc, mockAuthClient.Object, It.IsAny<IScope>(), It.IsAny<I2LOStorage>(), It.IsAny<I3LOStorage>());
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.Execute<BucketList>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseGetBuckets())
                .Returns(mockRequestBuilder.Object);

            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var mockDataBuilder = new Mock<DMDataBuilder>();

            var sut = new BucketsApi(mockDMClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            var result = sut.GetBuckets();

            //Assert
            result.Should().BeSameAs(model);
        }

        #endregion

        #region PostBucket

        [Fact]
        public void PostBucket_1_HasRequiredParameters_BucketKeyAndPolicyKey()
        {
            var method = typeof(BucketsApi).GetMethod("PostBucket");
            var parameters = method.GetParameters();

            parameters.Should().Contain(x => x.Name == "bucketKey" && !x.IsOptional && x.ParameterType == typeof(string));
            parameters.Should().Contain(x => x.Name == "policyKey" && !x.IsOptional && x.ParameterType == typeof(BucketPolicyKey));
        }

        [Fact]
        public void PostBucket_2_OnSuccess_ReturnsModel()
        {
            //Arrange
            var bucketKey = BucketsFixtures.RightBucketKey();
            var policyKey = BucketPolicyKey.Transient;
            var request = RestSharpFixtures.PostRequest();
            var model = BucketsFixtures.BucketRight();
            var data = "data";

            var mockAuthClient = new Mock<AuthClient>();
            var mockAuthenticator = new Mock<Authenticator>(_cc, mockAuthClient.Object, It.IsAny<IScope>(), It.IsAny<I2LOStorage>(), It.IsAny<I3LOStorage>());
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.Execute<Bucket>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UsePostBucket(It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);

            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var mockDataBuilder = new Mock<DMDataBuilder>();
            mockDataBuilder
                .Setup(s => s.UseBucket(It.IsAny<string>(), It.IsAny<BucketPolicyKey>()))
                .Returns(mockDataBuilder.Object);

            mockDataBuilder
                .Setup(s => s.Build())
                .Returns(data);

            var sut = new BucketsApi(mockDMClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            var result = sut.PostBucket(bucketKey, policyKey);

            //Assert
            result.Should().BeOfType<Bucket>();
        }

        [Fact]
        public void PostBucket_3_WhenCalled_InvokesRequestBuilderUsePostBucketExactlyOnceWithDataBuilt()
        {
            //Arrange
            var bucketKey = BucketsFixtures.RightBucketKey();
            var policyKey = BucketPolicyKey.Transient;
            var request = RestSharpFixtures.PostRequest();
            var model = BucketsFixtures.BucketRight();
            var data = "data";

            var mockAuthClient = new Mock<AuthClient>();
            var mockAuthenticator = new Mock<Authenticator>(_cc, mockAuthClient.Object, It.IsAny<IScope>(), It.IsAny<I2LOStorage>(), It.IsAny<I3LOStorage>());
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.Execute<Bucket>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UsePostBucket(It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);

            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var mockDataBuilder = new Mock<DMDataBuilder>();
            mockDataBuilder
                .Setup(s => s.UseBucket(It.IsAny<string>(), It.IsAny<BucketPolicyKey>()))
                .Returns(mockDataBuilder.Object);

            mockDataBuilder
                .Setup(s => s.Build())
                .Returns(data);

            var sut = new BucketsApi(mockDMClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            var result = sut.PostBucket(bucketKey, policyKey);

            //Assert
            mockRequestBuilder.Verify(s => s.UsePostBucket(It.IsAny<string>()), Times.Once());
            mockRequestBuilder.Verify(s => s.UsePostBucket(data), Times.Once());
        }

        [Fact]
        public void PostBucket_4_WhenCalled_InvokesRequestBuilderBuildExactlyOnce()
        {
            //Arrange
            var bucketKey = BucketsFixtures.RightBucketKey();
            var policyKey = BucketPolicyKey.Transient;
            var request = RestSharpFixtures.PostRequest();
            var model = BucketsFixtures.BucketRight();
            var data = "data";

            var mockAuthClient = new Mock<AuthClient>();
            var mockAuthenticator = new Mock<Authenticator>(_cc, mockAuthClient.Object, It.IsAny<IScope>(), It.IsAny<I2LOStorage>(), It.IsAny<I3LOStorage>());
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.Execute<Bucket>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UsePostBucket(It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);

            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var mockDataBuilder = new Mock<DMDataBuilder>();
            mockDataBuilder
                .Setup(s => s.UseBucket(It.IsAny<string>(), It.IsAny<BucketPolicyKey>()))
                .Returns(mockDataBuilder.Object);

            mockDataBuilder
                .Setup(s => s.Build())
                .Returns(data);

            var sut = new BucketsApi(mockDMClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            var result = sut.PostBucket(bucketKey, policyKey);

            //Assert
            mockRequestBuilder.Verify(s => s.Build(), Times.Once());
        }

        [Fact]
        public void PostBucket_5_WhenCalled_InvokesDmClientExecuteExactlyOnceWithBuiltRequest()
        {
            //Arrange
            var bucketKey = BucketsFixtures.RightBucketKey();
            var policyKey = BucketPolicyKey.Transient;
            var request = RestSharpFixtures.PostRequest();
            var model = BucketsFixtures.BucketRight();
            var data = "data";

            var mockAuthClient = new Mock<AuthClient>();
            var mockAuthenticator = new Mock<Authenticator>(_cc, mockAuthClient.Object, It.IsAny<IScope>(), It.IsAny<I2LOStorage>(), It.IsAny<I3LOStorage>());
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.Execute<Bucket>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UsePostBucket(It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);

            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var mockDataBuilder = new Mock<DMDataBuilder>();
            mockDataBuilder
                .Setup(s => s.UseBucket(It.IsAny<string>(), It.IsAny<BucketPolicyKey>()))
                .Returns(mockDataBuilder.Object);

            mockDataBuilder
                .Setup(s => s.Build())
                .Returns(data);

            var sut = new BucketsApi(mockDMClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            var result = sut.PostBucket(bucketKey, policyKey);

            //Assert
            mockDMClient.Verify(s => s.Execute<Bucket>(It.IsAny<RestRequest>()), Times.Once());
            mockDMClient.Verify(s => s.Execute<Bucket>(request), Times.Once());
        }

        [Fact]
        public void PostBucket_6_WhenCalled_InvokesDataBuilderUseBucketExactlyOnceWithParameters()
        {
            //Arrange
            var bucketKey = BucketsFixtures.RightBucketKey();
            var policyKey = BucketPolicyKey.Transient;
            var request = RestSharpFixtures.PostRequest();
            var model = BucketsFixtures.BucketRight();
            var data = "data";

            var mockAuthClient = new Mock<AuthClient>();
            var mockAuthenticator = new Mock<Authenticator>(_cc, mockAuthClient.Object, It.IsAny<IScope>(), It.IsAny<I2LOStorage>(), It.IsAny<I3LOStorage>());
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.Execute<Bucket>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UsePostBucket(It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);

            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var mockDataBuilder = new Mock<DMDataBuilder>();
            mockDataBuilder
                .Setup(s => s.UseBucket(It.IsAny<string>(), It.IsAny<BucketPolicyKey>()))
                .Returns(mockDataBuilder.Object);

            mockDataBuilder
                .Setup(s => s.Build())
                .Returns(data);

            var sut = new BucketsApi(mockDMClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            var result = sut.PostBucket(bucketKey, policyKey);

            //Assert
            mockDataBuilder.Verify(s => s.UseBucket(It.IsAny<string>(), It.IsAny<BucketPolicyKey>()), Times.Once());
            mockDataBuilder.Verify(s => s.UseBucket(bucketKey, policyKey), Times.Once());
        }

        [Fact]
        public void PostBucket_7_WhenCalled_InvokesDataBuilderBuildeExactlyOnce()
        {
            //Arrange
            var bucketKey = BucketsFixtures.RightBucketKey();
            var policyKey = BucketPolicyKey.Transient;
            var request = RestSharpFixtures.PostRequest();
            var model = BucketsFixtures.BucketRight();
            var data = "data";

            var mockAuthClient = new Mock<AuthClient>();
            var mockAuthenticator = new Mock<Authenticator>(_cc, mockAuthClient.Object, It.IsAny<IScope>(), It.IsAny<I2LOStorage>(), It.IsAny<I3LOStorage>());
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.Execute<Bucket>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UsePostBucket(It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);

            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var mockDataBuilder = new Mock<DMDataBuilder>();
            mockDataBuilder
                .Setup(s => s.UseBucket(It.IsAny<string>(), It.IsAny<BucketPolicyKey>()))
                .Returns(mockDataBuilder.Object);

            mockDataBuilder
                .Setup(s => s.Build())
                .Returns(data);

            var sut = new BucketsApi(mockDMClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            var result = sut.PostBucket(bucketKey, policyKey);

            //Assert
            mockDataBuilder.Verify(s => s.Build(), Times.Once());
        }

        [Fact]
        public void PostBucket_8_OnSuccess_ReturnsExecuteModel()
        {
            //Arrange
            var bucketKey = BucketsFixtures.RightBucketKey();
            var policyKey = BucketPolicyKey.Transient;
            var request = RestSharpFixtures.PostRequest();
            var model = BucketsFixtures.BucketRight();
            var data = "data";

            var mockAuthClient = new Mock<AuthClient>();
            var mockAuthenticator = new Mock<Authenticator>(_cc, mockAuthClient.Object, It.IsAny<IScope>(), It.IsAny<I2LOStorage>(), It.IsAny<I3LOStorage>());
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.Execute<Bucket>(It.IsAny<RestRequest>()))
                .Returns(model);

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UsePostBucket(It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);

            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var mockDataBuilder = new Mock<DMDataBuilder>();
            mockDataBuilder
                .Setup(s => s.UseBucket(It.IsAny<string>(), It.IsAny<BucketPolicyKey>()))
                .Returns(mockDataBuilder.Object);

            mockDataBuilder
                .Setup(s => s.Build())
                .Returns(data);

            var sut = new BucketsApi(mockDMClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            var result = sut.PostBucket(bucketKey, policyKey);

            //Assert
            result.Should().Be(model);
        }

        #endregion

        #region DeleteBucket

        [Fact]
        public void DeleteBucket_1_WhenCalled_InvokesRequestBuilderUseDeleteBucketExactlyOnceWithParameters()
        {
            //Arrange
            var bucketKey = BucketsFixtures.RightBucketKey();
            var policyKey = BucketPolicyKey.Transient;
            var request = RestSharpFixtures.DeleteRequest();

            var mockAuthClient = new Mock<AuthClient>();
            var mockAuthenticator = new Mock<Authenticator>(_cc, mockAuthClient.Object, It.IsAny<IScope>(), It.IsAny<I2LOStorage>(), It.IsAny<I3LOStorage>());
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.Execute(It.IsAny<RestRequest>(), null))
                .Verifiable();

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseDeleteBucket(It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);

            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var mockDataBuilder = new Mock<DMDataBuilder>();

            var sut = new BucketsApi(mockDMClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            sut.DeleteBucket(bucketKey);

            //Assert
            mockRequestBuilder.Verify(s => s.UseDeleteBucket(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public void DeleteBucket_2_WhenCalled_InvokesRequestBuilderBuildExactlyOnce()
        {
            //Arrange
            var bucketKey = BucketsFixtures.RightBucketKey();
            var policyKey = BucketPolicyKey.Transient;
            var request = RestSharpFixtures.DeleteRequest();

            var mockAuthClient = new Mock<AuthClient>();
            var mockAuthenticator = new Mock<Authenticator>(_cc, mockAuthClient.Object, It.IsAny<IScope>(), It.IsAny<I2LOStorage>(), It.IsAny<I3LOStorage>());
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.Execute(It.IsAny<RestRequest>(), null))
                .Verifiable();

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseDeleteBucket(It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);

            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var mockDataBuilder = new Mock<DMDataBuilder>();

            var sut = new BucketsApi(mockDMClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            sut.DeleteBucket(bucketKey);

            //Assert
            mockRequestBuilder.Verify(s => s.Build(), Times.Once());
        }

        [Fact]
        public void DeleteBucket_3_WhenCalled_InvokesDmClientExecuteExactlyOnceWithBuiltRequest()
        {
            //Arrange
            var bucketKey = BucketsFixtures.RightBucketKey();
            var request = RestSharpFixtures.DeleteRequest();

            var mockAuthClient = new Mock<AuthClient>();
            var mockAuthenticator = new Mock<Authenticator>(_cc, mockAuthClient.Object, It.IsAny<IScope>(), It.IsAny<I2LOStorage>(), It.IsAny<I3LOStorage>());
            var mockDMClient = new Mock<DMClient>(mockAuthenticator.Object);
            mockDMClient
                .Setup(s => s.Execute(It.IsAny<RestRequest>(), null))
                .Verifiable();

            var mockRequestBuilder = new Mock<DMRequestBuilder>();
            mockRequestBuilder
                .Setup(s => s.UseDeleteBucket(It.IsAny<string>()))
                .Returns(mockRequestBuilder.Object);

            mockRequestBuilder
                .Setup(s => s.Build())
                .Returns(request);

            var mockDataBuilder = new Mock<DMDataBuilder>();

            var sut = new BucketsApi(mockDMClient.Object, mockRequestBuilder.Object, mockDataBuilder.Object);

            //Act
            sut.DeleteBucket(bucketKey);

            //Assert
            mockDMClient.Verify(s => s.Execute(It.IsAny<RestRequest>(), null), Times.Once());
            mockDMClient.Verify(s => s.Execute(request, null), Times.Once());
        }

        #endregion
    }
}
