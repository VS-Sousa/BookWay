using BookWayApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace BookWayApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {

        [HttpGet]
        public JsonResult GetGenres()
        {
            return new JsonResult(1);
        }
    }
}
