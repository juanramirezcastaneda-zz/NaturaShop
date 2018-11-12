import React from "react";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";
import { actionCreators } from "../store/Sales";
import { CustomTable } from "../shared/CustomTable";

class Sales extends React.Component {
  componentWillMount() {
    this.props.requestSales();
  }

  render() {
    let content = this.props.isLoading ? (
      <p>
        <em>Loading...</em>
      </p>
    ) : (
      <div>
        <CustomTable src={this.props.sales} prefix={"sl"} />
      </div>
    );
    return <div>{content}</div>;
  }
}

export default connect(
  state => state.sales,
  dispatch => bindActionCreators(actionCreators, dispatch)
)(Sales);
