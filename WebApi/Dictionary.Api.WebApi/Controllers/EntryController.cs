using Dictionary.Common.DTOs.Commands.Entry.Create;
using Dictionary.Common.DTOs.Commands.Entry.CreateFav;
using Dictionary.Common.DTOs.Commands.Entry.CreateVote;
using Dictionary.Common.DTOs.Commands.Entry.DeleteFav;
using Dictionary.Common.DTOs.Commands.Entry.DeleteVote;
using Dictionary.Common.DTOs.Commands.Entry.GetEntryFav;
using Dictionary.Common.DTOs.Commands.Entry.UserDeleteFav;
using Dictionary.Common.DTOs.Queries.Entry.Get;
using Dictionary.Common.DTOs.Queries.Entry.GetById;
using Dictionary.Common.DTOs.Queries.Entry.GetLeft;
using Dictionary.Common.DTOs.Queries.Entry.Search;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dictionary.Api.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EntryController : ControllerBase
    {
        private readonly IMediator mediator;

        public EntryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetEntry([FromQuery]GetEntryContentQueryRequest request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetEntryById([FromQuery] GetEntryByIdQueryRequest request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> GetEntrySearch([FromBody] EntrySearchQueryRequest request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> GetEntryLeft(GetEntrysQueryRequest request)
        {
            var result=await mediator.Send(request);
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Create(EntryCreateCommandReuqest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetEntryFav([FromQuery]GetEntryUserFavCommandRequest request)
        {
            
            return Ok(await mediator.Send(request));
        }

        [HttpPost]
        public async Task<IActionResult> CreateFav(EntryFavCreateCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> CreateVote(EntryVoteCreateCommandReuqest request)
        {
            await mediator.Send(request);
            return Ok(true);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteVote(EntryVoteDeleteCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFav(EntryFavDeleteCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }


        [HttpDelete]
        public async Task<IActionResult> UserDeleteFav(UserDeleteFavoriteCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
