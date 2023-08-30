using LaBook_Planet.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LaBook_Planet.Data.Context
{
    public class LaBook_PlanetContext : IdentityDbContext<AppUser>
    {
        public LaBook_PlanetContext(DbContextOptions<LaBook_PlanetContext> options) : base(options) 
        {

        }
    }
}
