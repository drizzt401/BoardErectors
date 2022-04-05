using BoardErectors.Domain.Entities;
using BoardErectors.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BoardErectors.Web.Tests.PropertyServiceTest
{
    public class PropertyServiceTest
    {
        private readonly string _baseUrl = "http://boarderectors-api.accentstaging.co.uk/agents";

        [Fact]
        public async void PropertyService_ShouldGetListOfProperties_WhenGivenValidAgentCode()
        {
            //arrange
            var expectedPropertyList = new List<Property>
            {
                new Property() {Id="cfc4486f-3c97-45a2-aca3-32d980a2900d",
                    Address = new Address{Id="cfc4486f-3c97-45a2-aca3-32d980a2900e", HouseNumber="39", Address1="El Alamein Way",
                    Locality ="Bradwell", Town="Great Yarmouth", County="Norfolk", PostCode="NR31 8SZ"},
                    ErectedAt = DateTime.Parse("2022-04-05T07:51:04.1227662+00:00"),
                    ErectedBoardType = new ErectedBoardType{Id = 1, ExpiryAge = 180, Title ="For Sale"},
                    TotalFeeCharged = 17.99f
                },


                new Property() {Id="cfc4486f-3c97-45a2-aca3-32d980a29010",
                    Address = new Address{Id="cfc4486f-3c97-45a2-aca3-32d980a29011", HouseNumber="94b", Address1="St. Benedicts Street",
                    Locality ="", Town="Norwich", County="Norfolk", PostCode="NR2 4AB"},
                    ErectedAt = DateTime.Parse("2022-04-05T07:51:04.1227701+00:00"),
                    ErectedBoardType = new ErectedBoardType{Id = 2, ExpiryAge = 14, Title ="Sold"},
                    TotalFeeCharged = 13.4375f
                }
            };


            var expectedTuple = Tuple.Create(expectedPropertyList, "Successful");
            var json = JsonConvert.SerializeObject(expectedPropertyList);
            var configuration = new ConfigurationBuilder().AddInMemoryCollection(
            new Dictionary<string, string>
            {
                { "BoardErectors:BaseUrl", "http://boarderectors-api.accentstaging.co.uk/agents" }
            }).Build(); 

            HttpResponseMessage httpResponse = new HttpResponseMessage();
            httpResponse.StatusCode = System.Net.HttpStatusCode.OK;
            httpResponse.Content = new StringContent(json, Encoding.UTF8, "application/json");

            var mockFactory = new Mock<IHttpClientFactory>();
            var logger = Mock.Of<ILogger<PropertyService>>();

            Mock<HttpMessageHandler> mockHandler = new Mock<HttpMessageHandler>();
            mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.Is<HttpRequestMessage>(r => r.Method == HttpMethod.Get && r.RequestUri.ToString().StartsWith(_baseUrl)),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpResponse);

            HttpClient httpClient = new HttpClient(mockHandler.Object);
            mockFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(httpClient);


            PropertyService service = new PropertyService(mockFactory.Object, logger, configuration);

            //act
            var actualTuple = await service.GetPropertiesByAgentCode("ACC001");

            //assert
            Assert.NotNull(actualTuple.Item1);
            Assert.IsAssignableFrom<IEnumerable<Property>>(actualTuple.Item1);
        }
    }
}
