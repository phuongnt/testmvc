using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using webapi1.Models;

namespace webapi1.Controllers
{
    public class ProductController : ApiController
    {
        //
        // GET: /Product/

       
        private readonly ProductRepository _productRepository = new ProductRepository();

        public IQueryable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

    }
}
