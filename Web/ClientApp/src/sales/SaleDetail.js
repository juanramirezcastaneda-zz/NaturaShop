import React, { Component } from "react";
import { connect } from "react-redux";

export class SaleDetail extends Component {
  componentDidMount() {}

  render() {
    return (
      <div>
        <h1>This is the sale detail component</h1>
      </div>
    );
  }
}

export default connect(state => state.sales)(SaleDetail);
