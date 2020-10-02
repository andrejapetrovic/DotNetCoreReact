use [MyDb]

insert into movie values ('Godfather I', 'Kum ...', 'Drama', '1980-04-15', 350.50)
insert into movie values ('Godfather II', 'Kum drugi deo ...', 'Drama', '1982-04-15', 99.00)
insert into movie values ('Ko to tamo peva', ' drugi deo ...', 'Drama', '1977-04-15', 55.34)

insert into member values ('Aki', 'aki@gmail.com', '1995-02-15')
insert into member values ('Jovana', 'jp@gmail.com', '2002-04-25')

insert into membermovies values (1, 1)
insert into membermovies values (1, 2)

insert into ticket values (20.12, '2020-07-07', 1)
insert into ticket values (20.12, '2020-07-07', 1)
insert into ticket values (31.23, '2020-03-04', 2)
insert into ticket values (50.5, '2020-09-09', null)