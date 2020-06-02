using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Na.TodoList.API.Services;
using Na.TodoList.Domain;
using Na.TodoList.Domain.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Na.TodoList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthUserServices _auth;

        private List<AppUser> _users = new List<AppUser>
        {
            new AppUser { Id = 1, FirstName = "Luis", LastName = "Forero", UserName = "lforero", Password = "ratablanca" , Email = "el@email.com" }
        };

        public AuthController(IAuthUserServices auth)
        {
            _auth = auth;
        }

        [HttpPost("[action]")]
        public ActionResult Authenticate([FromBody] AuthenticateUser apiUser)
        {
            try
            {
                if (apiUser == null || string.IsNullOrEmpty(apiUser.Username) || string.IsNullOrEmpty(apiUser.Password))
                    return BadRequest("Missing values");

                var appUser = _users.SingleOrDefault(x => x.UserName == apiUser.Username && x.Password == apiUser.Password);

                if (appUser == null)
                    return Ok("Wrong user or password");

                _auth.CreateToken(appUser);

                return Ok(appUser);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                //_logger.LogError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving trigger paths from database");
            }
        }
    }
}