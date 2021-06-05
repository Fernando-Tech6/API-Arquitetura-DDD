using Api.Domain.Entities;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {    /*Quando for mandar de service para data irá utilizar do model para entity*/
            CreateMap<UserEntity, UserModel>()
            .ReverseMap();
        }
    }
}
