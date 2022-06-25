using JudoDesktopApp.Models.Entities;

namespace JudoDesktopApp.Services
{
    public class DbContext : IDbContext
    {
        public JudoBaseEntities GetNewInstance()
        {
            return new JudoBaseEntities();
        }
    }
}
