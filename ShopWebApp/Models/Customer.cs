using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopWebApp.Models
{
	[Table("Customers")]
	public class Customer
	{
		[Key]
		public int id { get; set; }

		[Required]
		public string name { get; set; }

		[Required]
		public string surname { get; set; }

		[Required]
		public string address { get; set; }

		public virtual ICollection<Product> products { get; set; }

		public Customer()
		{
			products = new List<Product>();
		}
	}
}