using ProductManagement.Enums;
using ProductManagement.Interfaces;
using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProductManagement.Entities
{

    [RoutePrefix("api/UserManageData")]
    public class UserManageController : ApiController
    {
        private IDBContext sqlDBContext;
        private IMailActions mailAction;
        public UserManageController(IDBContext _sqlDBContext,IMailActions _mailAction)
        {
            sqlDBContext = _sqlDBContext;
            mailAction = _mailAction;
        }
        [HttpPost]
        [Route("Registration")]
        public async Task<bool> Registration(UserDetails userDetail)
        {
            bool isRegistered = false;
            if (sqlDBContext.CheckUserExists(userDetail.emailId).Result)
            {
                isRegistered = await sqlDBContext.Add_Delete_Modify_User(userDetail, (int)ActionType.ADD);
            }
            return isRegistered;
        }
        [HttpGet]
        [Route("RecoverPassword")]
        public async Task<string> ForgotPassword(string userName)
        {
            bool isUserExists = false;
            int env;
            string response = string.Empty;
            isUserExists = await sqlDBContext.CheckUserExists(userName);
            int.TryParse(ConfigurationManager.AppSettings["environment"],out env);
            if (isUserExists&& (env == (int)Enums.Environment.PRODUCTION))
            {
                mailAction.sendMail(userName);
                response = "Password sent successfully.";
            }
            else
            {
                response = await sqlDBContext.GetPassword(userName);
            }
            return response;
        }
    }
}
