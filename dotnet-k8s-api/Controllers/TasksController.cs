using DotnetK8sApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetK8sApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private static readonly List<TaskItem> Tasks = new()
    {
        new(1, "Build the .NET Web API", true),
        new(2, "Package it as a container", true),
        new(3, "Deploy it to Kubernetes", false)
    };

    [HttpGet]
    public ActionResult<IEnumerable<TaskItem>> GetAll()
    {
        return Ok(Tasks);
    }

    [HttpGet("{id:int}")]
    public ActionResult<TaskItem> GetById(int id)
    {
        var task = Tasks.FirstOrDefault(item => item.Id == id);
        return task is null ? NotFound() : Ok(task);
    }

    [HttpPost]
    public ActionResult<TaskItem> Create(CreateTaskRequest request)
    {
        var nextId = Tasks.Count == 0 ? 1 : Tasks.Max(item => item.Id) + 1;
        var task = new TaskItem(nextId, request.Title, false);
        Tasks.Add(task);

        return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
    }
}

public record CreateTaskRequest(string Title);
