using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Models;
using Capstone.Security;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BoardsController : ControllerBase
    {
        

        public BoardsController()
        {
           
        }

        [HttpGet]
        public IEnumerable<Board> GetBoards()
        {
            return FakeBoardDAO.GetBoards();
        }

        [HttpGet("{id}")]
        public Board GetSpecificBoard(int id)
        {
            return FakeBoardDAO.GetSpecificBoard(id);
        }
        

    }
}
