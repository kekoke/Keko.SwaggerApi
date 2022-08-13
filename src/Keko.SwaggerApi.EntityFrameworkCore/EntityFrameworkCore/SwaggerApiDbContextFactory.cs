using Keko.SwaggerApi.Configuration;
using Keko.SwaggerApi.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Keko.SwaggerApi.EntityFrameworkCore
{
    /* This class is needed to run EF Core PMC commands. Not used anywhere else */
    public class SwaggerApiDbContextFactory : IDesignTimeDbContextFactory<SwaggerApiDbContext>
    {
        public SwaggerApiDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SwaggerApiDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DbContextOptionsConfigurer.Configure(
                builder,
                configuration.GetConnectionString(SwaggerApiConsts.ConnectionStringName)
            );

            return new SwaggerApiDbContext(builder.Options);
        }
    }
}