using Keko.SwaggerApi.Common.Swagger.Attribute;
using Keko.SwaggerApi.Web.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Keko.SwaggerApi.Web.Swagger
{
    /// <summary>
    /// 
    /// </summary>
    public class SwaggerDocumentBuilder
    {
        private static List<SwaggerOpenApiInfo> _openApiInfos;
        private static SwaggerDocumentConfig _documentConfig;

        static SwaggerDocumentBuilder()
        {
            var configuration = ServiceLocator.Instance.GetService<IConfigurationRoot>();
            //_documentConfig = configuration.GetSection("SwaggerDocument").Get<SwaggerDocumentConfig>();
            _documentConfig = new SwaggerDocumentConfig()
            {
                DefaultGroup = new DefaultGroup
                {
                    Description = "所有服务",
                    Group = "all",
                    Order = 1,
                    Title = "所有服务"
                }
            };
        }


        public static List<SwaggerOpenApiInfo> OpenApiInfos
        {
            get
            {
                if (_openApiInfos == null)
                {
                    var assemllies = SwaggerDocumentBuilder.GetApiAssemblys();
                    _openApiInfos = SwaggerDocumentBuilder.GetGroups(assemllies);
                }
                return _openApiInfos;
            }
        }

        private static List<Assembly> GetApiAssemblys()
        {
            var assemllies = AppDomain.CurrentDomain.GetAssemblies().ToList();

            assemllies = assemllies.Where(c => c.GetName().Name.EndsWith(".Application")
                                       || c.GetName().Name.EndsWith(".Api")
                                       || c.GetName().Name.EndsWith(".Web"))
                                      .ToList();
            return assemllies;
        }

        private static List<SwaggerOpenApiInfo> GetGroups(List<Assembly> assemblies)
        {
            // 如果没有定义 ApiDescriptionSettings，则返回默认分组           
            List<SwaggerOpenApiInfo> groups = new List<SwaggerOpenApiInfo>();
            foreach (var item in assemblies)
            {
                var types = item.GetTypes();
                foreach (var type in types)
                {
                    var apiDescriptionSettings = type.GetCustomAttribute<ApiDescriptionSettingsAttribute>(true);
                    if (apiDescriptionSettings == null || string.IsNullOrEmpty(apiDescriptionSettings.GroupName))
                        continue;

                    groups.Add(new SwaggerOpenApiInfo() { Order = apiDescriptionSettings.Order, Description = apiDescriptionSettings.Description, Version = apiDescriptionSettings.GroupName, Title = apiDescriptionSettings.Group });
                }

            }
            //var defaultGroup = new SwaggerOpenApiInfo { Version = "all", Title = "所有服务", Description = "所有服务" };
            var defaultGroup = new SwaggerOpenApiInfo { Version = _documentConfig.DefaultGroup.Group, Title = _documentConfig.DefaultGroup.Title, Description = _documentConfig.DefaultGroup.Description, Order = _documentConfig.DefaultGroup.Order };
            if (groups.Count > 1)
            {
                //排序
                groups = groups.OrderByDescending(c => c.Order).ToList();
            }

            groups.Add(defaultGroup);
            return groups;
        }


    }
}
