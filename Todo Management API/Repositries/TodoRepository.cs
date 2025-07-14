using Microsoft.EntityFrameworkCore;
using Todo_Management_API.Enums;
using Todo_Management_API.Models;

namespace Todo_Management_API.Repositries
{
    public class TodoRepository : GenericRepository<Todo>, ITodoRepository
    {
        public TodoRepository(AppDbContext db) : base(db)
        {
        }

        public async Task<IEnumerable<Todo>> GetByStatusAsync(TodoStatus status)
        {
            return await db.Todos
            .Where(t => t.Status == status)
            .ToListAsync();
        }

        public async Task<bool> MarkAsCompletedAsync(Guid id)
        {
            var todo = await db.Todos.FindAsync(id);
            if (todo == null)
            {
                return false;
            }
            todo.Status = TodoStatus.Completed;
            todo.LastModifiedDate = DateTime.UtcNow;
            return true;
        }
    }
}
