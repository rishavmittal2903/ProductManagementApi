using ProductManagement.Entities;
using ProductManagement.Enums;
using ProductManagement.Interfaces;
using ProductManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProductManagement.Controllers
{
    [BasicAuthentication]
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        private IDBContext sqlDBContext;
        public ProductController(IDBContext _sqlDBContext)
        {
            sqlDBContext = _sqlDBContext;
        }
        [HttpPost]
        [Route("AddProduct")]
        public async Task<bool> AddProducts(ProductDetails products)
        {
            bool isRegistered = false;
            isRegistered = await sqlDBContext.Add_Delete_Modify_Products(products, (int)ActionType.ADD);
            return isRegistered;
        }
        [ProductRoleAuthentication]
        [HttpPost]
        [Route("DeleteProduct")]
        public async Task<bool> DeleteProduct(ProductDetails products)
        {
            bool isDeleted = false;
            isDeleted = await sqlDBContext.Add_Delete_Modify_Products(products, (int)ActionType.DELETE);
            return isDeleted;
        }
        [ProductRoleAuthentication]
        [HttpPost]
        [Route("UpdateProduct")]
        public async Task<bool> UpdateProduct(ProductDetails products)
        {
            bool isUpdated = false;
            isUpdated = await sqlDBContext.Add_Delete_Modify_Products(products, (int)ActionType.UPDATE);
            return isUpdated;
        }
        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<List<ProductDetails>> GetAllProducts()
        {
            return await sqlDBContext.GetAllProducts();
        }
    }
}
