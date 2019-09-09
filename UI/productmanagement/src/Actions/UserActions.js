import {Registration,Login,AddUser,DeleteUser,UpdateUser,ForgotPassword,GetAllusers,stateUpdate}  from "../Entities/ActionConstantName"

export function Register_User(data)
{
    return {
        type:Registration,
        payload:data
    }
}
export function Login_Account(data)
{
    return {
        type:Login,
        payload:data
    }
}
export function Add_Users(data)
{
    return {
        type:AddUser,
        payload:data
    }
}
export function Delete_Users(data)
{
    return {
        type:DeleteUser,
        payload:data
    }
}
export function Update_Users(data)
{
    return {
        type:UpdateUser,
        payload:data
    }
}
export function Forgot_Password(data)
{
    return {
        type:ForgotPassword,
        payload:data
    }
}
export function Get_All_Users(data)
{
    return {
        type:GetAllusers,
        payload:data
    }
}
export function updateState(data)
{
    return {
        type:stateUpdate,
        payload:data
    }
}

