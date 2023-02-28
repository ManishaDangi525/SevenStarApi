using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using SevenStarDtos.Attributes;

namespace SevenStarDtos.DTOs
{
    public class GroupAssignUserDTO : BaseDTO
    {
        public long UserPermissionId { get; set; } 
       
        public long UserId { get; set; }

        public long GroupId { get; set; }
        [IgnoreParam]
        public string GroupName { get; set; }
        [IgnoreParam]
        public string UserName { get; set; }

        public GroupAssignUserDTO()
        {
            GroupAssignUserdetails = new List<GroupAssignUserDTOdetailsDTO>();

        }
        public List<GroupAssignUserDTOdetailsDTO> GroupAssignUserdetails { get; set; }

    }

     
    public class GroupAssignUserDTOdetailsDTO : BaseDTO
    {
        public long UserPermissionId { get; set; }

        public long UserId { get; set; }

        public long GroupId { get; set; }
        [IgnoreParam]
        public string GroupName { get; set; }
        [IgnoreParam]
        public string UserName { get; set; }




    }
}
