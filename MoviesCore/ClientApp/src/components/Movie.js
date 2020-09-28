import React from 'react';
import style from './Movie.module.css';

export default class Movie extends React.Component {
	state = {
		title: 'Title',
		genre: 'Genre',
		story: 'Opis',
		price: 350,
		releaseDate: "2020-11-02"
	}

	changeHandler = async (event) => {
		event.preventDefault();

		let mov = {
			title: event.target.title.value,
			genre: event.target.genre.value,
			story: event.target.story.value,
			price: parseFloat(event.target.price.value),
			releaseDate: event.target.releaseDate.value
		}

		this.setState(mov);
		// console.log(mov);

		fetch("movie/add",
			{
				method: "POST",
				headers: {
					'Content-Type': 'application/json'
				},
				body: JSON.stringify(mov)
			})
			.then(res => res.json())
			.then(res => console.log(res))
			.catch(error => console.log(error))

		// for (var i = 0, len = event.target.elements.length; i < len; i++) {
		// 	console.log(event.target.elements[i].value)
		// }
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
			<form onSubmit={this.changeHandler}>
				<input className={style.formInput} type="text"
					defaultValue={this.state.title} name="title" />
				<br />
				<br />
				<label>Zanr&nbsp;</label>
				<select name="genre">
					<option>Komedija</option>
					<option>Akcioni</option>
					<option>Triler</option>
					<option>Fantazija</option>
				</select>
				<br />
				<br />
				<textarea name="story" rows="10" cols="50"
					defaultValue={this.state.story}></textarea>
				<br />
				<br />
				<input type="text" defaultValue={this.state.price} name="price" />
				<br />
				<br />
				<input type="text" defaultValue={this.state.releaseDate}
					name="releaseDate" />
				<br />
				<br />
				<input className={style.formInput} type="submit" value="Submit" />
			</form>
			<button onClick={this.getTest}>Get Test</button>
			</div>
		);
	}
}

