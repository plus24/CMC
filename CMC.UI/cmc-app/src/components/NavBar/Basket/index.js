import React, { useContext } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faBagShopping } from "@fortawesome/free-solid-svg-icons";
import { BasketContext } from "../../../contexts/BasketContext";
import { Badge, Button, Card, Grid } from "@mui/material";
import BasketItem from "../../CheckOut/BasketItem/BasketItem";
import "./Basket.css";

function Basket(props) {
  const basketContext = useContext(BasketContext);
  const sum = basketContext.basket.reduce((a, b) => a + (b['quantity'] || 0), 0)

  return (
    <div className="basket">
      <Badge badgeContent={sum} color="warning">
        <FontAwesomeIcon icon={faBagShopping} size="2x"/>
      </Badge>
      {sum > 0 && (
        <Card className="basketItems">
          <Grid
            container
            direction="column"
            spacing={2}
            className="checkout"
            alignItems="center"
            justifyContent="center"
          >
            {basketContext.basket.map((item) => (
              <Grid item xs={12} key={item.id}>
                <BasketItem
                  item={item}
                  remove={basketContext.remove}
                  add={basketContext.add}
                ></BasketItem>
              </Grid>
            ))}
            <Grid item xs={12} className="buttons">
              <Button variant="contained" className="checkOut"  onClick={()=>props.toggleCheckOut()}>
                Check Out
              </Button>
            </Grid>
          </Grid>
        </Card>
      )}
    </div>
  );
}

export default Basket;
