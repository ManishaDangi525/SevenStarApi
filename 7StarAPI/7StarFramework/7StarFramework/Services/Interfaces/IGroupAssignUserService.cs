using SevenStarDtos.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenStarFramework.Services.Interfaces
{
    public interface IGroupAssignUserService
    {
        //Get All Data
        Task<ReturnObject<List<GroupAssignUserDTO>>> GetAll(GroupAssignUserDTO groupAssignUserDTO);
        //Get Data by PurposeId
        Task<ReturnObject<GroupAssignUserDTO>> GetById(long id);
        //Insert Data
        Task<ReturnObject<long>> Insert(GroupAssignUserDTO groupAssignUserDTO);
        //Update Data
        Task<ReturnObject<long>> Update(GroupAssignUserDTO groupAssignUserDTO);
        //Delete Data by Id
        Task<ReturnObject<bool>> Delete(long id);
    }
}
