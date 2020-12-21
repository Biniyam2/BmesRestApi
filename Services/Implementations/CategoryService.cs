using BmesRestApi.Messages.Request.Category;
using BmesRestApi.Messages.Response.Category;
using BmesRestApi.Messages;
using BmesRestApi.Repositories;


namespace BmesRestApi.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly MessageMapper _messageMapper;
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _messageMapper = new MessageMapper();
        }
        public DeleteCategoryResponse DeleteCategory(DeleteCategoryRequest categoryRequest)
        {
            var category = _categoryRepository.FindCategoryById(categoryRequest.Id);
            _categoryRepository.DeleteCategory(category);
            var categoryDto = _messageMapper.MapToCategroyDto(category);
            return new DeleteCategoryResponse
            { 
              Category = categoryDto
            };

        }

        public UpdateCategoryResponse EditeCategory(UpdateCategoryRequest updateCategoryRequest)
        {
            UpdateCategoryResponse updateCategoryResponse = null;
            if (updateCategoryRequest.Category.IdDto == updateCategoryRequest.Id)
            {
                var category = _messageMapper.MapToCategroy(updateCategoryRequest.Category);
                _categoryRepository.EditCategory(category);
                var categoryDto = _messageMapper.MapToCategroyDto(category);
                return new UpdateCategoryResponse
                {

                };
            }
            return updateCategoryResponse;
        }

        public FetchCategoryResponse GetCategories(FetchCategoryRequest fetchCategoryRequest)
        {
            var categorys = _categoryRepository.GetAllCategory();
            var categoryDto = _messageMapper.MapToCategoryDtos(categorys);
            return new FetchCategoryResponse
            {
                Categories = categoryDto
            };
        }

        public GetCategoryResponse GetCategory(GetCategoryRequest getCategoryRequest)
        {
            var cateogry = _categoryRepository.FindCategoryById(getCategoryRequest.Id);
            var categoryDto = _messageMapper.MapToCategroyDto(cateogry);
            return new GetCategoryResponse
            {
                Category = categoryDto
            };
        }

        public CreateCategoryResponse SaveCategory(CreateCategoryRequest categoryRequest)
        {
            var category = _messageMapper.MapToCategroy(categoryRequest.Category);
            _categoryRepository.SaveCategory(category);
            var categoryDto = _messageMapper.MapToCategroyDto(category);
            return new CreateCategoryResponse
            {
                Category = categoryDto
            };
        }
    }
}
