using Microsoft.EntityFrameworkCore;

namespace JWTLoginToken.Authentication
{
    public class IdentityDbContext<T>
    {
        internal void OnModelCreating(ModelBuilder builder)
        {
            throw new NotImplementedException();
        }
    }
}