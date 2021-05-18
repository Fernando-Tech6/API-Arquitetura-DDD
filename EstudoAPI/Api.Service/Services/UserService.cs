using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;

namespace Api.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<UserEntity> _repository;  // Como injeção é passado a interface do repository
        public UserService(IRepository<UserEntity> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public Task<IEnumerable<UserEntity>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<UserEntity> Get(int id)
        {

        }

        public Task<UserEntity> Post(UserEntity user)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserEntity> Put(UserEntity user)
        {
            throw new System.NotImplementedException();
        }
    }
}
