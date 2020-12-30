using Practica_04.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Practica_04.Data
{
    public class FailsContext : IdentityDbContext
    {
        public DbSet<Practica_04.Models.Fails> Fails {get; set;} 
        public FailsContext(DbContextOptions dco) : base(dco) {
            
        }
    }
}
