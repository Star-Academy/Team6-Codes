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


        Mock<ISearchService> iSearchServiceMock;
        List<Document> expected = new List<Document>() { new Document("1", "hello") };
        public SearchControllerTest()
        {
            iSearchServiceMock = new Mock<ISearchService>();
            iSearchServiceMock.Setup(r => r.SearchQuery("hello +world -mahdi")).Returns(expected);
            iSearchServiceMock.Setup(r => r.SearchQuery("bye -mhm")).Throws(new ElasticServerException(""));
            iSearchServiceMock.Setup(r => r.SearchQuery("reza")).Throws(new ElasticApiException(""));
            iSearchServiceMock.Setup(r => r.SearchQuery("mohamadhosein")).Throws(new ElasticClientException(""));
        }

        [Fact]
        public void SearchElasticTest()
        {
            var searchController = new SearchController(iSearchServiceMock.Object);
            var actual = searchController.SearchElastic("hello");

            Assert.IsType(typeof(OkObjectResult), actual);

            var objectResult = (OkObjectResult)actual;
            Assert.Equal(objectResult.Value, expected);
        }

        [Fact]
        public void SearchElasticServerError()
        {
            var searchController = new SearchController(iSearchServiceMock.Object);
            var actual = searchController.SearchElastic("bye -mhm");
            Assert.IsType(typeof(StatusCodeResult), actual);
            var objectResult = (StatusCodeResult)actual;
            Assert.Equal(503, objectResult.StatusCode);
        }
    }
}