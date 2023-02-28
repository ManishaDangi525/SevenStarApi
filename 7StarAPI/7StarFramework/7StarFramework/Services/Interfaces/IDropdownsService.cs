using SevenStarDtos.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenStarFramework.Services.Interfaces
{

    public interface IDropdownsService
    {
        //Get All Data
        Task<ReturnObject<List<DropdownsDTO>>> GetAll(DropdownsDTO dropdownsDTO);
    }
}
