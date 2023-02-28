 
using Microsoft.AspNetCore.Mvc;
using SevenStarDtos.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdexVendorManegement.Controllers
{
    public class BaseController : ControllerBase
    {
        // public LoginDTO currentUser => HttpContext.Items["CurrentUser"] != null ? (LoginDTO)HttpContext.Items["CurrentUser"] : null;
        public LoginDTO currentUser => new LoginDTO
        {
            UserId = 1,
            ClientId = 1

        };

    }
}
