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
    [Route("api/userPermission")]
    [ApiController]
    public class GroupFormsPermissionController : BaseController
    {
        private IGroupFormsPermissionService _Service;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private IConfiguration _configuration;

        public GroupFormsPermissionController(IGroupFormsPermissionService Service, IWebHostEnvironment hostEnvironment, IConfiguration configuration)
        {
            _Service = Service;
            _webHostEnvironment = hostEnvironment;
            _configuration = configuration;
        }

        //Get All Data 
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GroupFormsPermissionDTO userPermissionDTO)
        {

            userPermissionDTO.ClientId = currentUser.ClientId;
            userPermissionDTO.Mode = "search";
            var response = await _Service.GetAll(userPermissionDTO);
            return Ok(response);
        }

        // Get Data By Id
        [HttpGet]
        [Route("{id:long}")]
        public async Task<IActionResult> Get(long id)
        {
            var response = await _Service.GetById(id);
            return Ok(response);
        }

        //Insert Data
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GroupFormsPermissionDTO userPermissionDTO)
        {
            userPermissionDTO.UserIdC = currentUser.UserId;
            userPermissionDTO.ClientId = currentUser.ClientId;
            userPermissionDTO.Mode = "insert";
            var response = await _Service.Insert(userPermissionDTO);
            return Ok(response);
        }

        //Update 
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] GroupFormsPermissionDTO userPermissionDTO)
        {
            userPermissionDTO.UserIdC = currentUser.UserId;
            userPermissionDTO.ClientId = currentUser.ClientId;
            userPermissionDTO.Mode = "update";
            var response = await _Service.Update(userPermissionDTO);
            return Ok(response);
        }

        //Delete
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var response = await _Service.Delete(id);
            return Ok(response);
        }
    }
}
