using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesCore.Models
{
    public partial class Member
    {
        public Member()
        {
            this.MemberMovies = new HashSet<MemberMovies>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime Birthdate { get; set; }

        public virtual ICollection<MemberMovies> MemberMovies { get; set; }

    }
}
