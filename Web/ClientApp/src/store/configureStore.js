import { applyMiddleware, combineReducers, compose, createStore } from "redux";
import thunk from "redux-thunk";
import logger from "redux-logger";
import { routerReducer, routerMiddleware } from "react-router-redux";
import * as Customers from "./Customers";
import * as Partners from "./Partners";
import * as Products from "./Products";
import * as Sales from "./Sales";

export default function configureStore(history, initialState) {
  const reducers = {
    customers: Customers.reducer,
    partners: Partners.reducer,
    products: Products.reducer,
    sales: Sales.reducer
  };

  const middleware = [thunk, routerMiddleware(history), logger];

  // In development, use the browser's Redux dev tools extension if installed
  const enhancers = [];
  const isDevelopment = process.env.NODE_ENV === "development";
  if (
    isDevelopment &&
    typeof window !== "undefined" &&
    window.devToolsExtension
  ) {
    enhancers.push(window.devToolsExtension());
  }

  const rootReducer = combineReducers({
    ...reducers,
    routing: routerReducer
  });

  return createStore(
    rootReducer,
    initialState,
    compose(
      applyMiddleware(...middleware),
      ...enhancers
    )
  );
}
