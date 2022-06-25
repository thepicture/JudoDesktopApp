using JudoDesktopApp.Models.Entities;
using System.Threading.Tasks;

namespace JudoDesktopApp.Repositories
{
    public interface IPasswordRepository
    {
        Task<bool> IsPasswordRecoveredAsync(User user);
    }
}
