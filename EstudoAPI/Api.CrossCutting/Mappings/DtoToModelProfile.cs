using Api.Domain.Dtos;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<UserModel, UserDto>()
            .ReverseMap(); /*Ele converte de model para dto e de dto para model*/

            CreateMap<UserModel, UserDtoCreate>()
           .ReverseMap();

            CreateMap<UserModel, UserDtoUpdate>()
           .ReverseMap();
        }
    }
}
