using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SevenStarDtos.DTOs;
using SevenStarFramework.Services.Interfaces;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Options;
using IdexVendorManegement.Controllers;

namespace SevenStar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private IUserService _userService;
        private AppSettings _appSettings;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private IConfiguration _configuration;
         

        public UserController(IUserService userService, IWebHostEnvironment hostEnvironment, IConfiguration configuration ,IOptions<AppSettings> settings)
        {
            _userService = userService;
            _webHostEnvironment = hostEnvironment;
            _configuration = configuration;          
            _appSettings = settings.Value;

        }
        //Insert
        [HttpPost]
        [Route("insert")]
        public async Task<ActionResult<LoginDTO>> Insert(LoginDTO loginDTO)
        {
            loginDTO.UserIdC = currentUser.UserId;
            loginDTO.ClientId = currentUser.ClientId;
            loginDTO.Mode = "insert";
          
            var response = await _userService.Insert(loginDTO);
            //if (response.Success)
            //{
            //    var res = await NotificationEmail.userMail(_webHostEnvironment, _appSettings, loginDTO.LoginName, loginDTO.UserName,loginDTO.LoginPassword);
            //}

            return Ok(response);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Put([FromBody] LoginDTO loginDTO)
        {
            loginDTO.UserIdC = currentUser.UserId;
            loginDTO.ClientId = currentUser.ClientId;
            loginDTO.Mode = "update";
            var response = await _userService.Update(loginDTO);
            return Ok(response);
        }
        //Get All Data 
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] LoginDTO loginDTO)
        {
            loginDTO.UserIdC = currentUser.UserId;
            loginDTO.ClientId = currentUser.ClientId;
            loginDTO.Mode = "search";
            var response = await _userService.GetAll(loginDTO);
            return Ok(response);
        }

        [HttpGet]
        [Route("{id:long}")]
        public async Task<IActionResult> Get(long id)
        {
            var response = await _userService.GetById(id);
            return Ok(response);
        }

        //Login
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<LoginDTO>> Login(LoginDTO userDto)
        {
           // userDto.ClientId = currentUser.ClientId;
            userDto.Mode = "login";
            var response = await _userService.LoginAsync(userDto, ipAddress());
            return Ok(response);
        }

        //Token
        [HttpPost("refresh-token")]
        public async Task<ActionResult<LoginDTO>> RefreshToken([FromQuery] string refreshToken)
        {
            var response = await _userService.RefreshTokenAsync(refreshToken, ipAddress());
           
            return Ok(response);
        }

        //Password Change
        [HttpPost("change-password")]
        public async Task<ActionResult<long>> ChangePassword([FromBody] ChangePasswordDTO changePasswordDTO)
        {
             changePasswordDTO.UserId = currentUser.UserId;
            changePasswordDTO.Mode = "changepassword";
            var response = await _userService.ChangePasswordAsync(changePasswordDTO);

            return Ok(response);
        }

        //ForgotPassword
        [HttpPut]
        [Route("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] LoginDTO loginDTO)
        {
            loginDTO.Mode = "forgot-password";

            var response = await _userService.ForgotPassword(loginDTO);

            //Forgot Password Mail
            //if (response.Success)
            //{
            //    var response1 = await _userService.GetById(response.ReturnValue);
            //    var res = await NotificationEmail.ForgotPasswordMail(_webHostEnvironment, response1.ReturnValue.OTP, _appSettings, response1.ReturnValue.LoginName );
            //}
            return Ok(response.Success);
        }

        //Match OTP
        [HttpPut]
        [Route("match-otp")]
        public async Task<IActionResult> MatchOtp([FromBody] LoginDTO loginDTO)
        {
            loginDTO.Mode = "matchOtp";
            var response = await _userService.MatchOtp(loginDTO);

            // Mail to supplier
            //if (response.Success)
            //{
            //    var response1 = await _userService.GetById(response.ReturnValue);
            //    var res = await NotificationEmail.NewPasswordMail(_webHostEnvironment, response1.ReturnValue.OTP, _appSettings, response1.ReturnValue.LoginName, response1.ReturnValue.LoginPassword);
            //}

            return Ok(response);

        } 

        //IPAddress
        private string ipAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }

        //[HttpGet]
        //[Route("bar-code")]
        //public IActionResult GetImage([FromQuery] LoginDTO loginDTO)
        //{
             
        //    try
        //    {
        //        string barcode = loginDTO.LoginName;
        //       // Zen.Barcode.Code128BarcodeDraw brcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;

        //        Zen.Barcode.CodeQrBarcodeDraw brcode1 = Zen.Barcode.BarcodeDrawFactory.CodeQr;

        //        MemoryStream ms = new MemoryStream();

        //        brcode1.Draw(barcode, 50).Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

        //         // brcode.Draw(barcode, 60).Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        //        ms.ToArray();

        //        return File(ms.ToArray(),
        //       "image/jpeg", "image");

        //       // return File(ms.ToArray(), "image/jpeg");
        //    }
        //    catch (Exception ex)
        //    {
        //        return NotFound();
        //    }
        //}

    }    
}
