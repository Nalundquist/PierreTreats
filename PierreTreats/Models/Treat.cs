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
		[Precision(14, 2)]
		public double Price {get; set;}
		public virtual ApplicationUser User {get; set;}
		public virtual Icollection<TreatFlavor> JoinTreFla {get; set;}
	}
}