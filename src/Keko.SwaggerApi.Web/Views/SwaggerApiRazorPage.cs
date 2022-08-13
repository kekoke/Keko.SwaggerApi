using Abp.AspNetCore.Mvc.Views;

namespace Keko.SwaggerApi.Web.Views
{
    public abstract class SwaggerApiRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected SwaggerApiRazorPage()
        {
            LocalizationSourceName = SwaggerApiConsts.LocalizationSourceName;
        }
    }
}
