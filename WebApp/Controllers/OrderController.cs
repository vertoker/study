using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;
using System;

using WebApp.Entities;
using WebApp.Interfaces;
using WebApp.Models;
using Microsoft.AspNetCore.Authorization;

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
            _orderService.InitDB();
        }

        [HttpGet()]
        [Route("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            var entity = _orderService.GetOrder(id);
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
            var entities = _orderService.GetOrders();
            if (entities == null)
            {
                return NotFound();
            }
            return Ok(entities);
        }

        [HttpPost]
        [Route("")]
        [Authorize]
        public IActionResult Create(OrderModelPost model)
        {
            _orderService.AddOrder(model);
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id, OrderStatus orderStatus)
        {
            var entity = _orderService.GetOrderData(id);
            if (entity == null)
            {
                return NotFound();
            }

            _orderService.UpdateStatus(id, entity, orderStatus);
            return Ok();
        }
    }
}