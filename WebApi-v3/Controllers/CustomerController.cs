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
        public List<CustomerViewModel> Get()
        {
            using (var connection = new WebApiContext())
            {

                var customer = connection.Customers.Select(cl => new CustomerViewModel()
                {
                    FirstName = cl.FirstName,
                    LastName = cl.LastName,
                    Gender = cl.Gender,
                    Functions = cl.Functions,
                    Age = cl.Age,
                    Salary = cl.Salary,
                    HireDate = cl.HireDate
                }).ToList();
                return customer;

            }
        }

        //GET: api/Customer/5
        public CustomerViewModel Get(int id)
        {
            using (var connection = new WebApiContext())
            {
                var person = connection.Customers
                    .FirstOrDefault(o => o.Id == id);

                var customerViewModel = new CustomerViewModel()
                {
                    Id = person.Id,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Gender = person.Gender,
                    Functions = person.Functions,
                    Age = person.Age,
                    Salary = person.Salary,
                    HireDate = person.HireDate
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
                    FirstName = customerViewModel.FirstName,
                    LastName = customerViewModel.LastName,
                    Gender = customerViewModel.Gender,
                    Functions = customerViewModel.Functions,
                    Age = customerViewModel.Age,
                    Salary = customerViewModel.Salary,
                    HireDate = customerViewModel.HireDate
                };

                context.Customers.Add(customer);
                context.SaveChanges();


                customerViewModel.Id = customer.Id;

                return customerViewModel;
            }

        }

        // PUT: api/Customer/5        
        public CustomerViewModel Put(int id, [FromBody]CustomerViewModel customerViewModel)
        {
            using (var context = new WebApiContext())
            {
                var customer = context.Employees.FirstOrDefault(o => o.Id == id);

                customer.FirstName = customerViewModel.FirstName;
                customer.LastName = customerViewModel.LastName;
                customer.Gender = customerViewModel.Gender;
                customer.Functions = customerViewModel.Functions;
                customer.Age = customerViewModel.Age;
                customer.Salary = customerViewModel.Salary;
                customer.HireDate = customerViewModel.HireDate;

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