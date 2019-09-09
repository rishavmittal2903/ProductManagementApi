import {AddProduct,DeleteProduct,UpdateProduct,GetAllProducts} from "../Entities/ActionConstantName";

const productState=[{
    productId:"",
    productName:"",
    productPrice:"",
    createdBy:""
}]
const productReducer=(state=productState,action)=>{
    switch(action.type)
    {
        case AddProduct:{

        }
        case DeleteProduct:{
            
        }
        case UpdateProduct:{
            
        }
        case GetAllProducts:{
            
        }
    }
    return state;
}
export default productReducer;