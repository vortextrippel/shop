using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopWebApp.Controllers;
using ShopWebApp.Models;

namespace UnitTests
{
	[TestClass]
	public class UnitTest1
	{
		CustomersController customersController;
		ProductsController productsController;

		[TestMethod]
		public void TestMethod1()
		{
			customersController = new CustomersController()
			{
				Request = new HttpRequestMessage(),
				Configuration = new HttpConfiguration()
			};

			productsController = new ProductsController()
			{
				Request = new HttpRequestMessage(),
				Configuration = new HttpConfiguration()
			};

			customersController.PostCustomer(
				new Customer()
				{
					name = "Robert",
					surname = "Schwab",
					address = "92 Edward Bennett Drive"
				});

			customersController.PostCustomer(
				new Customer()
				{
					name = "Freddy",
					surname = "Dong",
					address = "62 Forrest Road"
				});

			customersController.PostCustomer(
				new Customer()
				{
					name = "James",
					surname = "Bivens",
					address = "60 Buoro Street"
				});

			customersController.PostCustomer(
				new Customer()
				{
					name = "Frederick",
					surname = "Hinojosa",
					address = "52 Normans Road"
				});

			customersController.PostCustomer(
				new Customer()
				{
					name = "Kelly",
					surname = "Otero",
					address = "23 Thone Street"
				});

			HttpResponseMessage response = customersController.GetCustomers();
			List<Customer> customers = response.Content.ReadAsAsync<List<Customer>>().GetAwaiter().GetResult();
			Assert.AreEqual(5, customers.Count);

			productsController.PostProduct(
				customers[0].id,
				new Product()
				{
					name = "Phone",
					price = 7999,
					amount = 2
				});

			productsController.PostProduct(
				customers[0].id,
				new Product()
				{
					name = "Tablet",
					price = 12999,
					amount = 1
				});

			response = productsController.GetProducts();
			List<Product> products = response.Content.ReadAsAsync<List<Product>>().GetAwaiter().GetResult();
			Assert.AreEqual(2, products.Count);

			foreach (Product product in products)
			{
				productsController.DeleteProduct(product.id);
			}

			foreach (Customer customer in customers)
			{
				customersController.DeleteCustomer(customer.id);
			}

			response = customersController.GetCustomers();
			customers = response.Content.ReadAsAsync<List<Customer>>().GetAwaiter().GetResult();
			Assert.AreEqual(0, customers.Count);

			response = productsController.GetProducts();
			products = response.Content.ReadAsAsync<List<Product>>().GetAwaiter().GetResult();
			Assert.AreEqual(0, products.Count);
		}
	}
}
