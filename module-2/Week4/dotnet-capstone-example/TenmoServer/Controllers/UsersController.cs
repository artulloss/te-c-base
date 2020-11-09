using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TenmoServer.DAO;

namespace TenmoServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private IUserDAO userDao; 

        public UsersController(IUserDAO dao)
        {
            userDao = dao;
        }

        [HttpGet("count")]
        public int GetCountUsers()
        {
            return userDao.GetUsers().Count;
        }
    }
}
