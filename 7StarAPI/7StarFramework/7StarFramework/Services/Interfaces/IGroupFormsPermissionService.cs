using SevenStarDtos.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenStarFramework.Services.Interfaces
{
    public interface IGroupFormsPermissionService
    {
        //Get All Data
        Task<ReturnObject<List<GroupFormsPermissionDTO>>> GetAll(GroupFormsPermissionDTO userPermissionDTO);
        //Get Data by PurposeId
        Task<ReturnObject<GroupFormsPermissionDTO>> GetById(long id);
        //Insert Data
        Task<ReturnObject<long>> Insert(GroupFormsPermissionDTO userPermissionDTO);
        //Update Data
        Task<ReturnObject<long>> Update(GroupFormsPermissionDTO userPermissionDTO);
        //Delete Data by Id
        Task<ReturnObject<bool>> Delete(long id);
    }
}
