using Newtonsoft.Json;
using ProductManagement.Entities;
using ProductManagement.Enums;
using ProductManagement.Interfaces;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace ProductManagement.Models
{
    public class UserRoleAuthentication : AuthorizationFilterAttribute
        {
        private IDBContext dBContext;
        public UserRoleAuthentication()
        {
            dBContext = SqlDBContext.DBInstance;
        }
            public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
            {
                  
                    int userType = JsonConvert.DeserializeObject<UserDetails>(actionContext.Request.Content.ReadAsStringAsync().Result).userType;
                    string emailId= JsonConvert.DeserializeObject<UserDetails>(actionContext.Request.Content.ReadAsStringAsync().Result).emailId;
                // Get username  
                // Validate role with username  
                if (!ValidateRole(userType))
                    {
                        // returns unauthorized error  
                        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized,"User do not have access for this operation.");
                    }
                base.OnAuthorization(actionContext);
            }
        private bool ValidateRole(int userType)
            {
                return userType ==(int) UserType.ADMIN ? true:false ;
            }
        }
}