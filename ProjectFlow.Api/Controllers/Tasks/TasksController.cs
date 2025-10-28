using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectFlow.Application.Tasks.GetTask;

namespace ProjectFlow.Api.Controllers.Tasks;

[ApiController]
[Route("api/tasks")]
public class TasksController : ControllerBase
{
    private readonly ISender _sender;

    public TasksController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTask(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetTaskQuery(id);

        var result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }
}
