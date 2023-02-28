using SevenStarDtos.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenStarFramework.Services.Interfaces
{
    public interface IMenusService
    {
        //Get All Data
        Task<ReturnObject<List<MenuDTO>>> GetAll(MenuDTO menuDTO);
        //Get Data by PurposeId
        Task<ReturnObject<MenuDTO>> GetById(long id);
        //Insert Data
        Task<ReturnObject<long>> Insert(MenuDTO menuDTO);
        //Update Data
        Task<ReturnObject<long>> Update(MenuDTO menuDTO);
        //Delete Data by Id
        Task<ReturnObject<bool>> Delete(long id);
        
    }
}
