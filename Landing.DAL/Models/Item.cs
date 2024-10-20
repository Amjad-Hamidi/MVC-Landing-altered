using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landing.DAL.Models
{
	public class Item
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime CreatedAt { get; set; }


		public int? PortfoiloId { get; set; } // relation للداتا , عشان عملت  load بتلزم عشان اعمل 
		public Portfoilo Portfoilo { get; set; }
	}
}
