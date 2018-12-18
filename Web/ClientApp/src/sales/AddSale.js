import React, { Component } from "react";
import {
  Col,
  ControlLabel,
  Form,
  FormControl,
  FormGroup
} from "react-bootstrap";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";
import { actionCreators } from "../store/Customers";

export class AddSale extends Component {
  componentDidMount() {
    this.props.requestCustomers();
  }

  render() {
    return (
      <div>
        <Form horizontal>
          <FormGroup controlId="nsCustomerName">
            <Col componentClass={ControlLabel} sm={2}>
              Customer Name
            </Col>
            <Col sm={10}>
              <FormControl componentClass="select" placeholder="Name">
                <option value="">Select</option>
                {this.props.customers.map(customer => {
                  return <option value="">{customer.name}</option>;
                })}
              </FormControl>
            </Col>
          </FormGroup>
          <FormGroup controlId="nsCustomerEmail">
            <Col componentClass={ControlLabel} sm={2}>
              Customer Email
            </Col>
            <Col sm={10}>
              <FormControl placeholder="Email" />
            </Col>
          </FormGroup>
        </Form>
      </div>
    );
  }
}

export default connect(
  state => state.customers,
  dispatch => bindActionCreators(actionCreators, dispatch)
)(AddSale);
