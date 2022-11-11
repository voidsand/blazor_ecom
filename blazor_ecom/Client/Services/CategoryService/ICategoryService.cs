namespace blazor_ecom.Client.Services.CategoryService
{
    public interface ICategoryService
	{
        List<Category> Categories { get; set; }
        Task GetCategories();
    }
}

