using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Dtos;
using ToDo.Application.Services;

namespace ToDo.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/tasks")]
public class TasksController : ControllerBase
{
    private readonly IToDoTaskService _taskService;

    public TasksController(IToDoTaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ToDoTaskDto>>> GetAll()
    {
        var todos = await _taskService.GetAllAsync();

        return Ok(todos);
    }

    [HttpPost]
    public async Task<ActionResult<ToDoTaskDto>> Create(CreateToDoTaskDto request)
    {
        var task = await _taskService.AddNewAsync(request);

        return CreatedAtAction(nameof(GetById), new { task.Id }, task);
    }

    [HttpGet("{id}", Name = "GetById")]
    public async Task<ActionResult<ToDoTaskDto>> GetById(Guid id)
    {
        var task = await _taskService.GetByIdAsync(id);

        return task is null ? NotFound() : Ok(task);
    }

    [HttpDelete("{id}", Name = "Delete")]
    public async Task<ActionResult<ToDoTaskDto>> Delete(Guid id)
    {
        await _taskService.DeleteAsync(id);

        return NoContent();
    }

    [HttpPut("{id}", Name = "Edit")]
    public async Task<ActionResult<ToDoTaskDto>> Edit([FromRoute]Guid id, [FromBody] EditToDoTaskDto request)
    {
        var updated = await _taskService.UpdateAsync(id, request);

        return Ok(updated);
    }
}
