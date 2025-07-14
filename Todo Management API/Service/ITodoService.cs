using Todo_Management_API.DTOs;
using Todo_Management_API.Enums;

namespace Todo_Management_API.Service
{
    public interface ITodoService
    {
        Task<IEnumerable<ReadTodoDto>> GetAllTodosAsync();
        Task<ReadTodoDto?> GetTodoByIdAsync(Guid id);
        Task<ReadTodoDto> AddTodoAsync(CreateTodoDto todo);
        Task<bool> UpdateAsync(UpdateTodoDto todo);
        Task<bool> DeleteAsync(Guid id);

        Task<IEnumerable<ReadTodoDto>> GetTodosByStatusAsync(TodoStatus status);
        Task<bool> MarkAsCompletedAsync(Guid id);
    }
}
