import { MenuItem, Select } from "@mui/material";
import React, { useContext } from "react";
import { CurrencyContext } from "../../../contexts/CurrencyContext";
import "./Currencies.css";

function Currencies() {

  const currencyContext = useContext(CurrencyContext);
  return (
    <Select
    labelId="demo-simple-select-label"
    id="demo-simple-select"
    value={currencyContext.currency}
    label="Currency"
    onChange={currencyContext.setCurrency}
    className="currencies"
  >
    <MenuItem value='AUD'>AUD</MenuItem>
    <MenuItem value='USD'>USD</MenuItem>
    <MenuItem value='EUR'>EUR</MenuItem>
  </Select>
  );
}

export default Currencies;
