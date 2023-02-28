using SevenStarDtos.DTOs;
using SevenStarFramework.Repositories.Interfaces;
using SevenStarFramework.Services.Interfaces;
using SevenStarFramework.Type;
using SevenStarFramework.Utils;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenStarFramework.Services
{
    public class GroupAssignUserService : IGroupAssignUserService
    {
        private readonly AppSettings _appSettings;
        private IGroupAssignUserRepository _repository;
        public GroupAssignUserService(IGroupAssignUserRepository repository, IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _repository = repository;
        }


        //Delete 
        public async Task<ReturnObject<bool>> Delete(long id)
        {
            var response = await _repository.DeleteAsync(id);

            if (!response)
                throw new AppException(StringConstants.DeletionFailed);

            return new ReturnObject<bool>
            {
                Message = $"Group Assign User {StringConstants.DeleteSuccess}",
                ReturnValue = response,
                Status = true,
                Success = true
            };
        }

        //Get All data
        public async Task<ReturnObject<List<GroupAssignUserDTO>>> GetAll(GroupAssignUserDTO groupAssignUserDTO)
        {
            var response = await _repository.GetAllAsync(groupAssignUserDTO);

            if (response.Count <= 0)
                throw new AppException($"Group Assign User {StringConstants.RecordNotFound}");

            return new ReturnObject<List<GroupAssignUserDTO>>
            {
                ReturnValue = response,
                Status = true,
                Success = true
            };
        }

        //Edit 
        public async Task<ReturnObject<GroupAssignUserDTO>> GetById(long id)
        {
            var response = await _repository.GetByIdAsync(id);

            if (response == null)
                throw new AppException($"Group Assign User {StringConstants.RecordNotFound}");

            return new ReturnObject<GroupAssignUserDTO>
            {
                ReturnValue = response,
                Status = true,
                Success = true
            };
        }

        //Insert
        public async Task<ReturnObject<long>> Insert(GroupAssignUserDTO groupAssignUserDTO)
        {
             

            var response = await _repository.InsertAsync(groupAssignUserDTO);

            if (response == 0)
                throw new AppException($"Group Assign User {StringConstants.SavedFailed}");
            else if (response == -2)
                throw new AppException($"Group Assign User {StringConstants.AlreadyExists}");

            return new ReturnObject<long>
            {
                Message = $"Group Assign User {StringConstants.SavedSuccess}",
                ReturnValue = response,
                Status = true,
                Success = true
            };
        }

        //Update
        public async Task<ReturnObject<long>> Update(GroupAssignUserDTO groupAssignUserDTO)
        {
            
            var response = await _repository.UpdateAsync(groupAssignUserDTO);

            if (response == 0)
                throw new AppException($"Group Assign User {StringConstants.UpdateFailed}");
            else if (response == -2)
                throw new AppException($"Group Assign User {StringConstants.AlreadyExists}");

            return new ReturnObject<long>
            {
                Message = $"Group Assign User {StringConstants.UpdateSuccess}",
                ReturnValue = response,
                Status = true,
                Success = true
            };
        }
    }
}
