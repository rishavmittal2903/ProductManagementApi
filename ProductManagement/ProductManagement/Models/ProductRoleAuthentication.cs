using Newtonsoft.Json;
using ProductManagement.Entities;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http.Filters;

namespace ProductManagement.Models
{
    public class ProductRoleAuthentication : AuthorizationFilterAttribute
        {
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
                    string createdBy = JsonConvert.DeserializeObject<ProductDetails>(actionContext.Request.Content.ReadAsStringAsync().Result).createdBy;
                    // Get username  
                    string usrename = originalString.Split(':')[0];

                    // Validate role with username  
                    if (!ValidateRole(usrename, createdBy))
                    {
                        // returns unauthorized error  
                        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized,"Invalid access for this event.");
                    }
                }

                base.OnAuthorization(actionContext);
            }

            private bool ValidateRole(string userName,string createdBy)
            {
                return userName == createdBy ? true:false;
            }
        }
}