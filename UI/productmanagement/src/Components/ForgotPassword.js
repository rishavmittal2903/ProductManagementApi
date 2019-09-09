import React from 'react';
import {connect} from 'react-redux';
import signinimg from '../Images/signup-image.jpg';
import{updateState} from '../Actions/UserActions';
import UserService from "../Services/UserService";
import { goBack } from 'react-router-redux' 
class ForgotPass extends React.Component
{
    constructor()
    {
        super();
        this.emailRef=React.createRef();
    }
    render()
    {
        var that=this;
        return(
           
            <div className="container">
                <div className="signup-content boxShdw">
                    <div className="signup-img brdrrght">
                        <img src={signinimg} alt="background image"/>
                    </div>
                    <div className="signup-form">
                        <form method="POST" className="register-form" id="register-form">
                            <h2>Forgot Password</h2>
                          
                            
                           
                            <div className="form-group">
                                <label for="email">Email ID :</label>
                                <input type="email" name="email" ref={that.emailRef} id="emailId" onChange={()=>that.props.updateState(that.emailRef)} />
                            </div>
                            <div className="form-group hght20" onClick={that.props.history.goBack}>
                               <span className="txtFont fltlft">Go Back</span>
                            </div>
                            <div className="form-submit">
                                <input type="submit" value="Validate" className="submit" name="forgotpass" id="forgotPassword" onClick={()=>that.props.ForgotPassEvent(that.user.emailId)} />
                            </div>
                        </form>
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
        ForgotPassEvent:(data)=>{
            UserService.RecoverPassword(data).then(function(response){
            console.log(JSON.stringify(response));
            this.props.history.push("/SignIn")
            }).catch(function(error){
            console.log(error);
            })
        },
        changeState:(data)=>{
            dispatch(updateState(data));
        }
    }
}
export default connect(mapStateToProps,mapDispatchToProps)(ForgotPass);
