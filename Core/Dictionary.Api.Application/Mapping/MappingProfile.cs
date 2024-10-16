using AutoMapper;
using Dictionary.Api.Domain.Entitys;
using Dictionary.Common.DTOs.Commands.Entry.Create;
using Dictionary.Common.DTOs.Commands.Entry.CreateFav;
using Dictionary.Common.DTOs.Commands.Entry.CreateVote;
using Dictionary.Common.DTOs.Commands.EntryComment.Create;
using Dictionary.Common.DTOs.Commands.User.Create;
using Dictionary.Common.DTOs.Commands.User.Update;
using Dictionary.Common.DTOs.Queries.User.Get;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Api.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserCreateCommandRequest>().ReverseMap();
            CreateMap<User, UserUpdateCommandRequest>().ReverseMap();
            CreateMap<Entry, EntryCreateCommandReuqest>().ReverseMap();
            CreateMap<EntryFavorite, EntryFavCreateCommandRequest>().ReverseMap();
            CreateMap<EntryVote, EntryVoteCreateCommandReuqest>().ReverseMap();
            CreateMap<EntryComment, EntryCommentCommandRequest>().ReverseMap();
            CreateMap<User, GetUserDetailQueryResponse>().ReverseMap();
        }
    }
}
