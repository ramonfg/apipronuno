using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Library.Functions;
using Library.Models;
using System;

namespace Library.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserFunctions UserFunctions;

        public UsersController()
        {
            this.UserFunctions = new UserFunctions();
        }

        [HttpPost]
        public ActionResult<Guid> Login(LoginDto loginDto)
        {
            Access access = UserFunctions.Login(loginDto.Username, loginDto.Password);
            if (access.denied) return Unauthorized();
            else return access.guid;
        }

    }
}