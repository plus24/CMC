import React from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faThumbsUp } from "@fortawesome/free-solid-svg-icons";
import './ThankYou.css';
import { Button } from "@mui/material";

const ThankYou = (props) => {
  return (<div className="thankyou">
            <h1>THANK YOU!</h1>
            <i><FontAwesomeIcon icon={faThumbsUp} size="5x"/></i>
            <h3>Order reference number</h3>
            <h3>{props.orderId}</h3>
            <Button
              variant="contained"
              className="cancel"
              color="secondary"
              onClick={() => props.reset()}
            >
              Back
            </Button>
          </div>);
}

export default ThankYou;
