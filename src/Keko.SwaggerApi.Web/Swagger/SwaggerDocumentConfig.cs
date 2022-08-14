namespace Keko.SwaggerApi.Web.Swagger
{
    public class SwaggerDocumentConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public DefaultGroup DefaultGroup { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string IsEndableGroup { get; set; }
    }


    public class DefaultGroup
    {
        /// <summary>
        /// 
        /// </summary>
        public string Group { get; set; }
        /// <summary>
        /// 所有服务
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 所有服务
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Order { get; set; }
    }

   
    
}
