using JudoDesktopApp.Models.Entities;

namespace JudoDesktopApp.Services
{
    public interface IDbContext
    {
        JudoBaseEntities GetNewInstance();
    }
}
