using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Keko.SwaggerApi.Configuration;
using Keko.SwaggerApi.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;

namespace Keko.SwaggerApi.Web.Startup
{
    [DependsOn(
        typeof(SwaggerApiApplicationModule), 
        typeof(SwaggerApiEntityFrameworkCoreModule), 
        typeof(AbpAspNetCoreModule))]
    public class SwaggerApiWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public SwaggerApiWebModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(SwaggerApiConsts.ConnectionStringName);

            Configuration.Navigation.Providers.Add<SwaggerApiNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(SwaggerApiApplicationModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SwaggerApiWebModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(SwaggerApiWebModule).Assembly);
        }
    }
}