import React from 'react';
import {connect} from 'react-redux';
import UserService from "../Services/UserService";
import ProductService from "../Services/ProductServices";
import{Get_All_Users,Login_Account} from '../Actions/UserActions';
import {Get_All_Products} from "../Actions/ProductActions";

class AdminPage extends React.Component
{
    constructor()
    {
        super();
    }
    componentWillMount()
    {
    if(sessionStorage.getItem("LoginFlag"))
   {
    this.props.history.push("/SignIn");
   }
    }
    render()
    {
        var that=this;
        return(
            <div className="main">
            <div className="container">
                <div className="signup-content boxShdw">
                    <div className="signup-img brdrrght">
                      <ul>
                          <li onClick={()=>that.props.loadAllUsers("")}>GetUsers</li>
                          <li onClick={()=>that.props.getallProducts("")}>GetProducts</li>
                          <li onClick={()=>that.props.history.push("/Registration")}>AddUsers</li>
                    </ul>
                    </div>
                </div>
            </div>
    
        </div>
                    
                
        )
    }
}

const mapStateToProps=(state)=>{
    return {
        user:state.userReducer   
    }
}

const mapDispatchToProps=(dispatch)=>{
    var that=this;
    return {
       loadAllUsers:(data)=>{ 
        UserService.GetAllUsers({}).then(function(response){
if(response!=null&&response!=undefined)
{
dispatch(Get_All_Users(JSON.parse(response)));
sessionStorage.setItem("LoginFlag",true);
that.props.history.push("/Users");  
} 
}).catch(function(error){
console.log(error);
        })
        
    },
    getallProducts:(data)=>{ 
        ProductService.Gell_All_products({}).then(function(response){
if(response!=null&&response!=undefined)
{
dispatch(Get_All_Products(JSON.parse(response)));
sessionStorage.setItem("LoginFlag",true);
that.props.history.push("/Products");  
} 
}).catch(function(error){
console.log(error);
        })
        
    }
}
}
export default connect(mapStateToProps,mapDispatchToProps)(AdminPage);
