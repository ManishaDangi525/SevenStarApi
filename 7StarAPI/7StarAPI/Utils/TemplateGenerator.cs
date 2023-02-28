 
using SevenStarDtos.DTOs;
using SevenStarFramework.Repositories.Interfaces;
using SevenStarFramework.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace SevenStar.Utils
{
    public class TemplateGenerator
    {
       
        private IWebHostEnvironment _hostingEnvironment;


        public TemplateGenerator(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
     


  }
}
