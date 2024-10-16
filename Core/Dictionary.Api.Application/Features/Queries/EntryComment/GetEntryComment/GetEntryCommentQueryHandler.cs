using Dictionary.Api.Application.Interface.Repository;
using Dictionary.Common.DTOs.Queries.EntryComment.GetEntryComment;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Api.Application.Features.Queries.EntryComment.GetEntryComment
{
    public class GetEntryCommentQueryHandler : IRequestHandler<GetEntryCommentQueryRequest, List<GetEntryCommentQueryResponse>>
    {
        private readonly IEntryCommentRepository repository;

        public GetEntryCommentQueryHandler(IEntryCommentRepository repository)
        {
            this.repository = repository;
        }
        public async Task<List<GetEntryCommentQueryResponse>> Handle(GetEntryCommentQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await repository.AsQueryable()
                 .AsNoTracking()
                 .OrderByDescending(x=>x.CreateDate)
                 .Include(x => x.User)
                 .Where(x => x.EntryId == request.EntryId).Select(x =>
                 new
                 {
                     x.EntryId,
                     x.CreateDate,
                     x.Content,
                     x.User
                 }).ToListAsync();

            var result2 = await (from comments in repository.AsQueryable()
                                 where comments.EntryId == request.EntryId
                                 join comment in repository.AsQueryable()
                                 on comments.UserId equals comment.UserId
                                 select new
                                 {
                                     comments.EntryId,
                                     comments.CreateDate,
                                     comments.Content,
                                     comments.User
                                 }).AsNoTracking().ToListAsync();
            List<GetEntryCommentQueryResponse> lst = new List<GetEntryCommentQueryResponse>();
            foreach (var item in result)
            {
                lst.Add(
                    new GetEntryCommentQueryResponse()
                    {
                        Content = item.Content,
                        User = item.User,
                        EntryId = item.EntryId,
                        CreateDate = item.CreateDate
                    }
                    );
            }
            return lst;

        }
    }
}
