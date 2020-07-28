using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vulild.Service;
using Vulild.Service.AssemblyService;

namespace Vulild.WebApi
{
    public static class AssemblySearchExtension
    {
        public static void UserAssemblySearch(this IApplicationBuilder app)
        {
            var assemblySearch = ServiceUtil.GetService<IAssemblySearch>();
            assemblySearch.Search();
        }
    }
}
