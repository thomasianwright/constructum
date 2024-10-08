using Constructum.Server.Organisations.Commands;
using Constructum.Server.Organisations.Queries;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace Constructum.Server.Controllers;

[Route("api/v1/organisations")]
[ApiController]
public class OrganisationControllerV1(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetOrganisations([FromQuery] string? search, CancellationToken cancellationToken)
    {
        var query = new GetOrganisationsQuery(search);
        
        var result = await mediator.Send(query, cancellationToken);
        
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateOrganisationAsync([FromBody] CreateOrganisationCommand command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(command, cancellationToken);
        
        if (result.IsFailed)
            return BadRequest(result.Errors);
        
        return Ok(result.Value);
    }
}