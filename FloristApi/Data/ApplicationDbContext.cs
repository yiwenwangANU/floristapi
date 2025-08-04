using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FloristApi.Data
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }
    }
}
