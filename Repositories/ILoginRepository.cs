using JudoDesktopApp.Models.Entities;
using System.Threading.Tasks;

namespace JudoDesktopApp.Repositories
{
    public interface ILoginRepository
    {
        Task<bool> IsSignedInAsync(User user);
    }
}
