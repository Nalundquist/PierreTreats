using System.Collections.Generic;
using System;

namespace PierreTreats.Models
{
	public class Flavor
	{
		public Flavor()
		{
			this.JoinTreFla = new HashSet<TreatFlavor>();
		}
		public int FlavorId {get; set;}
		public string Name {get; set;}
		public virtual ApplicationUser User {get; set;}
		public virtual ICollection<TreatFlavor> JoinTreFla {get;}
	}
}