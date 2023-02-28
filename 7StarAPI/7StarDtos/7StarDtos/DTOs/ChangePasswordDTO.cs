using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SevenStarDtos.DTOs
{
    public class ChangePasswordDTO
    {
        public int UserId { get; set; }
        public string LoginPassword { get; set; }
        public string NewPassword { get; set; }
        public string Mode { get; set; }
    }
}
