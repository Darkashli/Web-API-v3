using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_v3.Domain;
using WebApi_v3.Infrastructure;
using WebApi_v3.Models;

namespace WebApi_v3.Controllers
{
    public class ProductController : ApiController
    {
        public ProductController()
        {
        }

        // GET: api/Product
        [HttpGet]
        public List<ProductViewModel> Get()
        {

            //using (var connection = new WebApiContext())
            // {
            /* var product = connection.GetProducts.Select(cl => new CustomerViewModel()
             {

                 FirstName = cl.FirstName,
                 LastName = cl.LastName,
             }).ToList();*/
            /*return product;*/

            //}
            return Get();
        }

        // GET: api/Product/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Product
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}
