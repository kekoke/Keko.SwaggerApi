using Abp.Application.Services;
using Abp.Domain.Repositories;
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
    public class TodoAppService : SwaggerApiAppServiceBase, ITodoAppService
    {
        private readonly IRepository<TodoItem, int> _todoItemRepository;

        public TodoAppService(IRepository<TodoItem, int> todoItemRepository)
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

        public async Task<TodoItemDto> CreateAsync(CreateTodoItemInput  input)
        {
            var todoItem = await _todoItemRepository.InsertAsync(
                new TodoItem { Id= int.Parse(DateTime.Now.ToString("HHmmdd")) ,Text = input.Text, CreationTime = DateTime.Now }
            );

            return new TodoItemDto
            {
                Id = todoItem.Id,
                Text = todoItem.Text
            };
        }

        public async Task DeleteAsync(int id)
        {
            await _todoItemRepository.DeleteAsync(id);
        }
    }
}
