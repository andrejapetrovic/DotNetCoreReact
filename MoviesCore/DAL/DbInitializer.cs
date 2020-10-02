using MoviesCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesCore.DAL
{
    public class DbInitializer
    {
        public static void Initialize(MyContext context)
        {
            context.Database.EnsureCreated();

            if (context.Movies.Any())
            {
                return;
            }
            var movies = new Movie[]
            {
                new Movie()
                {
                    Title = "LOTR I",
                    Genre = "Fantazija",
                    Price = 144.45m,
                    ReleaseDate = DateTime.Parse("02/20/2000"),
                    Story = "..."
                },
                                new Movie()
                {
                    Title = "LOTR II",
                    Genre = "Fantazija",
                    Price = 144.45m,
                    ReleaseDate = DateTime.Parse("12/03/2002"),
                    Story = "... ..."
                },
                new Movie()
                {
                    Title = "Ko to tamo peva",
                    Genre = "Komedija",
                    Price = 144.45m,
                    ReleaseDate = DateTime.Parse("04/23/1997"),
                    Story = "Bobo smrade..."
                }
            };
            foreach (Movie movie in movies)
            {
                context.Movies.Add(movie);
            }
            context.SaveChanges();

            var members = new Member[]
            {
                new Member()
                {
                    Name = "Aki",
                    Email = "ap@gmail.com",
                    Birthdate = DateTime.Parse("02/15/1995")
                },
                new Member()
                {
                   Name = "JP",
                   Email = "jp@gmail.com",
                   Birthdate = DateTime.Parse("05/25/2002")
                }
            };
            foreach (Member member in members)
            {
                context.Members.Add(member);
            }
            members[0].MemberMovies.Add(new MemberMovies(){ MovieId = movies[0].Id });
            members[0].MemberMovies.Add(new MemberMovies() { MovieId = movies[1].Id });
            context.SaveChanges();
        }
    }
}
