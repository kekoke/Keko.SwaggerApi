using Abp.Application.Services;
using Abp.Domain.Repositories;
using Keko.SwaggerApi.Common.Swagger.Attribute;
using Keko.SwaggerApi.Core.Entities;
using Keko.SwaggerApi.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keko.SwaggerApi
{
    [ApiDescriptionSettings(GroupName = "task", Group = "任务服务", Order = 9)]
    public class TaskAppServies : SwaggerApiAppServiceBase
    {
        private readonly IRepository<TodoItem, int> _todoItemRepository;

        public TaskAppServies(IRepository<TodoItem, int> todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        public async Task<List<TodoItemDto>> GetListAsync()
        {
            var items = _todoItemRepository.GetAll();
            return await items
                .Select(item => new TodoItemDto
                {
                    Id = item.Id,
                    Text = item.Text
                }).ToListAsync();
        }
    }
}
