import React from 'react';
import {connect} from 'react-redux';
import{updateState} from '../Actions/UserActions';
import UserService from "../Services/UserService";
class Products extends React.Component
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
                    <table>
                         <thead>
                             <tr>
<th>ProductId</th>
<th>ProductPrice</th>
<th>ProductName</th>
<th>Action</th>
                            </tr>
                        </thead>
                        <tbody>
                            {that.props.product.products.map(function(data,key){

                                return(
                                    <tr>
<td>{data.productId}</td>
<td>{data.productPrice}</td>
<td>{data.productName}</td>
<td><input type="button" value="RemoveProduct"/></td>
                                        </tr>
                                )
                            })}
                            </tbody>
                         </table>
                    </div>
                </div>
            </div>
    
        </div>
                    
                
        )
    }
}

const mapStateToProps=(state)=>{
    return {
        user:state.userReducer,
        product:state.productReducer   
    }
}

const mapDispatchToProps=(dispatch)=>{
    return {
            changeState:(data)=>{
            dispatch(updateState(data));
        }
    }
}
export default connect(mapStateToProps,mapDispatchToProps)(Products);
