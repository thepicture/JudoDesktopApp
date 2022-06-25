using JudoDesktopApp.Models.Entities;
using JudoDesktopApp.Services;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JudoDesktopApp.Repositories
{
    public class PasswordRepository : IPasswordRepository
    {
        private readonly IDbContext context;

        public PasswordRepository(IDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> IsPasswordRecoveredAsync(User user)
        {
            using (JudoBaseEntities entities = context.GetNewInstance())
            {
                if (!entities.Users.AsNoTracking().Any(u => u.UserName == user.UserName))
                {
                    return false;
                }
                byte[] passwordHash = MD5.Create()
                 .ComputeHash(Encoding.UTF8.GetBytes(user.PlainPassword));
                entities.Users.First(u => u.UserName == user.UserName).PasswordHash = passwordHash;
                await entities.SaveChangesAsync();
                return true;
            }
        }
    }
}
