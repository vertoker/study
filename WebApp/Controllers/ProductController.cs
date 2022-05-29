using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
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
            _productService.InitDB();
        }

        [HttpGet()]
        [Route("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            var entity = _productService.GetProduct(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpGet()]
        [Route("")]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public IActionResult Create(ProductModel model)
        {
            _productService.AddProduct(model.name, model.description, model.price, model.photo_url);
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id, ProductModel model)
        {
            var entity = _productService.GetProductData(id);
            if (entity == null)
            {
                return NotFound();
            }

            _productService.UpdateProduct(id, entity, model.name, model.description, model.price, model.photo_url);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var entity = _productService.GetProductData(id);
            if (entity == null)
            {
                return NotFound();
            }

            _productService.DeleteProduct(id, entity);
            return Ok();
        }
    }
}
