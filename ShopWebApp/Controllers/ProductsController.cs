using ShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopWebApp.Controllers
{
    public class ProductsController : ApiController
    {
		ShopContext context => ShopContext.Instance;

		[HttpGet]
		[Route("api/Products")]
		public HttpResponseMessage GetProducts()
		{
			return Request.CreateResponse(HttpStatusCode.OK, context?.products?.ToList());
		}

		[HttpGet]
		[Route("api/Products/{id}")]
		public HttpResponseMessage GetProduct(int id)
		{
			Product product = context.products?.Find(id);
			return Request.CreateResponse(HttpStatusCode.OK, product);
		}

		[HttpPost]
		[Route("api/Products/{customer_id}")]
		public HttpResponseMessage PostProduct(int customer_id, [FromBody]Product product)
		{
			Customer customer = context.customers?.Find(customer_id);
			customer.products.Add(product);
			context.SaveChanges();
			return Request.CreateResponse(HttpStatusCode.OK);
		}

		[HttpPut]
		[Route("api/Products/{id}")]
		public HttpResponseMessage PutProduct(int id, [FromBody]Product newProduct)
		{
			Product product = context.products?.Find(id);
			product.name = newProduct.name;
			product.price = newProduct.price;
			product.amount = newProduct.amount;
			product.customer = newProduct.customer;
			context.SaveChanges();
			return Request.CreateResponse(HttpStatusCode.OK);
		}

		[HttpDelete]
		[Route("api/Products/{id}")]
		public HttpResponseMessage DeleteProduct(int id)
		{
			context.products.Remove(context.products.Find(id));
			context.SaveChanges();
			return Request.CreateResponse(HttpStatusCode.OK);
		}
	}
}
