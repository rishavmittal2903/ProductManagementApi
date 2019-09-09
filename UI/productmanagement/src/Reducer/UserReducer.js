import {Registration,Login,AddUser,DeleteUser,UpdateUser,ForgotPassword,GetAllusers,stateUpdate,flagUpdate} from "../Entities/ActionConstantName";

const userState={
    firstName:"",
    lastName:"",
    emailId:"",
    mobileNumber:"",
    gender:"",
    password:"",
    userType:0
}
const userReducer=(state=userState,action)=>{
    switch(action.type)
    {
        case Registration:{

            break;
        }
        case Login:{
            
            state={
                ...state,
                firstName:action.payload.firstName,
                lastName:action.payload.lastName,
                emailId:action.payload.emailId,
                mobileNumber:action.payload.mobileNumber,
                gender:action.payload.gender,
                password:action.payload.password,
                userType:action.payload.userType
            }
            break;
        }
        case AddUser:{
            
            break;
        }
        case DeleteUser:{
            
            break;
        }
        case UpdateUser:{
            
            break;
        }
        case ForgotPassword:{
            
            break;
        }
        case GetAllusers:{
            
            break;
        }
        case stateUpdate:{
          var id=action.payload.current.id;
          var value=action.payload.current.value;
          switch(id)
          {
              case "firstName":{state={...state,firstName:value}; break;}
              case "lastName":{state={...state,lastName:value}; break;}
              case "emailId":{state={...state,emailId:value}; break;}
              case "mobileNumber":{state={...state,mobileNumber:value}; break;}
              case "gender":{state={...state,gender:value}; break;}
              case "password":{state={...state,password:value}; break;}
              case "userType":{state={...state,userType:value}; break;}
          }
            break;
        }
      
    }
    return state;
}
export default userReducer;