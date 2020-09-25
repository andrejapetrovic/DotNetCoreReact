using System;
using System.Collections.Generic;

namespace MoviesCore.Models
{
    public partial class Movie
    {
        public Movie()
        {
            MemberMovie = new HashSet<MemberMovie>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Story { get; set; }
        public string Genre { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<MemberMovie> MemberMovie { get; set; }
    }
}
