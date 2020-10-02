using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesCore.Models
{
    public partial class Movie
    {
        public Movie()
        {
            this.MemberMovies = new HashSet<MemberMovies>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Story { get; set; }

        public string Genre { get; set; }

        public DateTime? ReleaseDate { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? Price { get; set; }

        public virtual ICollection<MemberMovies> MemberMovies { get; set; }

    }
}
