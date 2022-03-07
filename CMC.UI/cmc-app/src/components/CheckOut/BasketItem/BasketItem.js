import { Avatar, Button, ButtonGroup, Grid, ListItemText } from "@mui/material";
import React, { useContext } from "react";
import "./BasketItem.css";
import NumberFormat from "react-number-format";
import { CurrencyContext } from "../../../contexts/CurrencyContext";

const BasketItem=(props)=>{
  const currencyContext = useContext(CurrencyContext);
  return (
    <Grid
      container
      direction="row"
      alignContent="left"
      alignItems="left"
      style={{ minWidth: "520px" }}
      className="productItem"
    >
      <Grid item xs={1}>
        <Avatar alt={props.item.name} src={props.item.image} />
      </Grid>
      <Grid item xs={6}>
        <ListItemText primary={props.item.name} />
      </Grid>
      <Grid item xs={2}>
        <ListItemText>
          <NumberFormat
            value={props.item.price}
            displayType={"text"}
            thousandSeparator={true}
            prefix={currencyContext.currency === "EUR" ? "€" : "$"}
          />
        </ListItemText>
      </Grid>
      <Grid item xs={2}>
        <ButtonGroup size="small" aria-label="small outlined button group">
        <Button onClick={() => props.add(props.item)}>+</Button>
        <Button className="quantity" disabled>{props.item.quantity}</Button>
        <Button onClick={() => props.remove(props.item.id)}>-</Button>
      </ButtonGroup>
      </Grid>
    </Grid>
  );
}

export default BasketItem;
