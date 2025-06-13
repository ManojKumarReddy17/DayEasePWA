using Domain.RequestModels;
using Domain.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayEaseServices.Services.IServices
{
      public  interface IProductCategory
      {
        Task<List<CategoryRequest>> GetProductcategoByStoreId(CategoryRequest model);

        Task<MysqlResponse<Pagination<ProductRequestModel>>> GetProductsByStoreId(PaginationQueryInput model);

        //Task<List<ProductCategoriesModel>> GetProductsByStoreId(StoreProdCategoryRequestModel model);
        


      }
}
