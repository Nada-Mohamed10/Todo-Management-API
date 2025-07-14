using Todo_Management_API.Models;
using Todo_Management_API.Repositries;

namespace Todo_Management_API.Unit_of_works
{
    public interface IUnitOfWork
    {
        ITodoRepository Todos { get; }
        Task<int> CompleteAsync();
        Task<bool> MarkTodoAsCompletedAsync(Guid id);

    }
}
