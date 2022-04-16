using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;

using WebApp.Entities;
using WebApp.Interfaces;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [Route("")]
        public IActionResult Create(ProductModel model)
        {
            _productService.AddProduct(model.Name, model.Description, model.Price, model.PhotoURL);
            return Ok();
        }

        [HttpGet()]
        [Route("")]
        public IActionResult Get(int id)
        {
            var product = _productService.GetProduct(id);
            var result = new ProductModel()
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                PhotoURL = product.PhotoURL
            };
            return Ok(result);
        }
    }
}
