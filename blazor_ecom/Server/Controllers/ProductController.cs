using blazor_ecom.Server.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace blazor_ecom.Server.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("Products")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts()
        {
            var result = await _productService.GetProducts();
            return Ok(result);
        }

        [HttpGet("Products/{productId}")]
        public async Task<ActionResult<ServiceResponse<Product>>> GetProduct(int productId)
        {
            var result = await _productService.GetProduct(productId);
            return Ok(result);
        }

        [HttpGet("Categories/{categoryUrl}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductsByCategoryUrl(string categoryUrl)
        {
            var result = await _productService.GetProductsByCategoryUrl(categoryUrl);
            return Ok(result);
        }

        [HttpGet("Search/{searchText}/{page}")]
        public async Task<ActionResult<ServiceResponse<ProductSearchResult>>> SearchProducts(string searchText, int page)
        {
            var result = await _productService.SearchProducts(searchText.Trim(), page);
            return Ok(result);
        }

        [HttpGet("SearchSuggestions/{searchText}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetSearchSuggestions(string searchText)
        {
            var result = await _productService.GetSearchSuggestions(searchText.Trim());
            return Ok(result);
        }

        [HttpGet("Products/Featured")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetFeaturedProducts()
        {
            var result = await _productService.GetFeaturedProducts();
            return Ok(result);
        }
    }
}
