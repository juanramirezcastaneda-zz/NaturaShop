import React, { Component } from "react";

export class CustomTable extends Component {
  constructor(props) {
    super(props);
    const srcArray = props.src ? props.src : [];
    const columns = srcArray.length ? Object.keys(srcArray[0]) : null;
    this.state = { src: srcArray, columns: columns };
  }
  render() {
    return (
      <table>
        <thead key="thead">
          <tr>
            {this.state.columns.map(function(col) {
              const camelCol = col.replace(/^\w/, c => c.toUpperCase());
              return <td key={`h${col}`}>{camelCol}</td>;
            }, this)}
          </tr>
        </thead>
        <tbody key="tbody">
          {this.state.src.map(function(el) {
            return (
              <tr key={`r{$el.Id}`}>
                {this.state.columns.map(function(col) {
                  return <td key={el[col]}>{el[col]}</td>;
                })}
              </tr>
            );
          }, this)}
        </tbody>
      </table>
    );
  }
}
