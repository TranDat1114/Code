import { useState } from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import "./App.css";
import Home from "./pages/Home";
import Catagories from "./pages/Catagories";

function App() {
    const [count, setCount] = useState(0);

    return (
        <div className="App">
            <BrowserRouter>
                <Routes>
                    <Route path="/" element={<Home />} />
                    <Route path="/home" element={<Home />} />
                    <Route path="/catagories" element={<Catagories />} />
                </Routes>
            </BrowserRouter>
        </div>
    );
}

export default App;
