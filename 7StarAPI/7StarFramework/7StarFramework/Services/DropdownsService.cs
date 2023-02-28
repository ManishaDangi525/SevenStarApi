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
    public class DropdownsService : IDropdownsService
    {
        private readonly AppSettings _appSettings;
        private IDropdownsRepository _repository;
        public DropdownsService(IDropdownsRepository repository, IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _repository = repository;
        }

        //Get All Dropdowns Data
        public async Task<ReturnObject<List<DropdownsDTO>>> GetAll(DropdownsDTO dropdownsDTO)
        {
            var response = await _repository.GetAllAsync(dropdownsDTO);

            if (response.Count <= 0)
                throw new AppException($"Dropdown details {StringConstants.RecordNotFound}");

            return new ReturnObject<List<DropdownsDTO>>
            {
                ReturnValue = response,
                Status = true,
                Success = true
            };
        }
    }
}
