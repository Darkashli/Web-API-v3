using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_v3.Domain;
using WebApi_v3.Infrastructure;
using WebApi_v3.Models;

namespace WebApi_v3.Controllers
{
    public class CustomerController : ApiController
    {

        public CustomerController()
        {
        }

        // GET: api/Customer
        [HttpGet]
        public List<CustomerViewModel> Get()
        {
            using (var connection = new WebApiContext())
            {
                var customer = connection.Customers.Select(cl => new CustomerViewModel()
                {
                    Id = cl.Id,
                    FirstName = cl.FirstName,
                    LastName = cl.LastName,
                    Products = cl.Products.Select(o => new ProductViewModel()
                    {
                        Id = o.Id,
                        Name = o.Name,
                        Detail = o.Detail,
                        Price = o.Price
                    }).ToList()
                }).ToList();
                return customer;
            }
        }

        //GET: api/Customer/5
        [HttpGet]
        public CustomerViewModel Get(int id)
        {
            using (var connection = new WebApiContext())
            {
                var customer = connection.Customers
                    .FirstOrDefault(o => o.Id == id);

                var customerViewModel = new CustomerViewModel()
                {
                    Id = customer.Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Products = customer.Products.Select(o => new ProductViewModel()
                    {
                        Id = o.Id,
                        Name = o.Name,
                        Detail = o.Detail,
                        Price = o.Price
                    }).ToList()
                };
                return customerViewModel;
            }
        }

        // POST: api/Customer
        [HttpPost]
        public CustomerViewModel Post([FromBody]CustomerViewModel customerViewModel)
        {
            using (var context = new WebApiContext())
            {
                var customer = new Customer()
                {
                    Id = customerViewModel.Id,
                    FirstName = customerViewModel.FirstName,
                    LastName = customerViewModel.LastName,
                    Products = customerViewModel.Products.Select(o => new Product()
                    {
                        Id = o.Id,
                        Name = o.Name,
                        Detail = o.Detail,
                        Price = o.Price
                    }).ToList()
                };

                context.Customers.Add(customer);
                context.SaveChanges();

                return Get(customer.Id);
            }

        }

        // PUT: api/Customer/5 
        [HttpPut]
        public CustomerViewModel Put(int id, [FromBody]CustomerViewModel customerViewModel)
        {
            using (var context = new WebApiContext())
            {
                var customer = context.Customers.FirstOrDefault(o => o.Id == id);

                customer.FirstName = customerViewModel.FirstName;
                customer.LastName = customerViewModel.LastName;


                context.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();

                return customerViewModel;
            }
        }

        // DELETE: api/Customer/5
        public void Delete(int id)
        {
            using (var context = new WebApiContext())
            {
                var customer = context.Customers.FirstOrDefault(o => o.Id == id);
                context.Entry(customer).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}