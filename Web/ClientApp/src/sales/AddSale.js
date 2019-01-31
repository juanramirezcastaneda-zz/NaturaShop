import React, { Component } from "react";
import {
  Button,
  Col,
  ControlLabel,
  Form,
  FormControl,
  FormGroup
} from "react-bootstrap";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";
import { actionCreators as customerActionCreators } from "../store/Customers";
import { actionCreators as partnersActionCreators } from "../store/Partners";
import { actionCreators as productsActionCreators } from "../store/Products";

export class AddSale extends Component {
  constructor() {
    super();
    this.state = {
      selectedProduct: "",
      selectedCustomer: "",
      selectedPartner: "",
      selectedQuantity: 0,
      selectedEmail: ""
    };
  }

  componentDidMount() {
    this.props.requestCustomers();
    this.props.requestPartners();
    this.props.requestProducts();
    this.saveNewSale = this.saveNewSale.bind(this);
    this.handleProductChange = this.handleProductChange.bind(this);
    this.handleCustomerChange = this.handleCustomerChange.bind(this);
    this.handlePartnerChange = this.handlePartnerChange.bind(this);
    this.handleEmailChange = this.handleEmailChange.bind(this);
    this.handleQuantityChange = this.handleQuantityChange.bind(this);
  }

  saveNewSale() {
    const productQuantities = {};
    productQuantities[this.state.selectedProduct] = this.state.selectedQuantity;
    const saleViewModel = JSON.stringify({
      Sale: {
        CustomerId: this.state.selectedCustomer,
        PartnerId: this.state.selectedPartner,
        ProductIdsQuantities: productQuantities
      }
    });

    fetch("http://localhost:63165/api/Sales", {
      method: "POST",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json"
      },
      body: saleViewModel
    }).then(res => {
      console.log("Done");
      console.log(res);
    });
  }

  handleProductChange(evt) {
    this.setState({ selectedProduct: evt.target.value });
  }

  handleCustomerChange(evt) {
    this.setState({ selectedCustomer: evt.target.value });
  }

  handlePartnerChange(evt) {
    this.setState({ selectedPartner: evt.target.value });
  }

  handleEmailChange(evt) {
    this.setState({ selectedEmail: evt.target.value });
  }

  handleQuantityChange(evt) {
    this.setState({ selectedQuantity: evt.target.value });
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
              <FormControl
                componentClass="select"
                placeholder="Name"
                onChange={this.handleCustomerChange}
              >
                <option value="">Select</option>
                {this.props.customers.map(customer => {
                  return (
                    <option key={customer.id} value={customer.id}>
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
              <FormControl
                componentClass="select"
                placeholder="Name"
                onChange={this.handlePartnerChange}
              >
                <option value="">Select</option>
                {this.props.partners.map(partner => {
                  return (
                    <option key={partner.id} value={partner.id}>
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
              <FormControl
                type="email"
                placeholder="Email"
                onChange={this.handleEmailChange}
              />
            </Col>
          </FormGroup>
          <FormGroup controlId="nsProductName">
            <Col componentClass={ControlLabel} sm={2}>
              Product Name
            </Col>
            <Col sm={10}>
              <FormControl
                componentClass="select"
                placeholder="Product Name"
                onChange={this.handleProductChange}
              >
                <option value="">Select</option>
                {this.props.products.map(product => {
                  return (
                    <option key={product.id} value={product.id}>
                      {product.name}
                    </option>
                  );
                })}
              </FormControl>
            </Col>
          </FormGroup>
          <FormGroup controlId="nsProductQuantity">
            <Col componentClass={ControlLabel} sm={2}>
              Product Quantity
            </Col>
            <Col sm={2}>
              <FormControl
                type="number"
                placeholder="Product Quantity"
                onChange={this.handleQuantityChange}
              />
            </Col>
          </FormGroup>
          <FormGroup className="add-row">
            <Col sm={2}>
              <Button bsStyle="primary" onClick={this.saveNewSale}>
                Create Sale
              </Button>
            </Col>
          </FormGroup>
        </Form>
      </div>
    );
  }
}

export default connect(
  state => ({ ...state.customers, ...state.partners, ...state.products }),
  dispatch =>
    bindActionCreators(
      {
        ...customerActionCreators,
        ...partnersActionCreators,
        ...productsActionCreators
      },
      dispatch
    )
)(AddSale);
