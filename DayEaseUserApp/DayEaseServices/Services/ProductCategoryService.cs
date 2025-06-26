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
    public class ProductCategoryService : IProductCategory
    {
        private readonly IApiService _apiservice;
        public ProductCategoryService(IApiService apiservice)
        {
            _apiservice = apiservice;
        }




        public async Task<List<ProductCategoriesModel>> GetProductsByCategoryId(ProductCategoriesModel model)
        {
            string endpoint = "ProductCategory/GetProductCategoryById";
            var response = await _apiservice.PostAsync<ProductCategoriesModel, List<ProductCategoriesModel>>(endpoint, model);
            return response;
        }

        public async Task<List<ProductCategoryMapDto>> GetProductcategoByStoreId(StoreProdCategoryRequestModel model)
        {
            string endpoint = "ProductCategories/GetStoreProductCategorybyId";
            var response = await _apiservice.PostAsync<StoreProdCategoryRequestModel, List<ProductCategoryMapDto>>(endpoint, model);

            return response;
        }



        public async Task<MysqlResponse<Pagination<ProductRequestModel>>> GetProductsByStoreId(PaginationQueryInput model)
        {
            string endpoint = "Products/GetProductsByStoreId";
            var details = await _apiservice.PostAsync<PaginationQueryInput, MysqlResponse<Pagination<ProductRequestModel>>>(
                endpoint,
                model
            );
            return details;
        }


    }
}