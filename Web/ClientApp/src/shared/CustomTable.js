import React, { Component } from "react";
import { Link } from "react-router-dom";
import "./CustomTable.css";

export class CustomTable extends Component {
  constructor(props) {
    super(props);
    const srcArray = props.src ? props.src : [];
    const isLinkId = props.isLink ? props.isLink : false;
    const linkRoute = props.linkRoute ? props.linkRoute : "";
    const columns = srcArray.length ? Object.keys(srcArray[0]) : [];
    const prefix = props.prefix ? props.prefix : "ct";
    this.state = {
      src: srcArray,
      columns: columns,
      prefix: prefix,
      isLinkId: isLinkId,
      linkRoute: linkRoute
    };
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
            function hasIdColumn(col) {
              return col === "id";
            }
            const idIndex = this.state.columns.findIndex(hasIdColumn, this);
            const isLinkId = idIndex !== -1 && this.state.isLinkId;

            return (
              <tr key={`r${this.state.prefix + el.id}`}>
                {this.state.columns.map((col, index) => {
                  return (
                    <td key={`${col}`}>
                      {isLinkId && idIndex === index ? (
                        <Link to={`${this.state.linkRoute}/${el[col]}`}>
                          {el[col]}
                        </Link>
                      ) : (
                        el[col]
                      )}
                    </td>
                  );
                })}
              </tr>
            );
          }, this)}
        </tbody>
      </table>
    );
  }
}
