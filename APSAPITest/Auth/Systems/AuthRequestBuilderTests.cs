using Autodesk.PlatformServices.Auth;
using FluentAssertions;
using Moq;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APSAPITest.Auth.Systems
{
    public class AuthRequestBuilderTests
    {
        #region TwoLeggedToken

        [Fact]
        public void UseTwoLeggedToken_1_OnSuccess_ReturnsRestRequest()
        {
            //Arrange
            var clientId = APSFixtures.RightClientId();
            var clientSecret = APSFixtures.RightClientSecret();

            var sut = new AuthRequestBuilder();

            //Act
            var result = sut.WithClientCredentials(clientId, clientSecret)
                .SetScope(Scope.Data_Read)
                .UseTwoLegged()
                .Build();

            //Assert
            result.Should().BeOfType<RestRequest>();
        }

        [Fact]
        public void UseTwoLeggedToken_2_OnSuccess_ReturnsRestRequestWithRightData()
        {
            //Arrange
            var clientId = APSFixtures.RightClientId();
            var clientSecret = APSFixtures.RightClientSecret();

            var sut = new AuthRequestBuilder();

            //Act
            var result = sut.WithClientCredentials(clientId, clientSecret)
                .SetScope(Scope.Data_Read)
                .UseTwoLegged()
                .Build();

            //Assert
            result.Parameters.Should().Contain(x => x.Name == "Authorization" && ((string)x.Value).StartsWith("Basic "));
            result.Parameters.Should().Contain(x => x.Name == "Content-Type" && ((string)x.Value) == "application/x-www-form-urlencoded");
        }

        //Test ignored [Fact]
        public void UseTwoLeggedToken_3_WhenExecuted_ReturnsAutodeskToken()
        {
            //Arrange
            var clientId = APSFixtures.RightClientId();
            var clientSecret = APSFixtures.RightClientSecret();

            var client = RestSharpHelper.GetClient();

            var sut = new AuthRequestBuilder();

            //Act
            var result = sut.WithClientCredentials(clientId, clientSecret)
                .SetScope(Scope.Data_Read)
                .UseTwoLegged()
                .Build();

            //Assert
            var response = client.Execute(result);
            var deserealized = JsonConvert.DeserializeObject<TwoLeggedToken>(response.Content);
            deserealized.Should().NotBeNull();
            deserealized.Access_Token.Should().NotBeNull();
            deserealized.Token_Type.Should().Be("Bearer");
            deserealized.Expires_in.Should().Be(3599);
        }

        #endregion

        #region ThreeLeggedToken

        [Fact]
        public void UseThreeLeggedToken_1_OnSuccess_ReturnsRestRequest()
        {
            //Arrange
            var clientId = APSFixtures.RightClientId();
            var clientSecret = APSFixtures.RightClientSecret();

            var sut = new AuthRequestBuilder();

            //Act
            var result = sut.WithClientCredentials(clientId, clientSecret)
                .SetRedirectUri("some")
                .SetScope(Scope.Data_Read)
                .UseThreeLegged(AuthType.Code, "somecode")
                .Build();

            //Assert
            result.Should().BeOfType<RestRequest>();
        }

        [Fact]
        public void UseThreeLeggedToken_2_OnSuccess_ReturnsRestRequestWithRightData()
        {
            //Arrange
            var clientId = APSFixtures.RightClientId();
            var clientSecret = APSFixtures.RightClientSecret();

            var sut = new AuthRequestBuilder();

            //Act
            var result = sut.WithClientCredentials(clientId, clientSecret)
                .SetRedirectUri("some")
                .SetScope(Scope.Data_Read)
                .UseThreeLegged(AuthType.Code, "somecode")
                .Build();

            //Assert
            result.Parameters.Should().Contain(x => x.Name == "Authorization" && ((string)x.Value).StartsWith("Basic "));
            result.Parameters.Should().Contain(x => x.Name == "Content-Type" && ((string)x.Value) == "application/x-www-form-urlencoded");
        }

        //Test ignored [Fact]
        public void UseThreeLeggedToken_3_WhenExecuted_ReturnsAutodeskToken()
        {
            //Arrange
            var clientId = APSFixtures.RightClientId();
            var clientSecret = APSFixtures.RightClientSecret();
            var redirectUri = APSFixtures.RightRedictUri();

            var client = RestSharpHelper.GetClient();

            var authUri = new AuthorizeUriBuilder().UseClientId(clientId).UseResponseType("code").UseRedirectUri(redirectUri).SetScope(Scope.Data_Read).Build();

            var sut = new AuthRequestBuilder();

            //Act
            var result = sut.WithClientCredentials(clientId, clientSecret)
                .SetRedirectUri(redirectUri)
                .SetScope(Scope.Data_Read)
                .UseThreeLegged(AuthType.Code, "1tDaT8cDg8F9Q-PlEmYRj1TlOOf4J_P9gN1S-O4o")
                .Build();

            //Assert
            var response = client.Execute(result);
            var deserealized = JsonConvert.DeserializeObject<ThreeLeggedToken>(response.Content);
            deserealized.Should().NotBeNull();
            deserealized.Access_Token.Should().NotBeNull();
            deserealized.Token_Type.Should().Be("Bearer");
            deserealized.Expires_in.Should().Be(3599);
        }

        #endregion
    }
}
