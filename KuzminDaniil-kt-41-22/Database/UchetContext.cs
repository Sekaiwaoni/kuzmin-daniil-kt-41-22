using Microsoft.EntityFrameworkCore;

namespace KuzminDaniil_kt_41_22.Database 
{
    public class UchetDbContext : DbContext
    {
        public UchetDbContext(DbContextOptions<UchetDbContext> options) : base(options) 
        { 
        
        }
    }
}