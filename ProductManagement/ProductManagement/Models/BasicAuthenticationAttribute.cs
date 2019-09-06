using ProductManagement.Interfaces;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http.Filters;

namespace ProductManagement.Models
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        private IDBContext sqlDBContext;
        public BasicAuthenticationAttribute()
        {
            sqlDBContext = SqlDBContext.DBInstance;
        }
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                // Gets header parameters  
                string authenticationString = actionContext.Request.Headers.Authorization.Parameter;
                string originalString = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationString));

                // Gets username and password  
                string usrename = originalString.Split(':')[0];
                string password = originalString.Split(':')[1];

                // Validate username and password  
                if (!ValidateUser(usrename, password))
                {
                    // returns unauthorized error  
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }

            base.OnAuthorization(actionContext);
        }

        private  bool ValidateUser(string userName,string password)
        {
            bool isUserValid = false;
            isUserValid =  sqlDBContext.CheckUserExists(userName, password).Result;
            return isUserValid;
        }
    }

}