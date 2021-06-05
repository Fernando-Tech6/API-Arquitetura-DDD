using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces
{
    public interface ILoginRepository
    {
        /*Criado para uso de autenticação de usuario*/
        Task<LoginUser> RegisterAsync(LoginUser user);
        Task<LoginUser> LoginAsync(LoginUser user);
        Task<bool> DeleteAsync(int id);
    }
}
