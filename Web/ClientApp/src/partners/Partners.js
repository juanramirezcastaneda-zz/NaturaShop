import React from "react";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";
import { actionCreators } from "../store/Partners";
import { CustomTable } from "../shared/CustomTable";

class Partners extends React.Component {
  componentWillMount() {
    this.props.requestPartners();
  }

  render() {
    let content = this.props.isLoading ? (
      <p>
        <em>Loading...</em>
      </p>
    ) : (
      <div>
        <CustomTable src={this.props.partners} prefix={"prt"} />
      </div>
    );
    return (
      <div>
        <label>Partners</label>
        {content}
      </div>
    );
  }
}

export default connect(
  state => state.partners,
  dispatch => bindActionCreators(actionCreators, dispatch)
)(Partners);
