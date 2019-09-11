import axios from "axios";
import $ from "jquery";
var successfunc=function(response)
{
return response;
}
var failurefunc=function(error)
{
console.log(error);
}
 function convertIntoBase64(data)
{
  var credentials = btoa(data.emailId + ':' + data.password);
  var basicAuth = 'Basic ' + credentials;
  return basicAuth;
}
function convertIntoUserObject(data)
{
    var userDetail={
        firstName:data.firstName,
        lastName:data.firstName,
        emailId:data.emailId,
        mobileNumber:data.mobileNumber,
        gender:data.gender,
        password:data.password,
        userType:parseInt(data.userType)
    }
    return (userDetail);

}
 export default function makeServerSideCall(values,methodType,url,requestType)
{
    var promiseObject=new Promise(
        function(resolve,reject)
        {
            var headers = {'Authorization': convertIntoBase64(values)}

            $.ajax({
                type: methodType,
                url:url,
                dataType: "jsonp",
                beforeSend: function (xhr){ 
                    xhr.setRequestHeader(headers);
                },
                success: function (msg) {
                  resolve(successfunc(msg));
                },
                error: function(error){
                    reject(failurefunc(error));
                },
        
                data:requestType!="login"?(convertIntoUserObject(values)):values
            });
        }
    )

   return promiseObject;
}