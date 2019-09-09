import {Registration,Login,AddUser,DeleteUser,UpdateUser,ForgotPassword,GetAllUsers} from "../Entities/Config";
import {POST,GET} from "../Entities/ActionConstantName"
import makeServerSideCall from "../Entities/CommonMethods";
const userService={

    UserRegistration:function(values){
        return makeServerSideCall(values,POST,Registration);
    },
    UserLogin:function(values){
        var loginDetails={
            emailId:values.emailId,
            password:values.password
        }
   return makeServerSideCall(loginDetails,GET,Login,"login");
        },
    AddUser:function(values){ 
        return makeServerSideCall(values,POST,AddUser);
    },
    DeleteUser:function(values){
        return makeServerSideCall(values,POST,DeleteUser);
        },
    UpdateUser:function(values){
        return  makeServerSideCall(values,POST,UpdateUser);
            },
    GetAllUsers:function(values){
        return makeServerSideCall(values,GET,GetAllUsers);
                },
    RecoverPassword:function(values){
        return makeServerSideCall(values,GET,ForgotPassword);
                                }
     
}
export default userService;