import React, { Component } from "react";

export class CustomTable extends Component {
  constructor(props) {
    super(props);
    const srcArray = props.src ? props.src : [];
    this.state = { src: srcArray };
  }
  render() {
    return (
      <table>
        <thead key="thead">
          <tr>
            <th> the drag drop table</th>
          </tr>
        </thead>
        <tbody key="tbody">
          {this.state.src.map(function(el) {
            return (
              <tr key={`r{$el.Id}`}>
                <td key={el.id}>{el.id}</td>
                <td key={el.name}>{el.name}</td>
                <td key={el.phoneNumber}>{el.phoneNumber}</td>
              </tr>
            );
          }, this)}
        </tbody>
      </table>
    );
  }
}
