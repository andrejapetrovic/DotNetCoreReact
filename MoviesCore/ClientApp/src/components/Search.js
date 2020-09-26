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
		let response = await fetch("movie/all");
		let data = await response.json();
		console.log(data);
		this.setState({
			movies: data,
			query: '',
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
				{this.state.movies.map((movie) =>
					<li key={movie.id}>{movie.title}</li>
				)}
			</div>
		);
	}
}
