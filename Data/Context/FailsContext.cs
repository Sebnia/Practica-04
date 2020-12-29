using Practica_04.Models;
using Microsoft.EntityFrameworkCore;
namespace Practica_04.Data
{
    public class FailsContext : DbContext
    {
        public FailsContext(DbContextOptions dco) : base(dco) {

        }
    }
}
