import React, { Component } from "react";
import { connect } from "react-redux";

export class AddSale extends Component {
  componentDidMount() {}

  render() {
    return (
      <div>
        <h1>This is the add sale component</h1>
      </div>
    );
  }
}

export default connect(state => state.sales)(AddSale);
