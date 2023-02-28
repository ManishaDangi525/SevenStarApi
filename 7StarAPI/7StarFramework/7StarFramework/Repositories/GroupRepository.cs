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
    public class GroupRepository : RepositoryBase<GroupDTO, GroupDTO>, IGroupRepository
    {
        //Procedure Route
        public GroupRepository(IConfiguration configuration) : base(configuration)
        {
            ProcedureName = "Group_crud";
        }
    }
}
