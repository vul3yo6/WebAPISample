using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiApp.Filter;
using WebApiApp.Models;

namespace WebApiApp.Controllers
{
    [RequireHttps]
    [Authorize]
    public class TestController : System.Web.Http.OData.ODataController //public class TestController : ApiController
    {
        List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M },
            new Product { Id = 4, Name = "Apple", Category = "Fruit", Price = 1 },
            new Product { Id = 5, Name = "Banana", Category = "Fruit", Price = 3.75M },
            new Product { Id = 6, Name = "Cat", Category = "Anamail", Price = 16.99M }
        };

        // GET: api/Test
        //public IEnumerable<Product> Get()
        //{
        //    return products;
        //}
        //[Queryable]
        //public IQueryable<Product> Get()
        //{
        //    return products.AsQueryable();
        //}
        [Queryable]
        public IQueryable<Product> Get(System.Web.Http.OData.ODataActionParameters paramList)
        {
            if (paramList.ContainsKey("top"))
            {

            }
            return products.AsQueryable();
        }

        // GET: api/Test/5
        public Product Get(int id)
        {
            return products.FirstOrDefault(x => x.Id == id);
        }

        [Route("GetByName")]
        public IEnumerable<Product> Get(string name)
        {
            return products.Where(x => x.Name == name);
        }

        // POST: api/Test
        //public void Post([FromBody]string value)
        //{
        //    var model = JsonConvert.DeserializeObject<Product>(value);
        //    products.Add(model);
        //}
        //public void Post(string value)
        //{
        //    var model = JsonConvert.DeserializeObject<Product>(value);
        //    products.Add(model);
        //}

        public void Post([FromBody]Product model)
        {
            //var model = JsonConvert.DeserializeObject<Product>(value);
            products.Add(model);
        }
        //public void Post(Product model)
        //{
        //    //var model = JsonConvert.DeserializeObject<Product>(value);
        //    products.Add(model);
        //}

        // PUT: api/Test/5
        public void Put(int id, [FromBody]string value)
        {
            var model = JsonConvert.DeserializeObject<Product>(value);
            var product = products.FirstOrDefault(x => x.Id == id);

        }

        // DELETE: api/Test/5
        public void Delete(int id)
        {
            products.RemoveAll(x => x.Id == id);
        }
    }
}
