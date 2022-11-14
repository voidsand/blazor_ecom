namespace blazor_ecom.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;

        public event Action? ProductsChanged;

        public ProductService(HttpClient http)
        {
            _http = http;
        }

        public List<Product> Products { get; set; } = new List<Product>();
        public string Message { get; set; } = "Loading products...";
        public int CurrentPage { get; set; } = 1;
        public int PageCount { get; set; } = 0;
        public string LastSearchText { get; set; } = string.Empty;

        public async Task GetProducts(string? categoryUrl = null)
        {
            var result = categoryUrl == null ?
                await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/Products/Featured") :
                await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/Categories/{categoryUrl}");
            if (result != null && result.Data != null)
                Products = result.Data;

            CurrentPage = 1;
            PageCount = 0;
            if (Products.Count == 0)
                Message = "No products found.";

            ProductsChanged?.Invoke();
        }

        public async Task<ServiceResponse<Product>> GetProduct(int productId)
        {
            var result =
                await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/Products/{productId}");
            return result;
        }

        public async Task SearchProducts(string searchText, int page)
        {
            LastSearchText = searchText;
            var result =
                await _http.GetFromJsonAsync<ServiceResponse<ProductSearchResult>>($"api/Search/{searchText}/{page}");
            if (result != null && result.Data != null)
            {
                Products = result.Data.Products;
                CurrentPage = result.Data.CurrentPage;
                PageCount = result.Data.PageCount;
            }
            if (Products.Count == 0)
                Message = "No products found.";

            ProductsChanged?.Invoke();
        }

        public async Task<List<string>> GetSearchSuggestions(string searchText)
        {
            var result =
                await _http.GetFromJsonAsync<ServiceResponse<List<string>>>($"api/SearchSuggestions/{searchText}");
            return result.Data;
        }
    }
}