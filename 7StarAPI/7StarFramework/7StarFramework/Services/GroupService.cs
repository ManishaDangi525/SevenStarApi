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
    public class GroupService : IGroupService
    {
        private readonly AppSettings _appSettings;
        private IGroupRepository _repository;
        public GroupService(IGroupRepository repository, IOptions<AppSettings> appSettings)
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
                Message = $"Group {StringConstants.DeleteSuccess}",
                ReturnValue = response,
                Status = true,
                Success = true
            };
        }

        //Get All data
        public async Task<ReturnObject<List<GroupDTO>>> GetAll(GroupDTO groupDTO)
        {
            var response = await _repository.GetAllAsync(groupDTO);

            if (response.Count <= 0)
                throw new AppException($"Group {StringConstants.RecordNotFound}");

            return new ReturnObject<List<GroupDTO>>
            {
                ReturnValue = response,
                Status = true,
                Success = true
            };
        }

        //Edit 
        public async Task<ReturnObject<GroupDTO>> GetById(long id)
        {
            var response = await _repository.GetByIdAsync(id);

            if (response == null)
                throw new AppException($"Group {StringConstants.RecordNotFound}");

            return new ReturnObject<GroupDTO>
            {
                ReturnValue = response,
                Status = true,
                Success = true
            };
        }

        //Insert
        public async Task<ReturnObject<long>> Insert(GroupDTO groupDTO)
        {
            if (groupDTO.GroupName == "" || groupDTO.GroupName == null)
                throw new AppException($"Please enter name!");

            var response = await _repository.InsertAsync(groupDTO);

            if (response == 0)
                throw new AppException($"Group {StringConstants.SavedFailed}");
            else if (response == -2)
                throw new AppException($"Group {StringConstants.AlreadyExists}");

            return new ReturnObject<long>
            {
                Message = $"Group {StringConstants.SavedSuccess}",
                ReturnValue = response,
                Status = true,
                Success = true
            };
        }

        //Update
        public async Task<ReturnObject<long>> Update(GroupDTO groupDTO)
        {
            if (groupDTO.GroupName == "" || groupDTO.GroupName == null)
                throw new AppException($"Please enter name!");

            var response = await _repository.UpdateAsync(groupDTO);

            if (response == 0)
                throw new AppException($"Group {StringConstants.UpdateFailed}");
            else if (response == -2)
                throw new AppException($"Group {StringConstants.AlreadyExists}");

            return new ReturnObject<long>
            {
                Message = $"Group {StringConstants.UpdateSuccess}",
                ReturnValue = response,
                Status = true,
                Success = true
            };
        }
         
    }
}
