using System.Collections.Generic;
using GoogleApp.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SearchApi.Controllers;
using SearchApi.Services;
using Xunit;
using GoogleApp.Controller.Excpetion;
using SearchApi.Config;

namespace SearchApi.Test.Controllers.Test
{
    public class SearchControllerTest
    {


        private readonly Mock<ISearchService> iSearchServiceMock;
        private readonly List<Document> expected = new List<Document>() { new Document("1", "hello") };

        

        public SearchControllerTest()
        {
            iSearchServiceMock = new Mock<ISearchService>();
            iSearchServiceMock.Setup(r => r.SearchQuery(Constant.trueQuery)).Returns(expected);
            iSearchServiceMock.Setup(r => r.SearchQuery(Constant.serverErrorQuery)).Throws(new ElasticServerException(""));
            iSearchServiceMock.Setup(r => r.SearchQuery(Constant.apiErrorQuery)).Throws(new ElasticApiException(""));
            iSearchServiceMock.Setup(r => r.SearchQuery(Constant.clientErrorQuery)).Throws(new ElasticClientException(""));
        }


        [Fact]
        public void SearchElasticTest()
        {
            var searchController = new SearchController(iSearchServiceMock.Object);
            var actual = searchController.Search(Constant.trueQuery);

            Assert.IsType<OkObjectResult>(actual);

            var objectResult = (OkObjectResult)actual;
            Assert.Equal(objectResult.Value, expected);
        }

        [Fact]
        public void SearchElasticServerError()
        {
            var searchController = new SearchController(iSearchServiceMock.Object);
            var actual = searchController.Search(Constant.serverErrorQuery);
            Assert.IsType<ObjectResult>(actual);
            var objectResult = (ObjectResult)actual;
            Assert.Equal(Constant.serverErrorStatusCode, objectResult.StatusCode);
        }

        [Fact]
        public void SearchElasticClientError()
        {
            var searchController = new SearchController(iSearchServiceMock.Object);
            var actual = searchController.Search(Constant.clientErrorQuery);
            Assert.IsType<ObjectResult>(actual);
            var objectResult = (ObjectResult)actual;
            Assert.Equal(Constant.clientErrorStatusCode, objectResult.StatusCode);
        }

        [Fact]
        public void SearchElasticApiError()
        {
            var searchController = new SearchController(iSearchServiceMock.Object);
            var actual = searchController.Search(Constant.apiErrorQuery);
            Assert.IsType<ObjectResult>(actual);
            var objectResult = (ObjectResult)actual;
            Assert.Equal(Constant.apiErrorStatusCode, objectResult.StatusCode);
        }
    }
}