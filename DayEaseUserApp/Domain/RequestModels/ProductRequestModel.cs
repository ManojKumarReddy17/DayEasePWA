using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RequestModels
{
    public class ProductRequestModel
    {       
        public string StoreId { get; set; }
  
        public string ProductId { get; set; }

        public string CategoryId { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string ProductImg { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsEnable { get; set; }
        public bool IsDelete { get; set; }
    }
}
