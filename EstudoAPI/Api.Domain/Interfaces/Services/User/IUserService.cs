using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos;

namespace Api.Domain.Interfaces.Services.User
{
    public interface IUserService
    {   /*Interface para regra de negocios*/
        Task<UserDto> Get(int id);
        Task<IEnumerable<UserDto>> GetAll();
        Task<UserDtoCreateResult> Post(UserDtoCreate user);
        Task<UserDtoUpdateResult> Patch(UserDtoUpdate user);
        Task<bool> Delete(int id);
    }
}
