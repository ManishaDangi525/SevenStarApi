using SevenStarDtos.DTOs;
using SevenStarFramework.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenStarFramework.Repositories
{
    public class MenusRepository : RepositoryBase<MenuDTO, MenuDTO>, IMenusRepository
    {
        //Procedure Route
        public MenusRepository(IConfiguration configuration) : base(configuration)
        {
            ProcedureName = "GetMenusList";
        }
    }
}
