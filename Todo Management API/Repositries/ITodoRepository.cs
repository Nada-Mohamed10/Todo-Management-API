using Todo_Management_API.Enums;
using Todo_Management_API.Models;

namespace Todo_Management_API.Repositries
{
    public interface ITodoRepository : IGenericRepository<Todo>
    {
        Task<IEnumerable<Todo>> GetByStatusAsync(TodoStatus status);

        Task<bool> MarkAsCompletedAsync(Guid id);


    }
}
