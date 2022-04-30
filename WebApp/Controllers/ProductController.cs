using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
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

        [HttpGet()]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var entity = _productService.GetProduct(id);
            if (entity == null)
            {
                return NotFound();
            }

            var result = new ProductModel()
            {
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price,
                PhotoURL = entity.PhotoURL
            };
            return Ok(result);
        }

        [HttpGet()]
        [Route("")]
        public IActionResult Get()
        {
            var entities = _productService.GetProducts();
            if (entities == null)
            {
                return NotFound();
            }
            return Ok(entities);
        }

        [HttpPost]
        [Route("")]
        public IActionResult Create(ProductModel model)
        {
            _productService.AddProduct(model.Name, model.Description, model.Price, model.PhotoURL);
            return Ok();
        }

        [HttpPut]
        [Route("")]
        public IActionResult Update(int id, ProductModel model)
        {
            var entity = _productService.GetProduct(id);
            if (entity == null)
            {
                return NotFound();
            }

            _productService.UpdateProduct(id, entity, model.Name, model.Description, model.Price, model.PhotoURL);
            return Ok();
        }

        [HttpDelete]
        [Route("")]
        public IActionResult Delete(int id)
        {
            var entity = _productService.GetProduct(id);
            if (entity == null)
            {
                return NotFound();
            }

            _productService.DeleteProduct(id, entity);
            return Ok();
        }
    }
}
