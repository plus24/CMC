import "./App.css";
import Products from "./components/Products/Products";
import Navbar from "./components/NavBar";
import { useState } from "react";
import BasketContextProvider from "./contexts/BasketContext";
import CheckOut from "./components/CheckOut";
import CurrencyContextProvider from "./contexts/CurrencyContext";
import { AppBar, Toolbar, Typography } from "@mui/material";
import { Box } from "@mui/system";

function App() {
  const [isCheckOut, setCheckOut] = useState(false);
  const toggleCheckOut = () => {
    setCheckOut(!isCheckOut);
  };

  return (
    <CurrencyContextProvider>
      <BasketContextProvider className="App">
        <Box sx={{ flexGrow: 1 }}>
          <AppBar position="static">
          <Toolbar>
          <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
            CMC Market
          </Typography>
          <Navbar
            toggleCheckOut={toggleCheckOut}
            isCheckOut={isCheckOut}
          ></Navbar>
        </Toolbar>
          </AppBar>
        </Box>
        <section className="body">
          {isCheckOut ? (
            <CheckOut setCheckOut={setCheckOut} ></CheckOut>
          ) : (
            <Products></Products>
          )}
        </section>
      </BasketContextProvider>
    </CurrencyContextProvider>
  );
}

export default App;
