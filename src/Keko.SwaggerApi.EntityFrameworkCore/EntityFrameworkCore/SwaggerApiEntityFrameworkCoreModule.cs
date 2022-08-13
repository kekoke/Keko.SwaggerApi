using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Keko.SwaggerApi.EntityFrameworkCore
{
    [DependsOn(
        typeof(SwaggerApiCoreModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class SwaggerApiEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SwaggerApiEntityFrameworkCoreModule).GetAssembly());
        }
    }
}