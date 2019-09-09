import {AddProduct,DeleteProduct,UpdateProduct,GetAllProducts} from "../Entities/ActionConstantName";

const productState=[{
    productId:"",
    productName:"",
    productPrice:"",
    createdBy:"",
    products:[]
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
            state={
                ...state,
                products:[...state.products,action.payload]
            }
        }
    }
    return state;
}
export default productReducer;