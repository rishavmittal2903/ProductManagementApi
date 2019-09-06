using ProductManagement.Entities;
using ProductManagement.Enums;
using ProductManagement.Interfaces;
using ProductManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProductManagement.Controllers
{
    [RoutePrefix("api/UserAction")]
    [BasicAuthentication]
    public class UserController : ApiController
    {
      private  IDBContext sqlDBContext;
        public UserController(IDBContext _sqlDBContext)
        {
            sqlDBContext = _sqlDBContext;
        }
        [HttpPost]
        [Route("Login")]
        public async Task<UserDetails> Login(UserDetails userDetail)
        {
            return await sqlDBContext.Login(userDetail);
        }
        [HttpGet]
        [UserRoleAuthentication]
        [Route("DeleteUsers")]
        public async Task<bool> DeleteUsers(UserDetails userDetail)
        {
            bool isDeleted = false;
            isDeleted=  await sqlDBContext.Add_Delete_Modify_User(userDetail, (int)ActionType.DELETE);
            return isDeleted;
        }
        [HttpPost]
        [UserRoleAuthentication]
        [Route("UpdateUsers")]
        public async Task<bool> UpdateUsers(UserDetails userDetail)
        {
            bool isUpdated = false;
            isUpdated  = await sqlDBContext.Add_Delete_Modify_User(userDetail, (int)ActionType.DELETE);
            return isUpdated;
        }
        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<List<UserDetails>> GetAllUsers()
        {
            return await sqlDBContext.GetAllUsers();
        }
    }
}
