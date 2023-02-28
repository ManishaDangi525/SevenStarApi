using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SevenStarDtos.Attributes;

namespace SevenStarDtos.DTOs
{
    public class RefreshTokenDTO
    {
        [IgnoreParam]
        public long UserTokenId { get; set; }
        public long UserId { get; set; }
        public string Token { get; set; } 
        public string NewToken { get; set; } //
        public DateTime ExpiryDate { get; set; }

        [IgnoreParam]
        public DateTime CrDate { get; set; }
        [IgnoreParam]
        public bool IsExpired => DateTime.UtcNow >= ExpiryDate;//

        public string IpAddress { get; set; }
        [IgnoreParam]
        public DateTime? Revoked { get; set; }
        [IgnoreParam]
        public string RevokedByIP { get; set; }
        [IgnoreParam]
        public string ReplacedByToken { get; set; }
        [IgnoreParam]
        public bool IsActive => Revoked == null && !IsExpired;

        public string Mode { get; set; }
    }
}
