use MyDb;
select * from member
inner join member_movie on member.id = member_id
inner join movie on movie.id = movie_id

select count(ticket.id) "ticket count", member.Id, member.name
from member
inner join ticket on ticket.memberId = member.id
group by member.id, member.name
