
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

using System.Data;
using SevenStarDtos.DTOs;
using SevenStarFramework.Repositories.Interfaces;

namespace SevenStarFramework.Repositories
{
    public class UserRepository : RepositoryBase<LoginDTO, LoginDTO>, IUserRepository
    {
        //Procedure Route
        public UserRepository(IConfiguration configuration) : base(configuration)
        {
            ProcedureName = "GetUserLogin";
        }

        //Login
        public async Task<LoginDTO> GetUserLogin(LoginDTO userDto)
        {
            return await GetByIdAsync(userDto);
        }
        //token
        public async Task<long> SaveRefreshTokenAsync(RefreshTokenDTO refreshTokenDTO)
        {
            return await ExecuteStoredProcedureReturnAsync<RefreshTokenDTO>("SaveUserRefreshToken", refreshTokenDTO);
        }
    } 
}
