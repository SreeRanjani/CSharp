using Cart.Models;
using Microsoft.EntityFrameworkCore;

namespace Cart.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        DbSet<Category> Categories { get; set; }
    }
}
