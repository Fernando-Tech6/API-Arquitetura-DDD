using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services
{
    public interface ILoginService
    {

        Task<LoginUser> Post(LoginUser user);
        Task<LoginUser> PostLogin(LoginUser user);
        Task<bool> Delete(int id);
    }
}
