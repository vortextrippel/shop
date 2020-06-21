using ShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopWebApp.Controllers
{
    public class CustomersController : ApiController
    {
        ShopContext context => ShopContext.Instance;

		[HttpGet]
		[Route("api/Customers")]
		public HttpResponseMessage GetCustomers()
		{
			return Request.CreateResponse(HttpStatusCode.OK, context?.customers?.ToList());
		}

		[HttpGet]
		[Route("api/Customers/{id}")]
		public HttpResponseMessage GetCustomer(int id)
		{
			Customer customer = context.customers?.Find(id);
			return Request.CreateResponse(HttpStatusCode.OK, customer);
		}

		[HttpPost]
		[Route("api/Customers")]
		public HttpResponseMessage PostCustomer([FromBody]Customer customer)
		{
			context.customers.Add(customer);
			context.SaveChanges();
			return Request.CreateResponse(HttpStatusCode.OK);
		}

		[HttpPut]
		[Route("api/Customers/{id}")]
		public HttpResponseMessage PutCustomer(int id, [FromBody]Customer newCustomer)
		{
			Customer customer = context.customers?.Find(id);
			if (customer == null)
				return Request.CreateResponse(HttpStatusCode.NotFound);
			customer.name = newCustomer.name;
			customer.surname = newCustomer.surname;
			customer.address = newCustomer.address;
			customer.products = newCustomer.products;
			context.SaveChanges();
			return Request.CreateResponse(HttpStatusCode.OK);
		}

		[HttpDelete]
		[Route("api/Customers/{id}")]
		public HttpResponseMessage DeleteCustomer(int id)
		{
			context.customers.Remove(context.customers.Find(id));
			context.SaveChanges();
			return Request.CreateResponse(HttpStatusCode.OK);
		}
	}
}
