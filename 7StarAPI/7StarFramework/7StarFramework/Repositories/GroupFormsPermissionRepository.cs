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
    public class GroupFormsPermissionRepository : RepositoryBase<GroupFormsPermissionDTO, GroupFormsPermissionDTO>, IGroupFormsPermissionRepository
    {
        //Procedure Route
        public GroupFormsPermissionRepository(IConfiguration configuration) : base(configuration)
        {
            ProcedureName = "GroupFormsPermission_crud";
        }
    }
}
