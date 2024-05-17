import React from "react";
import ReactDOM from "react-dom/client";
import { BrowserRouter } from "react-router-dom";
import App from "app/App";
import "talwind.css";
const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(

    <BrowserRouter>
        <App />
    </BrowserRouter>
  
);
