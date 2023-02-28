using SevenStarDtos.DTOs;
using SevenStarFramework.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdexVendorManegement.Controllers;

namespace SevenStar.Controllers
{
    [Route("api/module")]
    [ApiController]
    public class MenusController : BaseController
    {
        private IMenusService _Service;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private IConfiguration _configuration;

        public MenusController(IMenusService Service, IWebHostEnvironment hostEnvironment, IConfiguration configuration)
        {
            _Service = Service;
            _webHostEnvironment = hostEnvironment;
            _configuration = configuration;
        }

        
        [HttpGet] 
        public async Task<IActionResult> Get([FromQuery] MenuDTO menuDTO)
        {

            menuDTO.ClientId = currentUser.ClientId;
            menuDTO.UserIdC = currentUser.UserId;
            menuDTO.Mode = "GetMenu";
            var response = await _Service.GetAll(menuDTO);
            return Ok(response);
        }

        


    }
}
