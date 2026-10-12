using BreakHomework_CThomason.Models; 
using Microsoft.EntityFrameworkCore;
namespace BreakHomework_CThomason.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<WrestlerModel> Wrestlers{get; set;}
    }
}