using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using SevenStarDtos.Attributes;

namespace SevenStarDtos.DTOs
{

    public class GroupFormsPermissionDTO : BaseDTO
    {
        public GroupFormsPermissionDTO()
        {
            GroupFormsPermissionDetails = new List<UserPermissiondetailsDTO>();

        }
        public long GPermissionId { get; set; } 
        public long GroupId { get; set; } 
        public long SubMenuId { get; set; }
        [IgnoreParam]
        public string GroupName { get; set; }
        [IgnoreParam]
        public string MenuName { get; set; }
        [IgnoreParam]
        public string SubMenuName { get; set; }

        public List<UserPermissiondetailsDTO> GroupFormsPermissionDetails { get; set; }

    }

    public class UserPermissiondetailsDTO : BaseDTO
    {
        public long GPermissionId { get; set; } 
        public long GroupId { get; set; }  
        public long SubMenuId { get; set; }
        [IgnoreParam]
        public string GroupName { get; set; }
        [IgnoreParam]
        public string MenuName { get; set; }
        [IgnoreParam]
        public string SubMenuName { get; set; }

    }
}
