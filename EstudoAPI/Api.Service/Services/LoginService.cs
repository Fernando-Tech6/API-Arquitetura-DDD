using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services;

namespace Api.Service.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _repository;
        public LoginService(ILoginRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<LoginUser> Post(LoginUser user)
        {
            return await _repository.RegisterAsync(user);
        }

        public async Task<LoginUser> PostLogin(LoginUser user)
        {
            return await _repository.LoginAsync(user);
        }
    }
}
