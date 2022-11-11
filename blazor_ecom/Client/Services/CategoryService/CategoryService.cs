﻿using blazor_ecom.Shared;

namespace blazor_ecom.Client.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _http;
        public CategoryService(HttpClient http)
        {
            _http = http;
        }

        public List<Category> Categories { get; set; } = new List<Category>();

        public async Task GetCategories()
        {
            var result =
                await _http.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/Categories");
            if (result != null && result.Data != null)
                Categories = result.Data;
        }
    }
}
