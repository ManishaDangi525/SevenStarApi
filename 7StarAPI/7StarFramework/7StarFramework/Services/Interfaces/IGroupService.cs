using SevenStarDtos.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenStarFramework.Services.Interfaces
{
    public interface IGroupService
    {
        //Get All Data
        Task<ReturnObject<List<GroupDTO>>> GetAll(GroupDTO groupDTO);
        //Get Data by  Id
        Task<ReturnObject<GroupDTO>> GetById(long id);
        //Insert Data
        Task<ReturnObject<long>> Insert(GroupDTO groupDTO);
        //Update Data
        Task<ReturnObject<long>> Update(GroupDTO groupDTO);
        //Delete Data by Id
        Task<ReturnObject<bool>> Delete(long id);
        
    }
}
