using DayEaseServices.Services.IServices;
using Domain.RequestModels;
using Domain.ResponseModels;
using Registration.IApiService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace DayEaseServices.Services
{
     public class ProductCategoryService:IProductCategory
    {
        private readonly IApiService _apiservice;
        public ProductCategoryService(IApiService apiservice)
        {
            _apiservice = apiservice;
        }


        public async Task<List<CategoryRequest>> GetProductcategoByStoreId(CategoryRequest model)
        {
            string endpoint = "ProductCategories/GetStoreProductCategorybyId";
            var response = await _apiservice.GetProductCategoriesByStoreId<CategoryRequest, List<CategoryRequest>>(endpoint, model);
           
            return response;
        }



        //public async Task<List<ProductCategoriesModel>> GetProductsByStoreId(StoreProdCategoryRequestModel model)
        //{
        //    string endpoint = "Products/GetProductsByStoreId";

        //    var jsonResponse = await _apiservice.GetProductByStoreId<StoreProdCategoryRequestModel, string>(endpoint, model);

        //    var response = JsonSerializer.Deserialize<List<ProductCategoriesModel>>(jsonResponse, new JsonSerializerOptions
        //    {
        //        PropertyNameCaseInsensitive = true
        //    });

        //    return response!;
        //}
        public async Task<MysqlResponse<Pagination<ProductRequestModel>>> GetProductsByStoreId(PaginationQueryInput model)
        {
            string endpoint = "Products/GetProductsByStoreId";
            var details = await _apiservice.PostPageAsync<PaginationQueryInput, MysqlResponse<Pagination<ProductRequestModel>>>(
                endpoint,
                model
            );
            return details;
        }

    }
}
