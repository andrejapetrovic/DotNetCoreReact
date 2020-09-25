using System;
using System.Collections.Generic;

namespace MoviesCore.Models
{
    public partial class MemberMovie
    {
        public int MemberId { get; set; }
        public int MovieId { get; set; }

        public virtual Member Member { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
