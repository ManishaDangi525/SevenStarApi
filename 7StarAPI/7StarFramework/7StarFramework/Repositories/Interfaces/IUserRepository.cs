
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SevenStarDtos.DTOs;

namespace SevenStarFramework.Repositories.Interfaces
{
    
    public interface IUserRepository : IRepositoryBase<LoginDTO, LoginDTO>
    {
        //User Login
        Task<LoginDTO> GetUserLogin(LoginDTO userDto);
        //Token
        Task<long> SaveRefreshTokenAsync(RefreshTokenDTO refreshTokenDTO);

    }
}
