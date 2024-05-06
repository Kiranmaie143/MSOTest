using Microsoft.EntityFrameworkCore;
using MSOTestSolution.Models;

namespace MSOTestSolution.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>option):base(option)
        {
        }
        public DbSet<Cockpit> Cockpits { get; set; }
       
    }
}
