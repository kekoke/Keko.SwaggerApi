using Abp.Application.Services;

namespace Keko.SwaggerApi
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class SwaggerApiAppServiceBase : ApplicationService
    {
        protected SwaggerApiAppServiceBase()
        {
            LocalizationSourceName = SwaggerApiConsts.LocalizationSourceName;
        }
    }
}