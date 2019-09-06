using System;
using System.Data;

namespace ProductManagement.Entities
{
    public class ProductDetails
    {
        public string productId { get; set; }
        public string productName { get; set; }
        public double productPrice { get; set; }
        public string createdBy { get; set; }
        public static ProductDetails Fill(IDataRecord record)
        {
            ProductDetails productDetails = new ProductDetails()
            {
                productId = record["productId"].ToString(),
                productName = record["productName"].ToString(),
                productPrice = Convert.ToInt64(record["productPrice"]),
                createdBy = record["createdBy"].ToString()
            };
            return productDetails;
        }
    }
}