using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
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
    public class AuthController : Controller
    {
        /*[Authorize]
        [Route("getlogin")]
        public IActionResult GetLogin()
        {
            string name = User.Claims.FirstOrDefault(c => c.Type == "Name").Value;
            return Ok($"Ваш логин: {name}");
        }

        [Authorize]
        [Route("getrole")]
        public IActionResult GetRole()
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == "Role").Value;
            return Ok($"Ваша роль: {role}");
        }*/
    }
}
