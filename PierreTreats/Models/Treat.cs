using System.Collections.Generic;
using System;

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
		public double Price {get; set;}
		public virtual ApplicationUser User {get; set;}
		public virtual Icollection<TreatFlavor> JoinTreFla {get; set;}
	}
}