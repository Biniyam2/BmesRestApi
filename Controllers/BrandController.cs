using BmesRestApi.Messages.Request.Brand;
using BmesRestApi.Messages.Response.Brand;
using BmesRestApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BmesRestApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {

        private IBrandService _brandService;
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        [AllowAnonymous]
        [HttpGet(template: "{id}")]
        public ActionResult<GetBrandResponse> GetBrand(long id)
        {
            var getBrandRequest = new GetBrandRequest
            {
                Id = id
            };
            var getBrandResponse = _brandService.GetBrand(getBrandRequest);
            return getBrandResponse;
        }
        [AllowAnonymous]
        [HttpGet()]
        public ActionResult<FetchBrandResponse> GetBrands ()
        {
            var fetchBrandsRequest = new FetchBrandRequest { };
            var fetchBrandResponse = _brandService.GetBrands(fetchBrandsRequest);
            return fetchBrandResponse;
        }
        [Authorize(Roles = "Administrator")]
        [HttpDelete(template:"{id}")]
        public ActionResult<DeleteBrandResponse> DeleteBrnad(long id) 
        {
            var deleteBrandRequest = new DeleteBrandRequest
            {
                Id = id
            };
            var deletBrandResponse = _brandService.DeleteBrand(deleteBrandRequest);
            return deletBrandResponse;
        }
        [Authorize(Roles = "Administrator")]
        [HttpPut()]
        public ActionResult<UpdateBrandRespones> PutBrand(UpdateBrandRequest updateBrandRequest) 
        {
            var updateBrandRespones = _brandService.EditeBrand(updateBrandRequest);
            return updateBrandRespones;         
        }
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult<CreateBrandResponse> PostBrand (CreateBrandRequest createBrandRequest)
        {
            var createBrandResponse = _brandService.SaveBrand(createBrandRequest);
            return createBrandResponse;
        }
    }
}
