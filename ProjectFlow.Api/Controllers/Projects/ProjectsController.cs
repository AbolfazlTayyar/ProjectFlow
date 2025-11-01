using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectFlow.Application.Projects.CreateProject;
using ProjectFlow.Application.Projects.GetProject;
using ProjectFlow.Application.Projects.SearchProjects;
using ProjectFlow.Domain.Projects;

namespace ProjectFlow.Api.Controllers.Projects;

[ApiController]
[Route("api/projects")]
public class ProjectsController : ControllerBase
{
    private readonly ISender _sender;

    public ProjectsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProject(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetProjectQuery(id);

        var result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> SearchProjects(DateOnly startDate, DateOnly endDate, CancellationToken cancellationToken)
    {
        var query = new SearchProjectsQuery(startDate, endDate);

        var result = await _sender.Send(query, cancellationToken);

        return Ok(result.Value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProject(CreateProjectRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateProjectCommand(
            request.UserId,
            Name.Create(request.Name),
            Description.Create(request.Description),
            DateRange.Create(request.StartDate, request.EndDate),
            TimeEstimate.Create(request.EstimatedHours),
            Money.Create(request.Amount, Currency.FromCode(request.Code)),
            request.MaxMemberCount);

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
            return BadRequest(result.Error);

        return CreatedAtAction(nameof(GetProject), new { id = result.Value }, result.Value);
    }
}
