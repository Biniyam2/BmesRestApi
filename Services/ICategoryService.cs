using BmesRestApi.Messages.Request.Category;
using BmesRestApi.Messages.Response.Category;


namespace BmesRestApi.Services
{
    public interface ICategoryService
    {
        CreateCategoryResponse SaveCategory(CreateCategoryRequest categoryRequest);
        UpdateCategoryResponse EditeCategory(UpdateCategoryRequest updateCategoryRequest);
        FetchCategoryResponse GetCategories(FetchCategoryRequest fetchCategoryRequest);
        GetCategoryResponse GetCategory(GetCategoryRequest getCategoryRequest);
        DeleteCategoryResponse DeleteCategory(DeleteCategoryRequest categoryRequest);
    }
}
