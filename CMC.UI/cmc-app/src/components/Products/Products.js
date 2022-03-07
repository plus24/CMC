import { CircularProgress } from "@mui/material";
import React, { useContext, useEffect, useState } from "react";
import { CurrencyContext } from "../../contexts/CurrencyContext";
import axios from "../axios";
import Product from "./Product/Product";
import "./Products.css";

const Products = () => {
  const currencyContext = useContext(CurrencyContext);
  const [loading, setLoading] = useState(true);
  const [products, setProducts] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      setLoading(true);
      try {
        const { data: response } = await axios.get("/products", 
        {
          params: { page: 1, count: 10, currency: currencyContext.currency },
        });
        setProducts(response);
      } catch (error) {
        console.error(error.message);
      }
      setLoading(false);
    };

    fetchData();
  }, [currencyContext.currency]);

  return (
    <div>
      {loading && <div><CircularProgress /></div>}
      {!loading && (
        <div>
          <div className="container">
            {products.map((item) => (
              <Product key={item.id} product={item}></Product>
            ))}
          </div>
        </div>
      )}
    </div>
  );
};

export default Products;
