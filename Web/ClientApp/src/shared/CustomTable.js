import React, { Component } from "react";
import "./CustomTable.css";

export class CustomTable extends Component {
  constructor(props) {
    super(props);
    const srcArray = props.src ? props.src : [];
    const columns = srcArray.length ? Object.keys(srcArray[0]) : [];
    const prefix = props.prefix ? props.prefix : "ct";
    this.state = { src: srcArray, columns: columns, prefix: prefix };
  }
  render() {
    return (
      <table>
        <thead key="thead">
          <tr>
            {this.state.columns.map(function(col) {
              const camelCol = col.replace(/^\w/, c => c.toUpperCase());
              return <th key={`h${this.state.prefix}${col}`}>{camelCol}</th>;
            }, this)}
          </tr>
        </thead>
        <tbody key="tbody">
          {this.state.src.map(function(el) {
            return (
              <tr key={`r${this.state.prefix + el.id}`}>
                {this.state.columns.map(function(col) {
                  return <td key={`${col}`}>{el[col]}</td>;
                })}
              </tr>
            );
          }, this)}
        </tbody>
      </table>
    );
  }
}
