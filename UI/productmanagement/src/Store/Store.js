import {createStore,combineReducers,applyMiddleware} from 'redux';
import productReducer from "../Reducer/ProductReducer";
import userReducer from "../Reducer/UserReducer";
import logger from 'redux-logger';
import createHistory from 'history/createBrowserHistory';
import { Router, Route, Switch } from 'react-router';
import { routerReducer, routerMiddleware } from 'react-router-redux';
const history = createHistory();
export default createStore(combineReducers({userReducer,productReducer,routing: routerReducer}),1,applyMiddleware(logger));