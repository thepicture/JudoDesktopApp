using JudoDesktopApp.Models.Entities;
using JudoDesktopApp.Services;
using System.Data.Entity;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JudoDesktopApp.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IDbContext context;

        public LoginRepository(IDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> IsSignedInAsync(User user)
        {
            using (JudoBaseEntities entities = context.GetNewInstance())
            {
                if (IsNoLoginOrPasswordPresented(user))
                {
                    return false;
                }
                else
                {
                    byte[] passwordHash = MD5.Create()
                        .ComputeHash(Encoding.UTF8.GetBytes(user.PlainPassword));
                    return await AreLoginAndPasswordCorrectAsync(user, entities, passwordHash);
                }
            }
        }

        private async Task<bool> AreLoginAndPasswordCorrectAsync(User user,
                                                       JudoBaseEntities entities,
                                                       byte[] passwordHash)
        {
            return await entities.Users
                .AsNoTracking()
                .AnyAsync(u => u.UserName == user.UserName && u.PasswordHash == passwordHash);
        }

        private static bool IsNoLoginOrPasswordPresented(User user)
        {
            return string.IsNullOrWhiteSpace(user.UserName)
                   || string.IsNullOrWhiteSpace(user.PlainPassword);
        }
    }
}
