 
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SevenStarDtos.DTOs;
using SevenStarFramework.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdexVendorManegement.Controllers
{
    [Route("api/dropdowns")]
    [ApiController]
    public class DropdownsController : BaseController
    {
        private IDropdownsService _Service;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private IConfiguration _configuration;

        public DropdownsController(IDropdownsService Service, IWebHostEnvironment hostEnvironment, IConfiguration configuration)
        {
            _Service = Service;
            _webHostEnvironment = hostEnvironment;
            _configuration = configuration;
        }

        //Get All Dropdowns
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] DropdownsDTO dropdownsDTO)
            {
            dropdownsDTO.UserIdC = currentUser.UserId;
            dropdownsDTO.ClientId = currentUser.ClientId;
            var response = await _Service.GetAll(dropdownsDTO);
            return Ok(response);
        }
    }
}
