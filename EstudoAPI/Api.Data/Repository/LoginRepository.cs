using System;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ApplicationDbContext _context;

        public LoginRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var delete = await _context.Logins.SingleOrDefaultAsync(t => t.Id.Equals(id));

                if (delete != null)  /*TESTAR SE SERÁ NULL OU FALSE O RETORNO*/
                {
                    _context.Logins.Remove(delete);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<LoginUser> LoginAsync(LoginUser user)
        {
            try
            { /*verificar se a senha e o usuario está correto*/
                var verification = await _context.Logins.Where(t => t.Username.ToLower() == user.Username.ToLower() &&
                t.Password == user.Password).FirstOrDefaultAsync();

                if (verification == null)
                {  /*Se a senha e o usurname forem invalidos retornar null
                     acionando um tratamento de erro no controller.*/
                    return null;
                }
                else
                {
                    return verification;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<LoginUser> RegisterAsync(LoginUser user)
        {
            try
            {
                _context.Logins.Add(user);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return user;
        }
    }
}
