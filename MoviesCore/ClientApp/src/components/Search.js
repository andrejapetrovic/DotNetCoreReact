import React from 'react';
import SearchList from './SearchList';
import { Link } from "react-router-dom";

export default class Search extends React.Component {
	state = {
		movies: [],
		query: "",
		loading: true
	}

	search = async e => {
		e.preventDefault();
		// let q = e.target.query.value.toLowerCase();
		// let response = await fetch(`movie/search?q=${q}`);
		// let data = await response.json();
		// console.log(data);
		// this.setState({
		// 	movies: data,
		// 	query: q,
		// 	loading: false
		// });
	}

	handleChange = event => {
		let q = event.target.value.toLowerCase();
		this.setState({
			movies: [],
			query: q,
			loading: false
		});
	}

	render() {
		return (
			<div>
				<form onSubmit={this.search}>
					<input type="text" name="query" onChange={this.handleChange} 
						value={this.state.query} />
					{/* <input type="submit" /> */}
					<button type="submit">
						<Link to={`/results/${this.state.query}`}>
							Search
						</Link>
					</button>
				</form>
				{this.state.query}
				{/* <SearchList movies={this.state.movies} /> */}
			</div>
		);
	}
}
