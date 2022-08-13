using Abp.Modules;
using Abp.Reflection.Extensions;
using Keko.SwaggerApi.Localization;

namespace Keko.SwaggerApi
{
    public class SwaggerApiCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            SwaggerApiLocalizationConfigurer.Configure(Configuration.Localization);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SwaggerApiCoreModule).GetAssembly());
        }
    }
}