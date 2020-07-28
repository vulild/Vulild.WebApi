using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vulild.Service;
using Vulild.Service.AssemblyService;

namespace Vulild.WebApi
{
    public static class ControllerRegister
    {
        public static IMvcBuilder AddAssemblyControllers(this IMvcBuilder mvcBuilder)
        {
            var assemblySearch = ServiceUtil.GetService<IAssemblySearch>();
            assemblySearch.AssemblyDeal += assembly =>
            {
                mvcBuilder.ConfigureApplicationPartManager(apm =>
                {
                    apm.ApplicationParts.Add(new AssemblyPart(assembly));
                    Console.WriteLine(assembly.FullName);
                });
            };
            return mvcBuilder;
        }

    }
}
