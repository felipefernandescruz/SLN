using Microsoft.EntityFrameworkCore;

using Authentication.Model;

namespace Authentication.Context
{
    public class AuthenticaContext: DbContext
    {
        public AuthenticaContext(DbContextOptions<AuthenticaContext> options): base(options)
        {

        }
        public DbSet<User> register { get; set; }

          
    }


}
