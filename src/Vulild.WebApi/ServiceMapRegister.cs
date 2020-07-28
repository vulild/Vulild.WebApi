using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vulild.Service;
using Vulild.Service.AssemblyService;

namespace Vulild.WebApi
{
    public static class ServiceMapRegister
    {
        public static void AddServiceMap(this IServiceCollection services)
        {
            var assemblySearch = ServiceUtil.GetService<IAssemblySearch>();
            assemblySearch.TypeDeal += ServiceUtil.TypeDeal;
        }
    }
}
