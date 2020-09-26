import React from 'react';
import '../App.css';
import { Link } from "react-router-dom";

export default class Home extends React.Component {

	render() {
		return (
			<nav>
				<ul>
					<li><a href="/">Home</a></li>
					<li><Link to="/new">New Movie</Link></li>
					<li><Link to="/info">Info</Link></li>
				</ul>
			</nav>
		);
	}
}


