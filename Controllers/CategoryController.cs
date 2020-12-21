using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BmesRestApi.Messages.Request.Category;
using BmesRestApi.Messages.Response.Category;
using BmesRestApi.Services;

namespace BmesRestApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _CategoryService;
        public CategoryController(ICategoryService Category)
        {
            _CategoryService = Category;
        }
        [AllowAnonymous]
        [HttpGet(template:"{id}")]
        public ActionResult<GetCategoryResponse> GetCategory (long id) 
        {
            var getRequest = new GetCategoryRequest
            {
                Id = id
            };
            var getResponse = _CategoryService.GetCategory(getRequest);
            return getResponse;
        }
        [AllowAnonymous]
        [HttpGet()]
        public ActionResult<FetchCategoryResponse> GetCategories ( ) 
        {
            var fetchCategoryRequest = new FetchCategoryRequest();
            var getResponse = _CategoryService.GetCategories(fetchCategoryRequest);
            return getResponse;
        }
        [Authorize (Roles = "Administrator")]
        [HttpPost]
        public ActionResult<CreateCategoryResponse> PostCategory (CreateCategoryRequest createCategoryRequest) 
        {
            var getResponse = _CategoryService.SaveCategory(createCategoryRequest);
            return getResponse;
        }
        [Authorize(Roles = "Administrator")]
        [HttpPut()]
        public ActionResult<UpdateCategoryResponse> PutCategory ( UpdateCategoryRequest getRequest)
        {

            var getResponse = _CategoryService.EditeCategory(getRequest);
            return getResponse;
        }
        [Authorize(Roles = "Administrator")]
        [HttpDelete(template:"{id}")]
        public ActionResult<DeleteCategoryResponse> DeleteCategory (long id) 
        {
            var deleteCategoryRequest = new DeleteCategoryRequest
            {
                Id = id
            };

            var getResponse = _CategoryService.DeleteCategory(deleteCategoryRequest);
            return getResponse;
        }




    }
}
