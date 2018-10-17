import React from "react";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";
import { actionCreators } from "../store/Customers";
import { CustomTable } from "../shared/CustomTable";

class Customers extends React.Component {
  componentWillMount() {
    this.props.requestCustomers();
  }

  render() {
    let content = this.props.isLoading ? (
      <p>
        <em>Loading...</em>
      </p>
    ) : (
      <div>
        <CustomTable src={this.props.customers} prefix={"ctm"} />
      </div>
    );
    return (
      <div>
        <label>Customers</label>
        {content}
      </div>
    );
  }
}

export default connect(
  state => state.customers,
  dispatch => bindActionCreators(actionCreators, dispatch)
)(Customers);
