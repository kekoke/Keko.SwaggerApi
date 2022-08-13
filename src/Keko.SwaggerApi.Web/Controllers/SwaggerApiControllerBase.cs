using Abp.AspNetCore.Mvc.Controllers;

namespace Keko.SwaggerApi.Web.Controllers
{
    public abstract class SwaggerApiControllerBase: AbpController
    {
        protected SwaggerApiControllerBase()
        {
            LocalizationSourceName = SwaggerApiConsts.LocalizationSourceName;
        }
    }
}