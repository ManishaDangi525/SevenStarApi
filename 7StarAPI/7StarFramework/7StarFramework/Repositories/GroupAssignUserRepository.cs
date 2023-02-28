 
using SevenStarFramework.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SevenStarDtos.DTOs;

namespace SevenStarFramework.Repositories
{
    public class GroupAssignUserRepository : RepositoryBase<GroupAssignUserDTO, GroupAssignUserDTO>, IGroupAssignUserRepository
    {
        //Procedure Route
        public GroupAssignUserRepository(IConfiguration configuration) : base(configuration)
        {
            ProcedureName = "GroupAssignUser";
        }
    }
}
