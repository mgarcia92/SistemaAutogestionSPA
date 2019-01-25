using Microsoft.EntityFrameworkCore;

namespace WebSPAGestionEmpleados.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        
    }
}