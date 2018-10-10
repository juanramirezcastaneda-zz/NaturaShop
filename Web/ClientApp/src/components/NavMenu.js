import React, { Component } from "react";
import { Link } from "react-router-dom";
import { Glyphicon, Nav, Navbar, NavItem } from "react-bootstrap";
import { LinkContainer } from "react-router-bootstrap";
import "./NavMenu.css";

export class NavMenu extends Component {
  displayName = NavMenu.name;

  render() {
    return (
      <Navbar inverse fixedTop fluid collapseOnSelect>
        <Navbar.Header>
          <Navbar.Brand>
            <Link to={"/"}>Shop</Link>
          </Navbar.Brand>
          <Navbar.Toggle />
        </Navbar.Header>
        <Navbar.Collapse>
          <Nav>
            <LinkContainer to={"/"} exact>
              <NavItem>
                <Glyphicon glyph="home" /> Home
              </NavItem>
            </LinkContainer>
            <LinkContainer to={"/customers"}>
              <NavItem>
                <Glyphicon glyph="th-list" /> Customers
              </NavItem>
            </LinkContainer>
            <LinkContainer to={"/sales"}>
              <NavItem>
                <Glyphicon glyph="th-list" /> Sales
              </NavItem>
            </LinkContainer>
            <LinkContainer to={"/partners"}>
              <NavItem>
                <Glyphicon glyph="th-list" /> Partners
              </NavItem>
            </LinkContainer>
            <LinkContainer to={"/products"}>
              <NavItem>
                <Glyphicon glyph="th-list" /> Products
              </NavItem>
            </LinkContainer>
          </Nav>
        </Navbar.Collapse>
      </Navbar>
    );
  }
}
