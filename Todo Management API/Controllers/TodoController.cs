using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo_Management_API.DTOs;
using Todo_Management_API.Enums;
using Todo_Management_API.Service;

namespace Todo_Management_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {

        ITodoService todoService;
        public TodoController(ITodoService todoService)
        {
            this.todoService = todoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTodosAsync()
        {
            var todos = await todoService.GetAllTodosAsync();
            return Ok(todos);
        }

        [HttpGet("{id}", Name = "GetTodoById")]
        public async Task<IActionResult> GetTodoByIdAsync(Guid id)
        {
            var todo = await todoService.GetTodoByIdAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        [HttpPost]
        public async Task<IActionResult> AddTodoAsync([FromBody] CreateTodoDto todo)
        {
            if (todo == null)
            {
                return BadRequest("Todo cannot be null");
            }
            var createdTodo = await todoService.AddTodoAsync(todo);
            return CreatedAtRoute(
         "GetTodoById",
          new { Id = createdTodo.Id },
          createdTodo
           );
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateTodoDto todo)
        {
            if (todo == null || id != todo.Id)
            {
                return BadRequest("Invalid Todo data");
            }
            var result = await todoService.UpdateAsync(todo);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await todoService.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }


        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetTodosByStatusAsync(TodoStatus status)
        {
            var todos = await todoService.GetTodosByStatusAsync(status);
            return Ok(todos);
        }

        [HttpPost("{id}/complete")]
        public async Task<IActionResult> MarkAsCompletedAsync(Guid id)
        {
            var result = await todoService.MarkAsCompletedAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();


        }
    }
}
