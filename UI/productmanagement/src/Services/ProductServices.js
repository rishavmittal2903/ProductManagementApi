import {AddProduct,DeleteProduct,UpdateProduct,GetAllProduct} from "../Entities/Config";
import {POST,GET} from "../Entities/ActionConstantName";
import makeServerSideCall from "../Entities/CommonMethods";
const productService={

    Add_Product:function(values){
   return makeServerSideCall(values,POST,AddProduct);
    },
    Delete_Product:function(values){
        return makeServerSideCall(values,POST,DeleteProduct);
        },
    ModifyProduct:function(values){ 
        return  makeServerSideCall(values,POST,UpdateProduct);
    },
    Gell_All_products:function(values){
        return  makeServerSideCall(values,GET,GetAllProduct);
        }
}
export default productService;