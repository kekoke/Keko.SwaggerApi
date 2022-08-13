using Abp.Application.Services;
using Keko.SwaggerApi.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Keko.SwaggerApi
{
    public interface ITodoAppService : IApplicationService
    {
        Task<List<TodoItemDto>> GetListAsync();
        Task<TodoItemDto> CreateAsync(SwaggerApi.Dto.CreateTodoItemInput input);
        Task DeleteAsync(int id);
    }
}
