using MoviesCore.Models;
using Microsoft.EntityFrameworkCore;

namespace MoviesCore.DAL
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Member> Members { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().ToTable("Movie");
            modelBuilder.Entity<Member>().ToTable("Member");
            modelBuilder.Entity<MemberMovies>().ToTable("MemberMovies")
                .HasKey(m => new { m.MemberId, m.MovieId });
        }
    }
}
