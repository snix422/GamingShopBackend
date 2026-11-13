using FootballShopBackend.Application.DTOs;
using FootballShopBackend.Application.Features.Review.Queries.GetReviewsList;
using FootballShopBackend.Application.Features.Reviews.Commands.CreateReview;
using FootballShopBackend.Application.Features.Reviews.Commands.DeleteProduct;
using FootballShopBackend.Application.Features.Reviews.Commands.UpdateReview;
using FootballShopBackend.Application.Features.Reviews.Queries.GetReviewDetail;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FootballShopBackend.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : Controller
    {
       private readonly IMediator _mediator;
       public ReviewController(IMediator mediator)
       {
            _mediator = mediator;
       }

        [HttpGet("reviews")]
        public async Task<ActionResult<List<ReviewDTO>>> GetAllReviews()
        {
            var reviews = await _mediator.Send(new GetReviewsListQuery());
            return Ok(reviews);
        }

        [HttpGet("reviews/{id}")]
        public async Task<ActionResult<ReviewDTO>> GetReviewById(Guid id)
        {
            var review = await _mediator.Send(new GetReviewDetailQuery(id));
            return Ok(review);
        }

        [HttpPost("reviews")]
        public async Task<ActionResult<ReviewDTO>> CreateReview([FromBody] CreateReviewCommand command)
        {
            var review = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetReviewById), new { id = review }, review);
        }

        [HttpDelete("reviews/{id}")]
        public async Task<ActionResult> DeleteReview(Guid id)
        {
            await _mediator.Send(new DeleteReviewCommand(id));
            return NoContent();
        }

        [HttpPut("reviews/{id}")]
        public async Task<ActionResult> UpdateReview(Guid id, [FromBody] UpdateReviewCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
