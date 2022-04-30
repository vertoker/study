
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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet()]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var entity = _orderService.GetOrder(id);
            if (entity == null)
            {
                return NotFound();
            }

            var result = new OrderModel()
            {
                Products = entity.Products,
                Address = entity.Address,
                Description = entity.Description,
                Status = entity.Status
            };
            return Ok(result);
        }

        [HttpGet()]
        [Route("")]
        public IActionResult Get()
        {
            var entities = _orderService.GetOrders();
            if (entities == null)
            {
                return NotFound();
            }
            return Ok(entities);
        }

        [HttpPost]
        [Route("")]
        public IActionResult Create(OrderModel model)
        {
            _orderService.AddOrder(model.Products, model.Address, model.Description, model.Status);
            return Ok();
        }

        [HttpPut]
        [Route("")]
        public IActionResult Update(int id, OrderStatus orderStatus)
        {
            var entity = _orderService.GetOrder(id);
            if (entity == null)
            {
                return NotFound();
            }

            _orderService.UpdateStatus(id, entity, orderStatus);
            return Ok();
        }
    }
}