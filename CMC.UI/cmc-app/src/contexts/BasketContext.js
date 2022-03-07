import React, { useState } from "react";

export const BasketContext = React.createContext();

function BasketContextProvider(props) {
  const [basket, setBasket] = useState([]);
  const add = (product) => {
    const products = basket.filter((item) => item.id !== product.id);
    if (products.length !== basket.length) {
      product.quantity += 1;
    } else {
      product.quantity = 1;
    }
    setBasket([...products, product]);
  };
  const remove = (id) => {
    const products = basket.filter((item) => item.id !== id);
    const deletingProduct = basket.find((item) => item.id === id);
    if (deletingProduct.quantity > 1) {
      deletingProduct.quantity -= 1;
      setBasket([...products, deletingProduct]);
    } else {
      setBasket([...products]);
    }
  };
  const reset = () => {
    setBasket([]);
  };
  return (
    <BasketContext.Provider
      value={{ basket: basket, add: add, remove: remove, reset: reset }}
    >
      {props.children}
    </BasketContext.Provider>
  );
}

export default BasketContextProvider;
