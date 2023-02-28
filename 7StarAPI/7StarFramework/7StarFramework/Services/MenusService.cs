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
    public class MenusService : IMenusService
    {
        private readonly AppSettings _appSettings;
        private IMenusRepository _repository;
        public MenusService(IMenusRepository repository, IOptions<AppSettings> appSettings)
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
                Message = $"Module {StringConstants.DeleteSuccess}",
                ReturnValue = response,
                Status = true,
                Success = true
            };
        }

        //Get All data
        public async Task<ReturnObject<List<MenuDTO>>> GetAll(MenuDTO MenusDTO)
        {
            var response = await _repository.GetAllAsync(MenusDTO); 

            var groupedList = response.GroupBy(x => new { x.MenuId, x.MenuName, x.MenuImage, x.OrderNo }).ToList();

            //List of New model
            List<MenuDTO> result = new List<MenuDTO>();
            MenuDTO menuDTO;

            foreach (var item in groupedList)
            {
                menuDTO = new MenuDTO
                {
                    MenuId = item.Key.MenuId,
                    MenuName = item.Key.MenuName,
                    MenuImage = item.Key.MenuImage,
                    OrderNo = item.Key.OrderNo,

                    MenuDetails = item.Select(x => new MenuDetailsDTO
                    {
                        SubMenuId = x.SubMenuId,
                        SubMenuName = x.SubMenuName,
                        SubMenuUrl = x.SubMenuUrl,
                        IsParent = x.IsParent


                    }).ToList()
                };
                result.Add(menuDTO);
            }

            if (response.Count <= 0)
                throw new AppException($"Menu List {StringConstants.RecordNotFound}");

            return new ReturnObject<List<MenuDTO>>
            {
                ReturnValue = result,
                Status = true,
                Success = true
            };

            //if (response.Count <= 0)
            //    throw new AppException($"Module {StringConstants.RecordNotFound}");

            //return new ReturnObject<List<MenuDTO>>
            //{
            //    ReturnValue = response,
            //    Status = true,
            //    Success = true
            //};
        }

        //Edit 
        public async Task<ReturnObject<MenuDTO>> GetById(long id)
        {
            var response = await _repository.GetByIdAsync(id);

            if (response == null)
                throw new AppException($"Module {StringConstants.RecordNotFound}");

            return new ReturnObject<MenuDTO>
            {
                ReturnValue = response,
                Status = true,
                Success = true
            };
        }

        //Insert
        public async Task<ReturnObject<long>> Insert(MenuDTO MenusDTO)
        {
             
            var response = await _repository.InsertAsync(MenusDTO);

            if (response == 0)
                throw new AppException($"Module {StringConstants.SavedFailed}");
            else if (response == -2)
                throw new AppException($"Module {StringConstants.AlreadyExists}");

            return new ReturnObject<long>
            {
                Message = $"Module {StringConstants.SavedSuccess}",
                ReturnValue = response,
                Status = true,
                Success = true
            };
        }

        //Update
        public async Task<ReturnObject<long>> Update(MenuDTO MenusDTO)
        {
            

            var response = await _repository.UpdateAsync(MenusDTO);

            if (response == 0)
                throw new AppException($"Module {StringConstants.UpdateFailed}");
            else if (response == -2)
                throw new AppException($"Module {StringConstants.AlreadyExists}");

            return new ReturnObject<long>
            {
                Message = $"Module {StringConstants.UpdateSuccess}",
                ReturnValue = response,
                Status = true,
                Success = true
            };
        }
        //Get All data
        public async Task<ReturnObject<List<MenuDTO>>> GetMenu(MenuDTO MenusDTO)
        {

            var response = await _repository.GetAllAsync(MenusDTO);

            var groupedList = response.GroupBy(x => new { x.MenuId, x.MenuName, x.MenuImage, x.OrderNo }).ToList();
             
            //List of New model
            List<MenuDTO> result = new List<MenuDTO>();
            MenuDTO menuDTO;

            foreach (var item in groupedList)
            {
                menuDTO = new MenuDTO
                {
                    MenuId = item.Key.MenuId,
                    MenuName = item.Key.MenuName,
                    MenuImage = item.Key.MenuImage,
                    OrderNo = item.Key.OrderNo,

                    MenuDetails = item.Select(x => new MenuDetailsDTO
                    {
                        SubMenuId = x.SubMenuId,
                        SubMenuName = x.SubMenuName,
                        SubMenuUrl = x.SubMenuUrl ,
                        IsParent = x.IsParent


                    }).ToList()
                };
                result.Add(menuDTO);
            }

            if (response.Count <= 0)
                throw new AppException($"Menu List {StringConstants.RecordNotFound}");

            return new ReturnObject<List<MenuDTO>>
            {
                ReturnValue = result,
                Status = true,
                Success = true
            };
        }

    }
}
