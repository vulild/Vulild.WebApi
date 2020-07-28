using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Text.Json.Serialization;
using Vulild.Core.FormatConversion;
using Vulild.Service;
using Vulild.Service.Services;

namespace Vulild.WebApi
{
    public static class ServiceRegister
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            string typeStr = configuration["InitOptionType"];
            var optionObj = configuration.GetSection("InitOption").Get(typeStr.ToType());
            if (optionObj is Option initOption)
            {
                IServiceInitService service = initOption.Build() as IServiceInitService;
                if (service != null)
                {
                    var tempOptions = service.GetOptions();
                    ServiceUtil.InitService(options =>
                    {
                        foreach (var option in tempOptions)
                        {
                            options.Add(option.Key, option.Value);
                        }
                    });
                }
            }

        }
    }
}
