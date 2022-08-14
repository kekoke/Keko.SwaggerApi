using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Keko.SwaggerApi.Web.Swagger.Filter
{
    /// <summary>
    /// Api分组过滤器
    /// </summary>
    public class ApiFilter : IDocumentFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="swaggerDoc"></param>
        /// <param name="context"></param>
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            if (context.DocumentName == swaggerDoc.Info.Version)
            {
                foreach (var apiDescription in context.ApiDescriptions)
                {
                    if (context.DocumentName.Equals("all"))
                    {
                        return;
                    }
                    if (!string.IsNullOrEmpty(apiDescription.GroupName) && apiDescription.GroupName != context.DocumentName)
                    {
                        swaggerDoc.Paths.Remove("/" + apiDescription.RelativePath);
                    }
                }
            }
        }
    }
}
