import React, { Component } from "react";
import {
  Col,
  ControlLabel,
  Form,
  FormControl,
  FormGroup,
  Label
} from "react-bootstrap";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";
import { actionCreators as customerActionCreators } from "../store/Customers";
import { actionCreators as partnersActionCreators } from "../store/Partners";

export class AddSale extends Component {
  componentDidMount() {
    this.props.requestCustomers();
    this.props.requestPartners();
  }

  render() {
    return (
      <div>
        <Label>New Sale</Label>
        <Form horizontal>
          <FormGroup controlId="nsCustomerName">
            <Col componentClass={ControlLabel} sm={2}>
              Customer Name
            </Col>
            <Col sm={10}>
              <FormControl componentClass="select" placeholder="Name">
                <option value="">Select</option>
                {this.props.customers.map(customer => {
                  return (
                    <option key={customer.id} value="">
                      {customer.name}
                    </option>
                  );
                })}
              </FormControl>
            </Col>
          </FormGroup>
          <FormGroup controlId="nsPartnerName">
            <Col componentClass={ControlLabel} sm={2}>
              Partner Name
            </Col>
            <Col sm={10}>
              <FormControl componentClass="select" placeholder="Name">
                <option value="">Select</option>
                {this.props.partners.map(partner => {
                  return (
                    <option key={partner.id} value="">
                      {partner.name}
                    </option>
                  );
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
  state => ({ ...state.customers, ...state.partners }),
  dispatch =>
    bindActionCreators(
      {
        ...customerActionCreators,
        ...partnersActionCreators
      },
      dispatch
    )
)(AddSale);
