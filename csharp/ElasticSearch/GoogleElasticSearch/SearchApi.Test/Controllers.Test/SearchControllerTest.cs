using System.Collections.Generic;
using GoogleApp.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SearchApi.Controllers;
using SearchApi.Services;
using Xunit;
using GoogleApp.Controller.Excpetion;

namespace SearchApi.Test.Controllers.Test
{
    public class SearchControllerTest
    {


        private readonly Mock<ISearchService> iSearchServiceMock;
        private readonly List<Document> expected = new List<Document>() { new Document("1", "hello") };

        private readonly string trueQuery = "hello +world -mahdi";
        private readonly string serverErrorQuery = "bye -mhm";
        private readonly string clientErrorQuery = "reza";
        private readonly string apiErrorQuery = "mohamadhosein";
        private readonly int serverErrorStatusCode = 503;
        private readonly int clientErrorStatusCode = 500;
        private readonly int apiErrorStatusCode = 400;
        public SearchControllerTest()
        {
            iSearchServiceMock = new Mock<ISearchService>();
            iSearchServiceMock.Setup(r => r.SearchQuery(trueQuery)).Returns(expected);
            iSearchServiceMock.Setup(r => r.SearchQuery(serverErrorQuery)).Throws(new ElasticServerException(""));
            iSearchServiceMock.Setup(r => r.SearchQuery(apiErrorQuery)).Throws(new ElasticApiException(""));
            iSearchServiceMock.Setup(r => r.SearchQuery(clientErrorQuery)).Throws(new ElasticClientException(""));
        }


        [Fact]
        public void SearchElasticTest()
        {
            var searchController = new SearchController(iSearchServiceMock.Object);
            var actual = searchController.SearchElastic(trueQuery);

            Assert.IsType<OkObjectResult>(actual);

            var objectResult = (OkObjectResult)actual;
            Assert.Equal(objectResult.Value, expected);
        }

        [Fact]
        public void SearchElasticServerError()
        {
            var searchController = new SearchController(iSearchServiceMock.Object);
            var actual = searchController.SearchElastic(serverErrorQuery);
            Assert.IsType<ObjectResult>(actual);
            var objectResult = (ObjectResult)actual;
            Assert.Equal(serverErrorStatusCode, objectResult.StatusCode);
        }

        [Fact]
        public void SearchElasticClientError()
        {
            var searchController = new SearchController(iSearchServiceMock.Object);
            var actual = searchController.SearchElastic(clientErrorQuery);
            Assert.IsType<ObjectResult>(actual);
            var objectResult = (ObjectResult)actual;
            Assert.Equal(clientErrorStatusCode, objectResult.StatusCode);
        }

        [Fact]
        public void SearchElasticApiError()
        {
            var searchController = new SearchController(iSearchServiceMock.Object);
            var actual = searchController.SearchElastic(apiErrorQuery);
            Assert.IsType<ObjectResult>(actual);
            var objectResult = (ObjectResult)actual;
            Assert.Equal(apiErrorStatusCode, objectResult.StatusCode);
        }
    }
}