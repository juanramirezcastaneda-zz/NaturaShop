import React, { Component } from "react";

export class CustomTable extends Component {
  constructor(props) {
    super(props);
    this.state = { src: props.src };
    console.log(props.src);
    console.log(Object.keys(props.src.shift()));
  }
  render() {
    return (
      <table>
        <thead>
          <tr>
            <th> the drag drop table</th>
          </tr>
        </thead>
        <tbody>
          {this.state.src.map(el => (
            <tr>
              <td>{el.Id}</td>
              <td>{el.Name}</td>
              <td>{el.PhonerNumber}</td>
            </tr>
          ))}
        </tbody>
      </table>
    );
  }
}
