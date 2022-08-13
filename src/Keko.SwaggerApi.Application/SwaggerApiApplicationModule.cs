using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Keko.SwaggerApi
{
    [DependsOn(
        typeof(SwaggerApiCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class SwaggerApiApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SwaggerApiApplicationModule).GetAssembly());
        }
    }
}