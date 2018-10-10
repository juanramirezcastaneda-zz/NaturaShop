import React from "react";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";
import { actionCreators } from "../store/Products";
import { CustomTable } from "../shared/CustomTable";

class Products extends React.Component {
  componentWillMount() {
    this.props.requestProducts();
  }

  render() {
    let content = this.props.isLoading ? (
      <p>
        <em>Loading...</em>
      </p>
    ) : (
      <div>
        <CustomTable src={this.props.products} />
      </div>
    );
    return (
      <div>
        <label>Products</label>
        {content}
      </div>
    );
  }
}

export default connect(
  state => state.products,
  dispatch => bindActionCreators(actionCreators, dispatch)
)(Products);
