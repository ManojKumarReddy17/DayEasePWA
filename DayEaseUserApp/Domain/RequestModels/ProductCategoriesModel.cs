using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RequestModels
{
    public class ProductCategoriesModel
    {
       public string StoreId { get; set; }
            public string ProductCategoryId { get; set; }
            public string ProductCategoryName { get; set; }
            public DateTime CreateDate { get; set; }
            public string CreateBy { get; set; }
            public DateTime UpdateDate { get; set; }
            public string UpdateBy { get; set; }
            public string ImageUrl { get; set; }
            public bool IsDelete { get; set; }

        
    }

}
