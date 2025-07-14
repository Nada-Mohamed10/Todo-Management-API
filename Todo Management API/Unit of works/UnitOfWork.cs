using Microsoft.EntityFrameworkCore;
using Todo_Management_API.Models;
using Todo_Management_API.Repositries;

namespace Todo_Management_API.Unit_of_works
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext db;
        public ITodoRepository Todos { get; }


        public UnitOfWork(AppDbContext db , ITodoRepository Todos)
        {
            this.db = db;
            this.Todos = Todos;
        }
        public  async Task<int> CompleteAsync()
        {
            return await db.SaveChangesAsync();
        }

        public async Task<bool> MarkTodoAsCompletedAsync(Guid id)
        {
            return await Todos.MarkAsCompletedAsync(id);
        }
    }
}
