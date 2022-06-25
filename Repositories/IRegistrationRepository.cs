using JudoDesktopApp.Models.Entities;
using System.Threading.Tasks;

namespace JudoDesktopApp.Repositories
{
    public interface IRegistrationRepository
    {
        Task<bool> IsSignedUpAsync(User user);
    }
}
