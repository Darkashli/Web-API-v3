using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_v3.Infrastructure;
using WebApi_v3.Domain;
using System.Collections;
using WebApi_v3.Models;
using Newtonsoft.Json;

namespace WebApi_v3.Controllers
{

    public class EmployeeController : ApiController
    {

        public EmployeeController()
        {

        }

        //GET: api/Employee
        public List<EmployeeViewModel> Get()
        {
            using (var connection = new WebApiContext())
            {

                var person = connection.Employees.Select(info => new EmployeeViewModel()
                {
                    FirstName = info.FirstName,
                    LastName = info.LastName,
                    Gender = info.Gender,
                    Functions = info.Functions,
                    Age = info.Age,
                    Salary = info.Salary,
                    HireDate = info.HireDate
                }).ToList();
                return person;

            }
        }


        //GET: api/Employee/5
        public EmployeeViewModel Get(int id)
        {
            using (var connection = new WebApiContext())
            {
                var person = connection.Employees
                    .FirstOrDefault(o => o.Id == id);

                var employeeViewModel = new EmployeeViewModel()
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

                return employeeViewModel;
            }
        }

        // POST: api/Employee
        [HttpPost]
        public EmployeeViewModel Post([FromBody]EmployeeViewModel employeeViewModel)
        {
            using (var context = new WebApiContext())
            {
                var employee = new Employee()
                {
                    FirstName = employeeViewModel.FirstName,
                    LastName = employeeViewModel.LastName,
                    Gender = employeeViewModel.Gender,
                    Functions = employeeViewModel.Functions,
                    Age = employeeViewModel.Age,
                    Salary = employeeViewModel.Salary,
                    HireDate = employeeViewModel.HireDate
                };

                context.Employees.Add(employee);
                context.SaveChanges();


                employeeViewModel.Id = employee.Id;

                return employeeViewModel;
            }

        }

        // PUT: api/Employee/5
        public EmployeeViewModel Put(int id, [FromBody]EmployeeViewModel employeeViewModel)
        {
            using (var context = new WebApiContext())
            {
                var employee = context.Employees.FirstOrDefault(o => o.Id == id);

                employee.FirstName = employeeViewModel.FirstName;
                employee.LastName = employeeViewModel.LastName;
                employee.Gender = employeeViewModel.Gender;
                employee.Functions = employeeViewModel.Functions;
                employee.Age = employeeViewModel.Age;
                employee.Salary = employeeViewModel.Salary;
                employee.HireDate = employeeViewModel.HireDate;

                context.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();

                return employeeViewModel;
            }
        }

        // DELETE: api/Employee/5
        public void Delete(int id)
        {
            using (var context = new WebApiContext())
            {
                var employee = context.Employees.FirstOrDefault(o => o.Id == id);
                context.Entry(employee).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
