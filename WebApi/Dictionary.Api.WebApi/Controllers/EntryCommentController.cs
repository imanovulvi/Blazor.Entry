using Dictionary.Common.DTOs.Commands.EntryComment.Create;
using Dictionary.Common.DTOs.Queries.EntryComment.GetEntryComment;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dictionary.Api.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EntryCommentController : ControllerBase
    {
        private readonly IMediator mediator;

        public EntryCommentController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCommentsEntryById([FromQuery]GetEntryCommentQueryRequest request)
        {
            
            return Ok(await mediator.Send(request));
        }

        [HttpPost]
        public async Task<IActionResult> Create(EntryCommentCommandRequest request)
        {
            await mediator.Send(request);
            return Ok(new {IsAdd=true});
        }

    }
}
