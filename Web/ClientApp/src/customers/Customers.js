import React, { Component } from "react";

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

  renderCustomerTable(customers) {
    return (
      <table className="table">
        <thead>
          <tr>
            <th>Id</th>
            <th>Name</th>
            <th>Number</th>
          </tr>
        </thead>
        <tbody>
          {customers.map(customer => (
            <tr key={customer.id}>
              <td>{customer.id}</td>
              <td>{customer.name}</td>
              <td>{customer.phoneNumber}</td>
            </tr>
          ))}
        </tbody>
      </table>
    );
  }

  render() {
    let content = this.state.loading ? (
      <p>
        <em>Loading...</em>
      </p>
    ) : (
      this.renderCustomerTable(this.state.customers)
    );

    return (
      <div>
        <h1>Customers</h1>
        {content}
      </div>
    );
  }
}
