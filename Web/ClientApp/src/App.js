import React, { Component } from "react";
import { Route } from "react-router";
import { Layout } from "./components/Layout";
import { Home } from "./components/Home";
import Customers from "./customers/Customers";
import Partners from "./partners/Partners";
import Products from "./products/Products";
import Sales from "./sales/Sales";
import SaleDetail from "./sales/SaleDetail";
import AddSale from "./sales/AddSale";

export default class App extends Component {
  render() {
    return (
      <Layout>
        <Route path="/" exact component={Home} />
        <Route path="/customers" component={Customers} />
        <Route path="/partners" component={Partners} />
        <Route path="/products" component={Products} />
        <Route path="/sales" exact component={Sales} />
        <Route path="/sales/:id" component={SaleDetail} />
        <Route path="/addSale" exact component={AddSale} />
      </Layout>
    );
  }
}
