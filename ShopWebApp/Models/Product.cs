using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopWebApp.Models
{
	[Table("Products")]
	public class Product
	{
		[Key]
		public int id { get; set; }

		public string name { get; set; }

		public float price { get; set; }

		public int amount { get; set; }

		[JsonIgnore]
		public virtual Customer customer { get; set; }
	}
}