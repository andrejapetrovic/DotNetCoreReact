using System;
using System.Collections.Generic;

namespace MoviesCore.Models
{
    public partial class Member
    {
        public Member()
        {
            MemberMovie = new HashSet<MemberMovie>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }

        public virtual ICollection<MemberMovie> MemberMovie { get; set; }
    }
}
