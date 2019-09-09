import React from 'react';
import {connect} from 'react-redux';
import{updateState} from '../Actions/UserActions';
import UserService from "../Services/UserService";
import '../Css/style.css';
import RegistrationImg from '../Images/RegistrationImg.jpg';
class Registration extends React.Component
{
    constructor()
    {
        super();
        this.firstNameRef=React.createRef();
        this.lastNameRef=React.createRef();
        this.emailIdRef=React.createRef();
        this.mobileNumberRef=React.createRef();
        this.genderRef=React.createRef();
        this.passwordRef=React.createRef();
        this.userTypeRef=React.createRef();
    }
    render()
    {
        var that=this;
        return(
            <div className="container">
                <div className="signup-content">
                    <div className="signup-img">
                        <img src={RegistrationImg} alt="background image"/>
                    </div>
                    <div className="signup-form">
                        <form method="POST" className="register-form" id="register-form">
                            <h2>User Registration Form</h2>
                            <div className="form-row">
                                <div className="form-group">
                                    <label for="name">First Name :</label>
                                    <input type="text" name="firstName" ref={that.firstNameRef} id="firstName" required onChange={()=>that.props.changeState(that.firstNameRef)}/>
                                </div>
                                </div>
                                <div className="form-row">
                                <div className="form-group">
                                    <label for="name">Last Name :</label>
                                    <input type="text" name="lastName" ref={that.lastNameRef} id="lastName" required onChange={()=>that.props.changeState(that.lastNameRef)}/>
                                </div>
                                </div>
                                <div className="form-row">
                                <div className="form-group">
                                    <label for="name">Email-Id :</label>
                                    <input type="email" name="emailId" ref={that.emailIdRef} id="emailId" required onChange={()=>that.props.changeState(that.emailIdRef)}/>
                                </div>
                                </div>
                                <div className="form-row">
                                <div className="form-group">
                                    <label for="father_name">Mobile Number :</label>
                                    <input type="text" name="mobileNumber" ref={that.mobileNumberRef} id="mobileNumber" required onChange={()=>that.props.changeState(that.mobileNumberRef)}/>
                                </div>
                                </div>
                           <div className="form-row">
                           <div className="form-group">
                                <label for="birth_date">Pasword :</label>
                                <input type="password" name="password" ref={that.passwordRef} onChange={()=>that.props.changeState(that.passwordRef)} id="password"/>
                            </div>
                               </div>
                            <div className="form-row">
                                <div className="form-group">
                                    <label for="state">Gender :</label>
                                    <div className="form-select">
                                        <select name="gender" id="gender" ref={that.genderRef} onChange={()=>that.props.changeState(that.genderRef)}>
                                            <option value="" disabled={true} selected={true}>Select Gender</option>
                                            <option value="male">Male</option>
                                            <option value="female">Female</option>
                                        </select>
                                        <span className="select-icon"><i className="zmdi zmdi-chevron-down"></i></span>
                                    </div>
                                </div>
                            </div>
                            <div className="form-row">
                            <div className="form-group">
                                <label for="usertype">User Type :</label>
                                <div className="form-select">
                                    <select name="userType" id="userType" ref={that.userTypeRef} onChange={()=>that.props.changeState(that.userTypeRef)}>
                                        <option value="" disabled={true} selected={true}>Select user type</option>
                                        <option value="Admin">Admin</option>
                                        <option value="Normal">Normal</option>
                                    </select>
                                    <span className="select-icon"><i className="zmdi zmdi-chevron-down"></i></span>
                                </div>
                            </div>
                            </div>
                            <div className="form-submit">
                            <span className="txtFont fltlft"  onClick={that.props.history.goBack}>Go Back</span>
                            <input type="submit" value="Register" className="submit" name="submit" id="submit" onClick={()=>that.props.RegisterData(that.props.user)}/>
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
    var that=this;
    return {
        RegisterData:(data)=>{
            UserService.UserRegistration(data).then(function(response){
console.log(JSON.stringify(response));
if(sessionStorage.getItem("LoginFlag"))
{
    that.props.history.goBack();
}
else
{
    this.props.history.push("/SignIn");

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
export default connect(mapStateToProps,mapDispatchToProps)(Registration);
