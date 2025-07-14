using System.ComponentModel.DataAnnotations;
using Todo_Management_API.Enums;

namespace Todo_Management_API.DTOs
{
    public class UpdateTodoDto
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        public string? Description { get; set; }

        public TodoStatus Status { get; set; } = TodoStatus.Pending;

        public TodoPriority Priority { get; set; } = TodoPriority.Medium;
        public DateTime? DueDate { get; set; }
    }
}
