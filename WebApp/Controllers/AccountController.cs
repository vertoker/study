using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

using WebApp.Options;
using WebApp.Entities;

namespace TokenApp.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost("/token")]
        public IActionResult Token(string login, string password)
        {
            var identity = ApplicationContextDB.GetIdentity(login, password);
            if (identity == null)
            {
                return BadRequest( new { errorText = "Invalid username or password." });
            }

            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name,
                role = identity.Claims.ToArray()[1].Value
            };

            return Json(response);
        }

        [HttpPost]
        [Route("")]
        public IActionResult Create(string login, string password, UserRole role)
        {
            if (ApplicationContextDB.GetIdentity(login, password) != null)
                return BadRequest( new { errorText = "Invalid username or password." } );
            ApplicationContextDB.AddUser(login, password, role);
            return Ok();
        }
    }
}