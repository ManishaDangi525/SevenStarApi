
using Microsoft.Extensions.Configuration;
using SevenStarDtos.DTOs;
using SevenStarFramework.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenStarFramework.Repositories
{
    public class DropdownsRepository : RepositoryBase<DropdownsDTO, DropdownsDTO>, IDropdownsRepository
    {
        //Procedure Route
        public DropdownsRepository(IConfiguration configuration) : base(configuration)
        {
            ProcedureName = "Dropdowns";
        }
    }
}
