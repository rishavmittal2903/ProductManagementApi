using ProductManagement.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductManagement.Interfaces
{
   public interface IDBContext
    {
        /// <summary>
        /// Manage user data as per flag 
        /// </summary>
        /// <param name="userDetails"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        Task<bool> Add_Delete_Modify_User(UserDetails userDetails, int flag);
        /// <summary>
        /// Return user details after succesfull login
        /// </summary>
        /// <param name="userDetails"></param>
        /// <returns></returns>
        Task<UserDetails> Login(UserDetails userDetails);
        /// <summary>
        /// Return all users
        /// </summary>
        /// <returns></returns>
        Task<List<UserDetails>> GetAllUsers();
        /// <summary>
        /// Return all available products
        /// </summary>
        /// <returns></returns>
        Task<List<ProductDetails>> GetAllProducts();
        /// <summary>
        /// Manage product as per flag
        /// </summary>
        /// <param name="productDetails"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        Task<bool> Add_Delete_Modify_Products(ProductDetails productDetails, int flag);
        /// <summary>
        /// Check whether user is already exists or not
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<bool> CheckUserExists(string userName, string password="");
        /// <summary>
        /// Store request and response in data table
        /// </summary>
        /// <param name="logMetadata"></param>
        /// <returns></returns>
        Task<bool> SendLogData(LogMetadata logMetadata);
        /// <summary>
        /// Store request and response in data table
        /// </summary>
        /// <param name="logMetadata"></param>
        /// <returns></returns>
        Task<string> GetPassword(string userName);
    }
}
