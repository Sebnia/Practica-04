using Practica_04.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Practica_04.Data
{
    public class FailsContext : IdentityDbContext
    {
        public FailsContext(DbContextOptions dco) : base(dco) {
            
        }
    }
}
