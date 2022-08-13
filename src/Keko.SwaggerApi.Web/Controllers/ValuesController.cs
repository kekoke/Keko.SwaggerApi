using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Keko.SwaggerApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public List<string> Get()
        {
            var list = new List<string> { };
            list.Add("1");
            return list;
        }
    }
}
