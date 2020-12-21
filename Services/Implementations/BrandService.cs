
using BmesRestApi.Repositories;
using BmesRestApi.Messages;
using BmesRestApi.Messages.Response.Brand;
using BmesRestApi.Messages.Request.Brand;
using System;

namespace BmesRestApi.Services.Implementations
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private MessageMapper _messageMapper;

        public BrandService (IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
            _messageMapper = new MessageMapper();
        }

        public CreateBrandResponse SaveBrand (CreateBrandRequest brandRequest)
        {
            var createBrandResponse = new CreateBrandResponse();
            var brand = _messageMapper.MapToBrand(brandRequest.brand);
            try
            {
                _brandRepository.SaveBrand(brand);
                var brandDto = _messageMapper.MapToBrandDto(brand);
                createBrandResponse.Brand = brandDto;
                createBrandResponse.Messages.Add(item:"Successfully saved the Brand");
                createBrandResponse.StatusCode = System.Net.HttpStatusCode.Created;
            }
            catch(Exception e)
            {
                var error = e.ToString();
                createBrandResponse.Messages.Add(error);
                createBrandResponse.StatusCode = System.Net.HttpStatusCode.InternalServerError;
            }
 
            return createBrandResponse;
        }
        public FetchBrandResponse GetBrands (FetchBrandRequest fetchBrandRequest)
        {
            var brand = _brandRepository.GetAllBrand();
            var brandDto = _messageMapper.MapToBrandDtos(brand);

            return new FetchBrandResponse
            { 
               Brands = brandDto
            };
        }
        public GetBrandResponse GetBrand  (GetBrandRequest getBrandRequest)
        {
            GetBrandResponse getBrandResponse = null;
            if(getBrandRequest.Id > 0)
            { 
              var brand = _brandRepository.FindBrandById(getBrandRequest.Id);
              var brandDto = _messageMapper.MapToBrandDto(brand);
              getBrandResponse = new GetBrandResponse
              { 
                Brand = brandDto
              };
            }
            return getBrandResponse;
        }
      
        public DeleteBrandResponse DeleteBrand (DeleteBrandRequest brandRequest)
        {
            var brand = _brandRepository.FindBrandById(brandRequest.Id);
            _brandRepository.DeleteBrand(brand);
            var brandDto = _messageMapper.MapToBrandDto(brand);
            return new DeleteBrandResponse
            {
                Brand = brandDto
            };
        }

        public UpdateBrandRespones EditeBrand(UpdateBrandRequest updatebrandRequest)
        {
            UpdateBrandRespones updateBrandRespones = null;
            if (updatebrandRequest.Id == updatebrandRequest.Brand.IdDto)
            {
                var brand = _messageMapper.MapToBrand(updatebrandRequest.Brand);
                _brandRepository.EditBrand(brand);
                var brandDto = _messageMapper.MapToBrandDto(brand);
                return new UpdateBrandRespones
                {

                };
            }
            return updateBrandRespones;
        }
    }
}
