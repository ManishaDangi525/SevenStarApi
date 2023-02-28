using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SevenStarDtos.Attributes;
using System.Text.Json.Serialization;

namespace SevenStarDtos.DTOs
{
    public class DropdownsDTO : BaseDTO
    {
        [IgnoreParam]
        public long Id { get; set; }
        [IgnoreParam]
        public string Value { get; set; }
        [IgnoreParam]
        public long Id2 { get; set; }
        [JsonIgnore]
        public long Cond1 { get; set; }
        [IgnoreParam]
        public string Cond2 { get; set; }
        [IgnoreParam]
        public string EmailAddress { get; set; }

        [JsonIgnore]
        public long Cond3 { get; set; }
        public long SupplierId { get; set; }
        
    }
}
