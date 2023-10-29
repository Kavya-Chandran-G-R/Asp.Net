using FilterSortPagination.DBContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using Sieve.Services;

namespace FilterSortPagination.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductDB db;
        private readonly SieveProcessor sieveProcessor;

        public ProductController(ProductDB _db, SieveProcessor _sieveProcessor)
        {
            db = _db;
            sieveProcessor= _sieveProcessor;
        }

        [Route("GetProduct")]
        [HttpGet]
        public async Task<IActionResult>GetProducts([FromQuery] SieveModel model)
        {
            var products = db.ProductDataContext.AsQueryable();
            products = sieveProcessor.Apply(model,products);
            return Ok(products);
        }
    }
}
