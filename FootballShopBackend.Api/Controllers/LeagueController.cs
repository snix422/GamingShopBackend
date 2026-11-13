using FootballShopBackend.Application.DTOs;
using FootballShopBackend.Application.Features.Leagues.Commands.CreateLeague;
using FootballShopBackend.Application.Features.Leagues.Commands.DeleteLeague;
using FootballShopBackend.Application.Features.Leagues.Commands.UpdateLeague;
using FootballShopBackend.Application.Features.Leagues.Queries.GetLeagueDetail;
using FootballShopBackend.Application.Features.Leagues.Queries.GetLeaguesList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FootballShopBackend.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeagueController : Controller
    {
       private readonly IMediator _mediator;
        public LeagueController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("leagues")]
        public async Task<ActionResult<List<LeagueDTO>>> GetAllLeagues()
        {
            var leagues = await _mediator.Send(new GetLeaguesListQuery());
            return Ok(leagues);
        }

        [HttpGet("leagues/{id}")]
        public async Task<ActionResult<LeagueDTO>> GetLeagueById(Guid id)
        {
            var league = await _mediator.Send(new GetLeagueDetailQuery(id));

            return Ok(league);
        }

        [HttpPost("leagues")]
        public async Task<ActionResult<LeagueDTO>> CreateLeague([FromBody] CreateLeagueCommand command)
        {
            var league = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetLeagueById), new { id = league }, league);
        }

        [HttpDelete("leagues/{id}")]
        public async Task<ActionResult> DeleteLeague(Guid id)
        {
            await _mediator.Send(new DeleteLeagueCommand(id));
            return NoContent();
        }

        [HttpPut("leagues/{id}")]
        public async Task<ActionResult<LeagueDTO>> UpdateLeague(Guid id, [FromBody] UpdateLeagueCommand command)
        {
            if (id != command.LeagueId)
            {
                return BadRequest();
            }
            await _mediator.Send(command);
            
            return NoContent();
        }
    }
}
