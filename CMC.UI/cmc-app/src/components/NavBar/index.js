import React from "react";
import Basket from "./Basket";
import Currencies from "./Currencies";
import "./Navbar.css";

function Navbar(props) {
  return (
    <div className="rightNav">
      {!props.isCheckOut && (
        <div className="basket">
          <Basket toggleCheckOut={props.toggleCheckOut}></Basket>
        </div>
      )}
      <div className="currencies">
        <Currencies></Currencies>
      </div>
    </div>
  );
}

export default Navbar;
