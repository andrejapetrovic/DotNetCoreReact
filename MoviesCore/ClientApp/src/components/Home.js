import React from 'react';
import Movie from './Movie';
import Search from './Search';
import Info	from './Info';
import '../App.css';
import { Route } from "react-router-dom";
import SearchList from './SearchList';

export default class Home extends React.Component {
	state = {
		loading_movies: false
	}

	setLoading = (isLoading) => { 
		this.setState({ ...this.state, loading_movies: isLoading })
	}

	render() {
		return (
			<div className="App">
				<Search 
					loading={this.state.loading_movies}
					setLoading={(isLoading) => this.setLoading(isLoading)}
				/>
				<header className="App-header">
					<Route path="/new" component={Movie} />
					<Route path="/info" component={Info} />
					<Route
						path="/results/:q"
						render={(props) => (
							<SearchList { ...props }
								setLoading={(isLoading) => this.setLoading(isLoading)}
							/>
						)}
					/>
					{/* <Route path="/results/:q" component={SearchList} /> */}
				</header>
			</div>
		);
	}
}

