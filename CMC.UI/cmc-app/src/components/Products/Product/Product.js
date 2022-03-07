import { faCartPlus } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Button } from "@mui/material";
import React, { useContext } from "react";
import NumberFormat from "react-number-format";
import { BasketContext } from "../../../contexts/BasketContext";
import { CurrencyContext } from "../../../contexts/CurrencyContext";
import './Product.css';

const Product=(props)=>{
  const basketContext = useContext(BasketContext);
  const currencyContext = useContext(CurrencyContext);

  const productImage=props.product.image?props.product.image:"https://www.pacificfoodmachinery.com.au/media/catalog/product/placeholder/default/no-product-image-400x400_5.png";
  return <div className="card">
  <img src={productImage} alt={props.product.name}></img> 
  <h3>{props.product.name}</h3>
  <p className="price"><NumberFormat
            value={props.product.price}
            displayType={"text"}
            thousandSeparator={true}
            decimalScale={2}
            prefix={currencyContext.currency === "EUR" ? "€" : "$"}
          /></p>
  <p>{props.product.description}</p>
  <p>
  <Button onClick={()=>basketContext.add(props.product)}>
        <FontAwesomeIcon icon={faCartPlus} size="2x" style={{marginRight:"10px"}}/>Add to Cart</Button></p>
</div>
}

export default Product;
