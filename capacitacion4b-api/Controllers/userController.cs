using capacitacion4b_api.Data.interfaces;
using capacitacion4b_api.DTOs.user;
using capacitacion4b_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace capacitacion4b_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : Controller
    {

        private iUserService _userService;
        public userController(iUserService userService) => _userService = userService;

        // GET: userController
        [HttpGet]
        public async Task<IActionResult> findAll()
        {
            var users = await _userService.findAll();
            return Ok(users);
        }

        // GET: userController/Details/5
        [HttpGet("{id}")]
        public async Task<IActionResult> findOne(int id)
        {

            userModel? user = await _userService.findOne(id);
            return Ok(user);

        }

        // POST: userController/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] createUserDto createUserDto)
        {

            userModel? user = await _userService.create(createUserDto);
            return Created(user?.idUsuario.ToString(), user);

        }

    }

}
