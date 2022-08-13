using System;
using System.Threading.Tasks;
using Abp.TestBase;
using Keko.SwaggerApi.EntityFrameworkCore;
using Keko.SwaggerApi.Tests.TestDatas;

namespace Keko.SwaggerApi.Tests
{
    public class SwaggerApiTestBase : AbpIntegratedTestBase<SwaggerApiTestModule>
    {
        public SwaggerApiTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual void UsingDbContext(Action<SwaggerApiDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<SwaggerApiDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<SwaggerApiDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<SwaggerApiDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<SwaggerApiDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<SwaggerApiDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<SwaggerApiDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<SwaggerApiDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
