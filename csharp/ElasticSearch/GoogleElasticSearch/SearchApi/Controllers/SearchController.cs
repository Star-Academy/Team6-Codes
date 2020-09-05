using GoogleApp.Controller.Excpetion;
using Microsoft.AspNetCore.Mvc;
using SearchApi.Services;

namespace SearchApi.Controllers
{
    [Route("{controller}/{action}")]
    public class SearchController : ControllerBase
    {

        private ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        [HttpGet]
        public IActionResult Search(string query)
        {
            try
            {
                var result = searchService.SearchQuery(query);
                return Ok(result);
            }
            catch (ElasticException e)
            {
                return StatusCode(e.StatusCode, e.Message);
            }
        }
    }
}