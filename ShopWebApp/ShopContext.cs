using ShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShopWebApp
{
	public class ShopContext : DbContext
	{
		public ShopContext() : base("Server=DESKTOP-3JJF44H\\SQLEXPRESS;Database=ShopDatabase;Trusted_Connection=True")
		{ }

		private static ShopContext instance;
		public static ShopContext Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new ShopContext();
				}
				return instance;
			}
		}

		public DbSet<Customer> customers { get; set; }

		public DbSet<Product> products { get; set; }
	}
}