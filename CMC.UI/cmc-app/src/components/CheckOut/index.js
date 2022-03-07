import { faShippingFast } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Button, CircularProgress, Grid } from "@mui/material";
import axios from "../axios";
import React, { useEffect, useState, useContext } from "react";
import NumberFormat from "react-number-format";
import { BasketContext } from "../../contexts/BasketContext";
import { CurrencyContext } from "../../contexts/CurrencyContext";
import BasketItem from "./BasketItem/BasketItem";
import "./CheckOut.css";
import ThankYou from "./ThankYou/ThankYou";

const CheckOut = (props) => {
  const [loading, setLoading] = useState(true);
  const [checkOutResult, setCheckOutResult] = useState();
  const [orderId, setOrderId] = useState();

  const basketContext = useContext(BasketContext);
  const currencyContext = useContext(CurrencyContext);

  useEffect(() => {
    const checkOut = async () => {
      setLoading(true);
      const checkOutRequest = {
        Products: basketContext.basket.map(prod => ({ id : prod.id, quantity : prod.quantity})),
        Currency: currencyContext.currency,
      };
      try {
        const { data: response } = await axios.post(
          "/CheckOut",
          checkOutRequest
        );
        setCheckOutResult(response);
        setLoading(false);
      } catch (error) {
        console.error(error.message);
      }
    };

    checkOut();
  }, [currencyContext.currency, basketContext.basket]);

  const placeOrder = async () => {
    setLoading(true);
    try {
      const checkOutRequest = {
        Products: basketContext.basket.map(prod => ({ id : prod.id, quantity : prod.quantity})),
        Currency: currencyContext.currency,
      };
      const { data: response } = await axios.post(
        "/CheckOut/PlaceOrder",
        checkOutRequest
      );
      setOrderId(response);
      setLoading(false);
    } catch (error) {
      console.error(error.message);
    }
  };

  const reset=()=>{
    props.setCheckOut(false);
    setOrderId();
    setCheckOutResult();
    basketContext.reset();
  }

  if (basketContext.basket.length === 0) {
    props.setCheckOut(false);
  }
  return (
    <div>
      {loading && (
        <div>
          <CircularProgress />
        </div>
      )}
      {!loading && (
        orderId ? (<ThankYou orderId={orderId} reset={reset}></ThankYou>) : (<Grid
          container
          direction="column"
          spacing={2}
          className="checkout"
          alignItems="center"
          justifyContent="center"
          style={{ minHeight: "100vh" }}
        >
          {checkOutResult.products.map((item) => (
            <Grid item xs={12} key={item.id}>
              <BasketItem
                item={item}
                remove={basketContext.remove}
                add={basketContext.add}
              ></BasketItem>
            </Grid>
          ))}
          <Grid item xs={12} className="gap">
            <hr className="solid"></hr>
          </Grid>
          <Grid item xs={12} className="shipping">
            <Grid
              container
              direction="row"
              alignContent="left"
              alignItems="left"
              style={{ minWidth: "520px" }}
              className="productItem"
            >
              <Grid item xs={2}>
                <FontAwesomeIcon icon={faShippingFast} size="2x" />
              </Grid>
              <Grid item xs={6}>
                Shipping Cost
              </Grid>
              <Grid item xs={4}>
                <NumberFormat
                  value={checkOutResult.shippingCost}
                  displayType={"text"}
                  thousandSeparator={true}
                  prefix={currencyContext.currency === "EUR" ? "€" : "$"}
                />
              </Grid>
            </Grid>
          </Grid>
          <Grid item xs={12} className="gap">
            <hr className="solid"></hr>
          </Grid>
          <Grid item xs={12} className="total">
            <Grid
              container
              direction="row"
              alignContent="left"
              alignItems="left"
              style={{ minWidth: "520px" }}
              className="productItem"
            >
              <Grid item xs={2}></Grid>
              <Grid item xs={6}>
                <span>Total Cost</span>
              </Grid>
              <Grid item xs={4}>
                <NumberFormat
                  value={checkOutResult.total}
                  displayType={"text"}
                  thousandSeparator={true}
                  prefix={currencyContext.currency === "EUR" ? "€" : "$"}
                />
              </Grid>
            </Grid>
          </Grid>
          <Grid item xs={12} className="buttons">
            <Button
              variant="contained"
              className="cancel"
              color="secondary"
              onClick={() => props.setCheckOut(false)}
            >
              Cancel
            </Button>
            <Button variant="contained" className="checkOut" onClick={()=>placeOrder()}>
              Place Order
            </Button>
          </Grid>
        </Grid>)
      )}
    </div>
  );
};

export default CheckOut;
