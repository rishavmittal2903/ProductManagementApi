import {AddProduct,DeleteProduct,UpdateProduct,GetAllProduct} from "../Entities/Config";
import {POST,GET} from "../Entities/ActionConstantName";
import makeServerSideCall from "../Entities/ActionConstantName";
const productService={

    Add_Product:function(values){
    makeServerSideCall(values,POST,AddProduct);
    },
    Delete_Product:function(values){
    makeServerSideCall(values,POST,DeleteProduct);
        },
    ModifyProduct:function(values){ 
    makeServerSideCall(values,POST,UpdateProduct);
    },
    Gell_All_products:function(values){
    makeServerSideCall(values,GET,GetAllProduct);
        }
}
export default productService;