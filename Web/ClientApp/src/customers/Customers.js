import React from "react";
import { css } from "react-emotion";
import { connect } from "react-redux";
import BounceLoader from "react-spinners/BounceLoader";
import { bindActionCreators } from "redux";
import { CustomTable } from "../shared/CustomTable";
import { actionCreators } from "../store/Customers";

const override = css`
  display: block;
  margin: 0 auto;
`;

class Customers extends React.Component {
  componentWillMount() {
    this.props.requestCustomers();
  }

  render() {
    let content = this.props.isLoading ? (
      <div className="sweet-loading">
        <BounceLoader
          className={override}
          sizeUnit={"px"}
          size={80}
          color={"#2c2c2c"}
          loading={this.props.loading}
        />
      </div>
    ) : (
      <div>
        <CustomTable src={this.props.customers} prefix={"ctm"} />
      </div>
    );
    return <div>{content}</div>;
  }
}

export default connect(
  state => state.customers,
  dispatch => bindActionCreators(actionCreators, dispatch)
)(Customers);
