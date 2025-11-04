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
    public class ProductCategoryService(IApiService _apiservice) : IProductCategory
    {

        public async Task<List<ProductCategoriesModel>> GetProductsByCategoryId(ProductCategoriesModel model)
    => await _apiservice.PostAsync<ProductCategoriesModel, List<ProductCategoriesModel>>
       ("ProductCategory/GetProductCategoryById", model);

        public async Task<List<ProductCategoryMapDto>> GetProductcategoByStoreId(StoreProdCategoryRequestModel model)
            => await _apiservice.PostAsync<StoreProdCategoryRequestModel, List<ProductCategoryMapDto>>
               ("ProductCategories/GetStoreProductCategorybyId", model);

        public async Task<MysqlResponse<Pagination<ProductRequestModel>>> GetProductsByStoreId(PaginationQueryInput model)
            => await _apiservice.PostAsync<PaginationQueryInput, MysqlResponse<Pagination<ProductRequestModel>>>
               ("Products/GetProductsByStoreId", model);


    }
}