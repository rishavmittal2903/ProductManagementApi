import React from 'react';
import ReactDOM from 'react-dom';
import './Css/style.css';
import {Provider} from "react-redux";
import AdminPage from "./Components/AdminPage";
import SignIn from "./Components/SignIn";
import Registration from "./Components/Registration";
import ForgotPassword from "./Components/ForgotPassword";
import Users from "./Components/users";
import Products from "./Components/Products";
import createHistory from 'history/createBrowserHistory';
import { Router, Route, Switch } from 'react-router';
import store from "./Store/Store";
const history = createHistory();
ReactDOM.render(
<Provider store={store}>
   <Router history={history}>
      <Switch>
      <Route exact path="/" component={SignIn} />
         <Route path="/Registration" component={Registration} />
         <Route path="/ForgotPassword" component={ForgotPassword} />
         <Route path="/SignIn" component={SignIn} />
         <Route path="/Admin" component={AdminPage} />
         <Route path="/Users" component={Users} />
         <Route path="/Products" component={Products} />
         <Route path="/*" component={() => 'NOT FOUND'} />
      </Switch>
   </Router>
</Provider>,

document.getElementById('root'));
