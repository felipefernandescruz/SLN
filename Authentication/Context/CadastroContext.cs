using Microsoft.EntityFrameworkCore;

using Authentication.Model;

namespace Authentication.Context
{
    public class CadastroContext: DbContext
    {
        public CadastroContext(DbContextOptions<CadastroContext> options): base(options)
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<UserLogin> UserLogin { get; set; }
        public DbSet<OriginAccess> OrignAccess { get; set; }

          
    }


}
