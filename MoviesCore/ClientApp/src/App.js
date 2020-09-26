import React from 'react';
import './App.css';
import Home from './components/Home';
import Nav from './components/Nav';
import { BrowserRouter as Router, Route, Link } from "react-router-dom";

function App() {
  return (
		<Router>
			<main>
				<Nav />
				<Home />
			 </main>
			</Router>
  );
}

export default App;
