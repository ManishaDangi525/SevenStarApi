using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using SevenStarDtos.Attributes;

namespace SevenStarDtos.DTOs
{
    public class MenuDTO : BaseDTO
    {
        public MenuDTO()
        {
            MenuDetails = new List<MenuDetailsDTO>();

        }
        [IgnoreParam]
        public long MenuId { get; set; }
        [IgnoreParam]
        public int OrderNo { get; set; }
        [IgnoreParam]
        public string MenuName { get; set; }
        [IgnoreParam]
        public string MenuImage { get; set; }
        [IgnoreParam]
        public long SubMenuId { get; set; }
        [IgnoreParam]
        public string SubMenuName { get; set; }
        [IgnoreParam]
        public string SubMenuUrl { get; set; }
        [IgnoreParam]
        public Nullable<bool> IsParent { get; set; }

        [IgnoreParam]
        public List<MenuDetailsDTO> MenuDetails { get; set; }
    }

    public class MenuDetailsDTO
    {
        [IgnoreParam]
        public long SubMenuId { get; set; }
        [IgnoreParam]
        public string SubMenuName { get; set; }
        [IgnoreParam]
        public string SubMenuUrl { get; set; }
        [IgnoreParam] 
        public Nullable<bool> IsParent { get; set; }
    }
}
