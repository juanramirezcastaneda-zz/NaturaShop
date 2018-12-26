import React from "react";
import { connect } from "react-redux";
import { withRouter } from "react-router";
import { bindActionCreators } from "redux";
import { actionCreators } from "../store/Sales";
import { CustomTable } from "../shared/CustomTable";
import { Button } from "react-bootstrap";
import "./Sales.css";

class Sales extends React.Component {
  constructor(props) {
    super(props);
    this.redirectToAdd = this.redirectToAdd.bind(this);
  }

  componentWillMount() {
    this.props.requestSales();
    this.history = this.props.history;
  }

  redirectToAdd() {
    this.history.push("/addSale");
  }

  render() {
    let content = this.props.isLoading ? (
      <p>
        <em>Loading...</em>
      </p>
    ) : (
      <div>
        <CustomTable
          src={this.props.sales}
          prefix={"sl"}
          isLink={true}
          linkRoute={"/sales"}
        />
        <div className="add-row">
          <Button bsStyle="primary" onClick={this.redirectToAdd}>
            Add Sale
          </Button>
        </div>
      </div>
    );
    return <div>{content}</div>;
  }
}

export default withRouter(
  connect(
    state => state.sales,
    dispatch => bindActionCreators(actionCreators, dispatch)
  )(Sales)
);
