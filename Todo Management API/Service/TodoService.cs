using AutoMapper;
using Todo_Management_API.DTOs;
using Todo_Management_API.Enums;
using Todo_Management_API.Models;
using Todo_Management_API.Unit_of_works;

namespace Todo_Management_API.Service
{
    public class TodoService : ITodoService
    {
        public readonly IUnitOfWork unit;
        public readonly IMapper map;
        public TodoService(IUnitOfWork unit , IMapper map)
        {
            this.unit = unit;
            this.map = map;
        }
        public async Task<ReadTodoDto> AddTodoAsync(CreateTodoDto todo)
        {
            var todoEntity = map.Map<Todo>(todo);
            todoEntity.Id = Guid.NewGuid();
            todoEntity.CreatedDate = DateTime.UtcNow;
            todoEntity.LastModifiedDate = DateTime.UtcNow;

            await unit.Todos.AddAsync(todoEntity);
            await unit.CompleteAsync();

            return map.Map<ReadTodoDto>(todoEntity);


        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var Todo = await unit.Todos.GetByIdAsync(id);
            if (Todo == null)
                return false;
            unit.Todos.Delete(id);
            await unit.CompleteAsync();
            return true;

        }

        public async Task<IEnumerable<ReadTodoDto>> GetAllTodosAsync()
        {
            var todos = await unit.Todos.GetAllAsync();
            return map.Map<IEnumerable<ReadTodoDto>>(todos);
        }

        public Task<ReadTodoDto?> GetTodoByIdAsync(Guid id)
        {
            var todo = unit.Todos.GetByIdAsync(id);
            if (todo == null)
            {
                return Task.FromResult<ReadTodoDto?>(null);
            }
            return Task.FromResult(map.Map<ReadTodoDto>(todo.Result));
        }

        public async Task<IEnumerable<ReadTodoDto>> GetTodosByStatusAsync(TodoStatus status)
        {
            var todos = await unit.Todos.GetByStatusAsync(status);
            return map.Map<IEnumerable<ReadTodoDto>>(todos);
        }

        public async Task<bool> MarkAsCompletedAsync(Guid id)
        {
            var result = await unit.MarkTodoAsCompletedAsync(id);

            if (!result) return false;
            var todo = await unit.Todos.GetByIdAsync(id);
            if (todo == null) return false;
            await unit.CompleteAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(UpdateTodoDto todo)
        {
            var todoEntity = await unit.Todos.GetByIdAsync(todo.Id);
            if (todoEntity == null) return false;
            map.Map(todo, todoEntity);
            todoEntity.LastModifiedDate = DateTime.UtcNow;
            unit.Todos.Update(todoEntity);
            await unit.CompleteAsync();
            return true;

        }




    }
}
