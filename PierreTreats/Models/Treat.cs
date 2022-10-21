using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace PierreTreats.Models
{
	public class Treat
	{
		public Treat()
		{
			this.JoinTreFla = new HashSet<TreatFlavor>();
		}
		public int TreatId {get; set;}
		public string Name {get; set;}
		public int Price {get; set;}
		public virtual ApplicationUser User {get; set;}
		public virtual ICollection<TreatFlavor> JoinTreFla {get; set;}
	}
}