import React from 'react';
import {connect} from 'react-redux';
import{updateState} from '../Actions/UserActions';
import UserService from "../Services/UserService";
class Users extends React.Component
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
<th>FirstName</th>
<th>LastName</th>
<th>EmailId</th>
<th>Gender</th>
<th>MobileNumber</th>
<th>Action</th>
                            </tr>
                        </thead>
                        <tbody>
                            {that.props.user.users.map(function(data,key){

                                return(
                                    <tr>
<td>{data.firstName}</td>
<td>{data.lastName}</td>
<td>{data.emailId}</td>
<td>{data.gender}</td>
<td>{data.mobileNumber}</td>
<td><input type="button" value="RemoveUser"/></td>


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
        user:state.userReducer   
    }
}

const mapDispatchToProps=(dispatch)=>{
    return {
       
        changeState:(data)=>{
            dispatch(updateState(data));
        }
    }
}
export default connect(mapStateToProps,mapDispatchToProps)(Users);
