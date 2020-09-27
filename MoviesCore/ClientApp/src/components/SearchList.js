import React from 'react';

export default class SearchList extends React.Component {
	state = {
		movies: []
	}

	async fetchMovies() {
		let q = this.props.match.params.q;
		let response = await fetch(`movie/search?q=${q}`);
		let data = await response.json();
		this.setState({
			movies: data
		})
	}

	componentDidUpdate(prevProps) {
		if (this.props.match.params.q !== prevProps.match.params.q) {
			console.log("Update")
			this.fetchMovies();
		}
	}
	
	componentDidMount() {
		console.log("Mount");
		this.fetchMovies();
	}

	render() {
		return (
			<div>
				{this.state.movies.map((movie) =>
					<li key={movie.id}>
						{movie.title}<br />
						{movie.story}<br />
						{movie.price}<br />
						{movie.genre}<br />
						{movie.releaseDate}<br />
					</li>
				)}
			</div>
		);
	}
}
