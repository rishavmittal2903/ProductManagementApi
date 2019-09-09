import {AddProduct,DeleteProduct,UpdateProduct,GetAllProducts}  from "../Entities/ActionConstantName"

export function Add_Products(data)
{
    return {
        type:AddProduct,
        payload:data
    }
}
export function Delete_Products(data)
{
    return {
        type:DeleteProduct,
        payload:data
    }
}
export function Update_Product(data)
{
    return {
        type:UpdateProduct,
        payload:data
    }
}
export function Get_All_Products(data)
{
    return {
        type:GetAllProducts,
        payload:data
    }
}
