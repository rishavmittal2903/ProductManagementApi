import React from 'react';
import {connect} from 'react-redux';
import signinimg from '../Images/signup-image.jpg';
import{updateState,Login_Account} from '../Actions/UserActions';
import UserService from "../Services/UserService";
class SignIn extends React.Component
{
    constructor()
    {
        super();
        this.emailRef=React.createRef();
        this.passRef=React.createRef();
    }
    render()
    {
        var that=this;
        return(
            <div className="main">
            <div className="container">
                <div className="signup-content boxShdw">
                    <div className="signup-img brdrrght">
                        <img src={signinimg} className="pdnglft20" alt="background image"/>
                    </div>
                    <div className="signup-form">
                        <div className="register-form" id="register-form">
                            <h2>Sign In</h2>
                            <div className="form-group">
                                <label for="email">Email ID :</label>
                                <input type="email" name="email" ref={that.emailRef} id="emailId" onChange={()=>that.props.changeState(that.emailRef)} />
                            </div>
                            <div className="form-group">
                                <label for="password">Password :</label>
                                <input type="password" name="password" ref={that.passRef} id="password" onChange={()=>that.props.changeState(that.passRef)}/>
                            </div>
                            <div className="form-group hght20">
                               <span className="txtFont fltlft" onClick={()=>that.props.history.push("/ForgotPassword")}>Forgot password?</span>
                               <span className="txtFont fltrght" onClick={()=>that.props.history.push("/Registration")}>New Registration</span>

                            </div>
                            <div className="form-submit">
                                <input type="button" value="Sign In" className="submit" name="signin" id="signin" onClick={()=>that.props.LoginData(that.props.user)} />
                            </div>
                        </div>
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
        LoginData:(data)=>{
            UserService.UserLogin(data).then(function(response){
if(response!=null&&response!=undefined)
{
dispatch(Login_Account(JSON.parse(response)));
} 
}).catch(function(error){
console.log(error);
            })
        },
        changeState:(data)=>{
            dispatch(updateState(data));
        }
    }
}
export default connect(mapStateToProps,mapDispatchToProps)(SignIn);
