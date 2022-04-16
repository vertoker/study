using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Entities;
using System.Collections.Generic;
using System.Linq;
using System;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [Route(nameof(Get))]
        public IEnumerable<ProductEntity> Get()
        {
            return new List<ProductEntity>();
        }
    }
}
