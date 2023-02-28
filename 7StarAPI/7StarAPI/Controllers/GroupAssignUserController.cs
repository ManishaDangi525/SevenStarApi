 
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
    [Route("api/groupAssignUser")]
    [ApiController]
    public class GroupAssignUserController : BaseController
    {
        private IGroupAssignUserService _Service;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private IConfiguration _configuration;

        public GroupAssignUserController(IGroupAssignUserService Service, IWebHostEnvironment hostEnvironment, IConfiguration configuration)
        {
            _Service = Service;
            _webHostEnvironment = hostEnvironment;
            _configuration = configuration;
        }

        //Get All Data 
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GroupAssignUserDTO groupAssignUserDTO)
        {

            groupAssignUserDTO.ClientId = currentUser.ClientId;
            groupAssignUserDTO.Mode = "search";
            var response = await _Service.GetAll(groupAssignUserDTO);
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
        public async Task<IActionResult> Post([FromBody] GroupAssignUserDTO groupAssignUserDTO)
        {
            groupAssignUserDTO.UserIdC = currentUser.UserId;
            groupAssignUserDTO.ClientId = currentUser.ClientId;
            groupAssignUserDTO.Mode = "insert";
            var response = await _Service.Insert(groupAssignUserDTO);
            return Ok(response);
        }

        //Update 
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] GroupAssignUserDTO groupAssignUserDTO)
        {
            groupAssignUserDTO.UserIdC = currentUser.UserId;
            groupAssignUserDTO.ClientId = currentUser.ClientId;
            groupAssignUserDTO.Mode = "update";
            var response = await _Service.Update(groupAssignUserDTO);
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
