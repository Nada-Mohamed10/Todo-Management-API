using Todo_Management_API.Enums;

namespace Todo_Management_API.Models
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }

        public TodoStatus Status { get; set; } = TodoStatus.Pending;

        public TodoPriority Priority { get; set; } = TodoPriority.Medium;
        public DateTime? DueDate { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime LastModifiedDate {  get; set; } = DateTime.UtcNow;
    }
}
