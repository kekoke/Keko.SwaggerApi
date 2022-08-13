using System.Threading.Tasks;
using Keko.SwaggerApi.Web.Controllers;
using Shouldly;
using Xunit;

namespace Keko.SwaggerApi.Web.Tests.Controllers
{
    public class HomeController_Tests: SwaggerApiWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
