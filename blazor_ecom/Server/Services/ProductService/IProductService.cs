﻿namespace blazor_ecom.Server.Services.ProductService
{
    public interface IProductService
	{
		Task<ServiceResponse<List<Product>>> GetProducts();
		Task<ServiceResponse<Product>> GetProduct(int productId);
		Task<ServiceResponse<List<Product>>> GetProductsByCategoryUrl(string categoryUrl);
	}
}
