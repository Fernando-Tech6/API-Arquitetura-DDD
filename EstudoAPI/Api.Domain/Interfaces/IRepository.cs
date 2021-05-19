using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Data.Repository
{    // Será criado Repository no modo generico.
    public interface IRepository<T> where T : BaseEntity
    {
        /*Os metodos assyncronos serão criados de modo generico também*/
        Task<T> InsertAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<bool> DeleteAsync(int id);
        Task<T> SelectAsync(int id);
        Task<IEnumerable<T>> SelectAsync();
        Task<bool> ExistAsync(int id);

    }
}
