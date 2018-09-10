import React, { Component } from "react";
import { CustomTable } from "../shared/CustomTable";

export class Customers extends Component {
  constructor(props) {
    super(props);
    this.state = { customers: [], loading: true };

    fetch("api/Customers")
      .then(response => response.json())
      .then(data => {
        this.setState({ customers: data, loading: false });
      });
  }

  render() {
    let content = this.state.loading ? (
      <p>
        <em>Loading...</em>
      </p>
    ) : (
      <div>
        <CustomTable src={this.state.customers} />
      </div>
    );

    return (
      <div>
        <h1>Customers</h1>
        {content}
      </div>
    );
  }
}
