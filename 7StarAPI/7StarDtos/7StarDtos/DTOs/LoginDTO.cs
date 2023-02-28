using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using SevenStarDtos.Attributes;

namespace SevenStarDtos.DTOs
{
    public class LoginDTO 
    {
        public int UserId { get; set; } 
        public string LoginName { get; set; }
        public string UserName { get; set; } 
        public string LoginPassword { get; set; }
       
        public string MobileNo { get; set; }
         
        public string Address { get; set; } 
        public string IsApproved { get; set; }

        public string SupplierName { get; set; }

        [JsonIgnore]
        public string Mode { get; set; }
        [JsonIgnore]
        public Nullable<int> UserIdC { get; set; }

        [IgnoreParam]
        public string Token { get; set; }

        [IgnoreParam]
        public string RefreshToken { get; set; }
        
        public int ClientId { get; set; } 

        public decimal? OTP { get; set; }
        public DateTime? OTPGenerateDate { get; set; }
        public DateTime? OTPExpiryDate { get; set; }

    }
}
