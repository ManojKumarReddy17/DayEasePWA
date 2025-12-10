using Domain.RequestModels;
using Domain.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayEaseServices.Services.IServices
{
    public interface IProductCategory

    {

        Task<List<ProductCategoryMapDto>> GetProductcategoByStoreId(StoreProdCategoryRequestModel model);

        Task<MysqlResponse<Pagination<ProductRequestModel>>> GetProductsByStoreId(PaginationQueryInput model);

        Task<List<ProductCategoriesModel>> GetProductsByCategoryId(ProductCategoriesModel model);

        Task<MysqlResponse<Pagination<ProductRequestModel>>> SearchProductsAsync(ProductSearchModel request);

    }
}