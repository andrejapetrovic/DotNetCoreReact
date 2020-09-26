import React from 'react';

export default class Search extends React.Component {
	state = {
		movies: [],
		query: "",
		loading: true
	}

	search = async e => {
		e.preventDefault();
		// var ret = this.state.list
		// 	.filter(x =>e
		// 		x.toLowerCase().includes(
		// 		e.target.query.value.toLowerCase()))
		// console.log(ret);
		//
		let q = e.target.query.value.toLowerCase();
		let response = await fetch(`movie/search?q=${q}`);
		let data = await response.json();
		console.log(data);
		this.setState({
			movies: data,
			query: q,
			loading: false
		});
	}

	render() {
		return (
			<div>
				<form onSubmit={this.search}>
					<input type="text" name="query" />
					<input type="submit" />
				</form>
				{this.state.query}
				{this.state.movies.map((movie) =>
					<li key={movie.id}>{movie.title}</li>
				)}
			</div>
		);
	}
}
