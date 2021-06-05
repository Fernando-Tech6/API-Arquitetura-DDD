using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.Repository;
using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Models;
using AutoMapper;

namespace Api.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<UserEntity> _repository;  // Como injeção é passado a interface do repository
        private readonly IMapper _mapper;   /*Para fazer a injeção do automapper*/
        public UserService(IRepository<UserEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var list = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<UserDto>>(list);
        }

        public async Task<UserDto> Get(int id)
        {
            var entity = await _repository.SelectIdAsync(id);
            return _mapper.Map<UserDto>(entity);  /*Mapper converte a entity que vem do banco de dados em dto*/
        }

        public async Task<UserDtoCreateResult> Post(UserDtoCreate user)
        {
            var post = _mapper.Map<UserModel>(user);
            var entity = _mapper.Map<UserEntity>(post);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<UserDtoCreateResult>(result);
        }

        public async Task<UserDtoUpdateResult> Patch(UserDtoUpdate user)
        {
            var update = _mapper.Map<UserModel>(user);
            var entity = _mapper.Map<UserEntity>(update);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<UserDtoUpdateResult>(result);

        }
    }
}
