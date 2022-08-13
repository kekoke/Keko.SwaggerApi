using Keko.SwaggerApi.EntityFrameworkCore;

namespace Keko.SwaggerApi.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly SwaggerApiDbContext _context;

        public TestDataBuilder(SwaggerApiDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            //create test data here...
        }
    }
}