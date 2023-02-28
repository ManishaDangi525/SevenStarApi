using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SevenStarFramework.Repositories;
using SevenStarFramework.Repositories.Interfaces;
using SevenStarFramework.Services;
using SevenStarFramework.Services.Interfaces;


namespace SevenStarFramework.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddTransactionFramework(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(typeof(IUserService), typeof(UserService));
            services.AddTransient(typeof(IUserRepository), typeof(UserRepository));

            services.AddTransient(typeof(IDropdownsRepository), typeof(DropdownsRepository));
            services.AddTransient(typeof(IDropdownsService), typeof(DropdownsService));
      
             

            services.AddTransient(typeof(IGroupAssignUserRepository), typeof(GroupAssignUserRepository));
            services.AddTransient(typeof(IGroupAssignUserService), typeof(GroupAssignUserService));            

            

            services.AddTransient(typeof(IGroupRepository), typeof(GroupRepository));
            services.AddTransient(typeof(IGroupService), typeof(GroupService));

            services.AddTransient(typeof(IMenusRepository), typeof(MenusRepository));
            services.AddTransient(typeof(IMenusService), typeof(MenusService));

            services.AddTransient(typeof(IGroupFormsPermissionRepository), typeof(GroupFormsPermissionRepository));
            services.AddTransient(typeof(IGroupFormsPermissionService), typeof(GroupFormsPermissionService));
       

      return services;
        }
    }
}
