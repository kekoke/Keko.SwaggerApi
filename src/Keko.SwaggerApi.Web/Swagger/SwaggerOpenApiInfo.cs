namespace Keko.SwaggerApi.Web.Swagger
{
    /// <summary>
    /// 
    /// </summary>
    public class SwaggerOpenApiInfo
    {
        //
        // 摘要:
        //     A short description of the application.
        public string Description { get; set; }

        //
        // 摘要:
        //     REQUIRED. The version of the OpenAPI document.
        public string Version { get; set; }

        //
        // 摘要:
        //     REQUIRED. The title of the application.
        public string Title { get; set; }

        /// <summary>
        /// 排序，数值越大在前
        /// </summary>
        public int Order { get; set; }

    }
}
