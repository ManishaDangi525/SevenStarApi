using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using SevenStarDtos.Attributes;

namespace SevenStarDtos.DTOs
{
    public class GroupDTO : BaseDTO
    {
        public long GroupId { get; set; } 
       
        public string GroupCode { get; set; }

        public string GroupName { get; set; }

        public GroupDTO()
        {
            Groupdetails = new List<GroupdetailsDTO>();

        }
        public List<GroupdetailsDTO> Groupdetails { get; set; }

    }

     
    public class GroupdetailsDTO : BaseDTO
    {
        public long GroupId { get; set; } 
        
        public string GroupCode { get; set; }

        public string GroupName { get; set; }

    }
}
