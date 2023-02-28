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
    public class GroupFormsPermissionService : IGroupFormsPermissionService
    {
        private readonly AppSettings _appSettings;
        private IGroupFormsPermissionRepository _repository;
        public GroupFormsPermissionService(IGroupFormsPermissionRepository repository, IOptions<AppSettings> appSettings)
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
                Message = $"User Permission {StringConstants.DeleteSuccess}",
                ReturnValue = response,
                Status = true,
                Success = true
            };
        }

        //Get All data
        public async Task<ReturnObject<List<GroupFormsPermissionDTO>>> GetAll(GroupFormsPermissionDTO userPermissionDTO)
        {
            var response = await _repository.GetAllAsync(userPermissionDTO);

            if (response.Count <= 0)
                throw new AppException($"User Permission {StringConstants.RecordNotFound}");

            return new ReturnObject<List<GroupFormsPermissionDTO>>
            {
                ReturnValue = response,
                Status = true,
                Success = true
            };
        }

        //Edit 
        public async Task<ReturnObject<GroupFormsPermissionDTO>> GetById(long id)
        {
            var response = await _repository.GetByIdAsync(id);

            if (response == null)
                throw new AppException($"User Permission {StringConstants.RecordNotFound}");

            return new ReturnObject<GroupFormsPermissionDTO>
            {
                ReturnValue = response,
                Status = true,
                Success = true
            };
        }

        //Insert
        public async Task<ReturnObject<long>> Insert(GroupFormsPermissionDTO userPermissionDTO)
        {
            //if (userPermissionDTO. == "" || userPermissionDTO.Name == null)
            //    throw new AppException($"Please enter name!");

            var response = await _repository.InsertAsync(userPermissionDTO);

            if (response == 0)
                throw new AppException($"User Permission {StringConstants.SavedFailed}");
            else if (response == -2)
                throw new AppException($"User Permission {StringConstants.AlreadyExists}");

            return new ReturnObject<long>
            {
                Message = $"User Permission {StringConstants.SavedSuccess}",
                ReturnValue = response,
                Status = true,
                Success = true
            };
        }

        //Update
        public async Task<ReturnObject<long>> Update(GroupFormsPermissionDTO userPermissionDTO)
        {
            //if (userPermissionDTO.Name == "" || userPermissionDTO.Name == null)
            //    throw new AppException($"Please enter name!");

            var response = await _repository.UpdateAsync(userPermissionDTO);

            if (response == 0)
                throw new AppException($"User Permission {StringConstants.UpdateFailed}");
            else if (response == -2)
                throw new AppException($"User Permission {StringConstants.AlreadyExists}");

            return new ReturnObject<long>
            {
                Message = $"User Permission {StringConstants.UpdateSuccess}",
                ReturnValue = response,
                Status = true,
                Success = true
            };
        }
    }
}
