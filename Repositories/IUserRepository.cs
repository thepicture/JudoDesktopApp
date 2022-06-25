using JudoDesktopApp.Models.Entities;
using System.Threading.Tasks;

namespace JudoDesktopApp.Repositories
{
    public interface IUserRepository
    {
        Task<bool> IsSignedInAsync(User user);
    }
}
