using FootballShopBackend.Application.DTOs;
using FootballShopBackend.Application.Features.Teams.Commands.CreateTeam;
using FootballShopBackend.Application.Features.Teams.Commands.DeleteTeam;
using FootballShopBackend.Application.Features.Teams.Commands.UpdateTeam;
using FootballShopBackend.Application.Features.Teams.Queries.GetTeamDetail;
using FootballShopBackend.Application.Features.Teams.Queries.GetTeamsList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FootballShopBackend.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : Controller
    {
        private readonly IMediator _mediator;

        public TeamController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("teams")]
        public async Task<ActionResult<List<TeamDTO>>> GetAllTeams()
        {
            var teams = await _mediator.Send(new GetTeamsListQuery());
            return Ok(teams);
        }

        [HttpGet("teams/{id}")]
        public async Task<ActionResult<TeamDTO>> GetTeamById(Guid id)
        {
            var team = await _mediator.Send(new GetTeamDetailQuery(id));
            return Ok(team);
        }

        [HttpPost("teams")]
        public async Task<ActionResult<TeamDTO>> CreateTeam([FromBody] CreateTeamCommand command)
        {
            var team = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetTeamById), new { id = team }, team);
        }

        [HttpDelete("teams/{id}")]
        public async Task<ActionResult> DeleteTeam(Guid id)
        {
            await _mediator.Send(new DeleteTeamCommand(id));
            return NoContent();
        }

        [HttpPut("teams/{id}")]
        public async Task<ActionResult> UpdateTeam(Guid id, [FromBody] UpdateTeamCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
