using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Keko.SwaggerApi.Web.Startup;
namespace Keko.SwaggerApi.Web.Tests
{
    [DependsOn(
        typeof(SwaggerApiWebModule),
        typeof(AbpAspNetCoreTestBaseModule)
        )]
    public class SwaggerApiWebTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SwaggerApiWebTestModule).GetAssembly());
        }
    }
}