import React, { useState } from "react";

export const CurrencyContext = React.createContext();

function CurrencyContextProvider(props) {
  const [currency, setCurrency] = useState(props.currency?props.currency:"AUD");

  const changeCurrency = (event) => {
    setCurrency(event.target.value);
  };
  return (
    <CurrencyContext.Provider
      value={{ currency: currency, setCurrency: changeCurrency }}
    >
      {props.children}
    </CurrencyContext.Provider>
  );
}

export default CurrencyContextProvider;
