using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesCore.Models
{
    public class Ticket
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

        [Column(TypeName = "decimal(5,2)")]
		public decimal Price { get; set; }

		public DateTime BuyingDate { get; set; }

        public Member member { get; set; }

    }
}
