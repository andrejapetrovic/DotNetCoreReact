import React from 'react';
import Movie from './Movie';
import Search from './Search';
import Info	from './Info';
import '../App.css';
import { Route } from "react-router-dom";

export default class Home extends React.Component {

	render() {
		return (
			<div className="App">
				<Search />
				<header className="App-header">
					<Route path="/new" component={Movie} />
					<Route path="/info" component={Info} />
				</header>
			</div>
		);
	}
}

