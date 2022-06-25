using JudoDesktopApp.Models.Entities;
using JudoDesktopApp.Services;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JudoDesktopApp.Repositories
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly IDbContext context;

        public RegistrationRepository(IDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> IsSignedUpAsync(User user)
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
                    User newUser = new User
                    {
                        UserName = user.UserName,
                        PasswordHash = passwordHash
                    };
                    entities.Users.Add(newUser);
                    await entities.SaveChangesAsync();
                    return true;
                }
            }
        }

        private static bool IsNoLoginOrPasswordPresented(User user)
        {
            return string.IsNullOrWhiteSpace(user.UserName)
                   || string.IsNullOrWhiteSpace(user.PlainPassword);
        }
    }
}
