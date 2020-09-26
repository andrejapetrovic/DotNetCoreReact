USE [DBFirst.Movies];

CREATE TABLE movie(
	/* (1, 1) je autoincrement */
	id INT PRIMARY KEY IDENTITY (1, 1),
	title VARCHAR (50)  NOT NULL,
	story VARCHAR (500) NOT NULL,
	genre VARCHAR (50) NOT NULL,
	release_date DATE,
	price DECIMAL(5, 2)
);

CREATE TABLE member(
	id INT PRIMARY KEY IDENTITY (1, 1),
	name VARCHAR (30) NOT NULL,
	email VARCHAR (50) NOT NULL,
	birthdate DATE NOT NULL
);

CREATE TABLE member_movie(
	CONSTRAINT member_movie_pk PRIMARY KEY (member_id, movie_id),
	member_id INT NOT NULL CONSTRAINT FK_member FOREIGN KEY  REFERENCES member (id),
	movie_id INT NOT NULL CONSTRAINT FK_movie FOREIGN KEY REFERENCES movie (id)
)

