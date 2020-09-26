import React from 'react';
import style from './Movie.module.css';

export default class Movie extends React.Component {
	state = {
		title: 'Title',
		genre: 'Genre',
		description: 'Opis',
		price: 350,
		releaseDate: "2020-11-02"
	}

	changeHandler = async (event) => {
		event.preventDefault();

		// const response = await fetch("https://")
		let mov = {
			title: event.target.title.value,
			genre: event.target.genre.value,
			description: event.target.desc.value,
			price: event.target.price.value,
			releaseDate: event.target.releaseDate.value
		}

		this.setState(mov);
		// console.log(mov);

		// fetch("https://localhost:44373/Movie/Add",
		// 	{
		// 		method: "POST",
		// 		body: JSON.stringify(mov)
		// 	})
		// 	.then(res => res.json())
		// 	.then(res => console.log(res))
		// 	.catch(error => console.log(error))

		// for (var i = 0, len = event.target.elements.length; i < len; i++) {
		// 	console.log(event.target.elements[i].value)
		// }
	}

	getTest = async (event) => {
		fetch("https://localhost:44373/Movie/GetMovie",
			{
				method: "GET"
			})
			.then(res => res.json())
			.then(res => {
				res.ReleaseDate = this.parseDate(res.ReleaseDate);
				console.log(res);
			})
			.catch(error => {
				console.log(error);
			})
	}

	parseDate = (stamp) => {
				//parsiranje datuma iz timestampa, mislim da je bolje to raditi server side
				var split = stamp.split("(")[1]
				split = split.substring(0, split.length - 2);
				var d = new Date(parseInt(split));
				return d.getDay() + ". " + d.getMonth() + ". " + d.getFullYear(); 
	}

	render() {
		return (
			<div>
				{this.state.title}
				{this.state.genre}
				{this.state.description}
				{this.state.price}
				{this.state.releaseDate}
			<form onSubmit={this.changeHandler}>
				<input className={style.formInput} type="text"
					defaultValue={this.state.title} name="title" />
				<br />
				<label>Zanr </label>
				<select name="genre">
					<option>Komedija</option>
					<option>Akcioni</option>
					<option>Triler</option>
				</select>
				<br />
				<textarea name="desc" rows="10" cols="50"
					defaultValue={this.state.description}></textarea>
				<br />
				<input type="text" defaultValue={this.state.price} name="price" />
				<br />
				<input type="text" defaultValue={this.state.releaseDate}
					name="releaseDate" />
				<br />
				<input className={style.formInput} type="submit" value="Submit" />
			</form>
			<button onClick={this.getTest}>Get Test</button>
			</div>
		);
	}
}

