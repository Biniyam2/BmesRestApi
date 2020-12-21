using BmesRestApi.Messages.Request.Brand;
using BmesRestApi.Messages.Response.Brand;


namespace BmesRestApi.Services
{
     public interface IBrandService
    {
        CreateBrandResponse SaveBrand(CreateBrandRequest brandRequest);
        UpdateBrandRespones EditeBrand(UpdateBrandRequest updatebrandRequest);
        FetchBrandResponse GetBrands(FetchBrandRequest fetchBrandRequest);
        GetBrandResponse GetBrand(GetBrandRequest getBrandRequest);
        DeleteBrandResponse DeleteBrand(DeleteBrandRequest brandRequest);
    }
}
