import React from 'react';
import SearchList from './SearchList';
import { Link } from "react-router-dom";

export default class Search extends React.Component {
	state = {
		movies: [],
		query: "",
		loading: false
	}

	handleSubmit = async e => {
		e.preventDefault();
		// window.location.assign(`/results/${this.state.query}`)
		// let q = e.target.query.value.toLowerCase();
		// let response = await fetch(`movie/search?q=${q}`);
		// let data = await response.json();
		// console.log(data);
		// this.setState({
		// 	movies: data,
		// 	query: q,
		// 	loading: false
		// });
		// this.setState({ ...this.state, loading: true })
		// console.log(this.state.loading);
	}

	handleChange = event => {
		let q = event.target.value.toLowerCase();
		this.setState({
			movies: [],
			query: q,
			loading: false
		});
	}

	handleClick = () => {
		console.log(this.props.loading)
		this.props.setLoading(true);
	}

	renderLink = () => {
		return (
			<Link to={`/results/${this.state.query}`}> 
				Search
			</Link>
		)
	}

	render() {
		return (
			<div>
				<form onSubmit={this.handleSubmit}>
					<input type="text" name="query" onChange={this.handleChange} 
						value={this.state.query} />
					{/* <input type="submit" /> */}
					<button type="submit" disabled={this.props.loading}>
						{this.props.loading ? <span>Submit</span> : this.renderLink() }
					</button>
				</form>
				{/* <SearchList movies={this.state.movies} /> */}
			</div>
		);
	}
}
